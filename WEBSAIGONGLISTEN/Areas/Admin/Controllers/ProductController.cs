using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WEBSAIGONGLISTEN.Models;
using WEBSAIGONGLISTEN.Repositories;

namespace WEBSAIGONGLISTEN.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Company)]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITourDayRepository _tourDayRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AccountController> _logger;
        private readonly ApplicationDbContext _context;// day la hung
        private readonly IConfiguration _configuration;
        private readonly int _pageSize = 10;
        public ProductController(IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<AccountController> logger, ITourDayRepository tourDayRepository, IConfiguration configuration)
        {
            _context = context; // cho nay la hung
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _tourDayRepository = tourDayRepository;
            _configuration = configuration;
        }
        // Hiển thị danh sách sản phẩm
        public async Task<IActionResult> Index(int page = 1, string searchName = "", int? categoryId = null, string fromDate = "", string toDate = "")
        {
            var allProducts = await _productRepository.GetAllAsync();

            // Apply filters
            if (!string.IsNullOrEmpty(searchName))
            {
                allProducts = allProducts.Where(p => p.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase));
            }

            if (categoryId.HasValue)
            {
                allProducts = allProducts.Where(p => p.CategoryId == categoryId.Value);
            }

            if (!string.IsNullOrEmpty(fromDate) && DateTime.TryParse(fromDate, out DateTime startDate))
            {
                allProducts = allProducts.Where(p => p.StartDate >= startDate);
            }

            if (!string.IsNullOrEmpty(toDate) && DateTime.TryParse(toDate, out DateTime endDate))
            {
                allProducts = allProducts.Where(p => p.EndDate <= endDate);
            }

            // Get categories for filter dropdown
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = categories;
            ViewBag.SearchName = searchName;
            ViewBag.SelectedCategoryId = categoryId;
            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;

            int totalProducts = allProducts.Count();
            int totalPages = (int)Math.Ceiling((double)totalProducts / _pageSize);

            var paginatedProducts = allProducts.Skip((page - 1) * _pageSize).Take(_pageSize).ToList();

            ViewData["TotalPages"] = totalPages;
            ViewData["CurrentPage"] = page;

            return View(paginatedProducts);
        }
        // Hiển thị form thêm sản phẩm mới
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            ViewBag.GoogleMapsApiKey = _configuration["GoogleMapsAPI:ApiKey"];
            return View();
        }
        // Xử lý thêm sản phẩm mới
        [HttpPost]
        public async Task<IActionResult> Add(Product product, IFormFile imageUrl)
        {
            // Kiểm tra product có null không
            if (product == null)
            {
                TempData["ErrorMessage"] = "Dữ liệu sản phẩm không hợp lệ";
                return RedirectToAction(nameof(Add));
            }

            // Kiểm tra validation cho các trường bắt buộc
            if (product.StartDate != default(DateTime) && product.EndDate != default(DateTime))
            {
                if (product.StartDate >= product.EndDate)
                {
                    ModelState.AddModelError("EndDate", "Ngày kết thúc phải sau ngày bắt đầu");
                }
                
                // Kiểm tra ngày bắt đầu không được trong quá khứ
                if (product.StartDate < DateTime.Today)
                {
                    ModelState.AddModelError("StartDate", "Ngày bắt đầu không được trong quá khứ");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imageUrl != null)
                    {
                        // Lưu hình ảnh đại diện tham khảo bài 02 hàm SaveImage
                        product.ImageUrl = await SaveImage(imageUrl);
                    }

                    await _productRepository.AddAsync(product);

                    TempData["SuccessMessage"] = "Thêm sản phẩm thành công!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra khi thêm sản phẩm: " + ex.Message);
                }
            }

            // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", product?.CategoryId);
            ViewBag.GoogleMapsApiKey = _configuration["GoogleMapsAPI:ApiKey"];
            return View(product);
        }
        // Viết thêm hàm SaveImage (tham khảo bài 02)
        private async Task<string> SaveImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                throw new ArgumentException("File hình ảnh không hợp lệ");
            }

            // Tạo tên file duy nhất để tránh trùng lặp
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var savePath = Path.Combine("wwwroot/images", fileName);
            
            // Đảm bảo thư mục tồn tại
            var directory = Path.GetDirectoryName(savePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/" + fileName; // Trả về đường dẫn tương đối
        }
        //Nhớ tạo folder images trong wwwroot

        // Hiển thị thông tin chi tiết sản phẩm
        // Route: /admin/display/{id}
        // Hiển thị thông tin chi tiết sản phẩm
        // Route: /admin/display/{id}
        [HttpGet("product/display/{id}")]
        public async Task<IActionResult> Display(int id)
        {
            // Lấy sản phẩm theo id
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            // Lấy các TourDays liên quan đến sản phẩm (giả sử có phương thức để lấy các ngày tour này)
            var tourDays = await _tourDayRepository.GetTourdaysByProductIdAsync(id);

            // Tạo và gán giá trị cho ProductDisplayViewModel
            var productDisplayViewModel = new ProductDisplayViewModel
            {
                Product = product,
                TourDays = tourDays
            };

            // Trả về view với ProductDisplayViewModel
            return View(productDisplayViewModel);
        }


        // Hiển thị form cập nhật sản phẩm
        // Route: /Admin/product/update/{id}
        [HttpGet("product/update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name",
            product.CategoryId);
            ViewBag.GoogleMapsApiKey = _configuration["GoogleMapsAPI:ApiKey"];
            return View(product);
        }
        // Xử lý cập nhật sản phẩm
        // Route: /Admin/product/update/{id} (POST)
        [HttpPost("product/update/{id}")]
        public async Task<IActionResult> Update(int id, Product product, IFormFile imageUrl)
        {
            try
            {
                ModelState.Remove("ImageUrl"); // Loại bỏ xác thực ModelState cho ImageUrl
                
                // Kiểm tra product có null không
                if (product == null)
                {
                    TempData["ErrorMessage"] = "Dữ liệu sản phẩm không hợp lệ";
                    return RedirectToAction(nameof(Index));
                }
                
                // Kiểm tra validation cho các trường bắt buộc
                if (product.StartDate != default(DateTime) && product.EndDate != default(DateTime) && product.StartDate >= product.EndDate)
                {
                    ModelState.AddModelError("EndDate", "Ngày kết thúc phải sau ngày bắt đầu");
                }
                
                if (id != product.Id)
                {
                    return NotFound();
                }
            
            if (ModelState.IsValid)
            {
                try
                {
                    var existingProduct = await _productRepository.GetByIdAsync(id);
                    
                    // Kiểm tra xem sản phẩm có tồn tại không
                    if (existingProduct == null)
                    {
                        return NotFound();
                    }
                    
                    // Giữ nguyên thông tin hình ảnh nếu không có hình mới được tải lên
                    if (imageUrl == null)
                    {
                        product.ImageUrl = existingProduct.ImageUrl;
                    }
                    else
                    {
                        // Lưu hình ảnh mới
                        product.ImageUrl = await SaveImage(imageUrl);
                    }
                    
                    // Cập nhật các thông tin khác của sản phẩm
                    existingProduct.Name = product.Name;
                    existingProduct.Description = product.Description;
                    existingProduct.CategoryId = product.CategoryId;
                    existingProduct.ImageUrl = product.ImageUrl;
                    existingProduct.Quantity = product.Quantity;
                    existingProduct.StartDate = product.StartDate;
                    existingProduct.EndDate = product.EndDate;
                    existingProduct.PriceUnder2 = product.PriceUnder2;
                    existingProduct.Price2To10 = product.Price2To10;
                    existingProduct.PriceAbove10 = product.PriceAbove10;
                    existingProduct.Latitude = product.Latitude;
                    existingProduct.Longitude = product.Longitude;
                    existingProduct.Address = product.Address;
                    existingProduct.City = product.City;
                    existingProduct.Province = product.Province;

                    await _productRepository.UpdateAsync(existingProduct);
                    
                    TempData["SuccessMessage"] = "Cập nhật sản phẩm thành công!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra khi cập nhật sản phẩm: " + ex.Message);
                }
            }
            
            // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", product.CategoryId);
            ViewBag.GoogleMapsApiKey = _configuration["GoogleMapsAPI:ApiKey"];
            return View(product);
            }
            catch (Exception ex)
            {
                // Log lỗi chi tiết
                _logger.LogError(ex, "Lỗi khi cập nhật sản phẩm với ID: {ProductId}", id);
                TempData["ErrorMessage"] = "Có lỗi xảy ra khi cập nhật sản phẩm. Vui lòng thử lại.";
                return RedirectToAction(nameof(Index));
            }
        }
        // Hiển thị form xác nhận xóa sản phẩm
        // Route: /admin/delete/{id}
        [HttpGet("product/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            
            // Lấy danh sách tour days liên quan
            var tourDays = await _tourDayRepository.GetTourdaysByProductIdAsync(id);
            ViewBag.TourDays = tourDays;
            ViewBag.HasTourDays = tourDays != null && tourDays.Any();
            
            return View(product);
        }
        // Xử lý xóa sản phẩm
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                // Kiểm tra xem sản phẩm có tour liên quan không
                var tourDays = await _tourDayRepository.GetTourdaysByProductIdAsync(id);
                
                if (tourDays != null && tourDays.Any())
                {
                    // Xóa cả tour liên quan trước khi xóa sản phẩm
                    foreach (var tourDay in tourDays)
                    {
                        await _tourDayRepository.DeleteTourDayAsync(tourDay.Id);
                    }
                }
                
                await _productRepository.DeleteAsync(id);
                
                if (tourDays != null && tourDays.Any())
                {
                    TempData["SuccessMessage"] = $"Xóa sản phẩm và {tourDays.Count()} ngày tour liên quan thành công!";
                }
                else
                {
                    TempData["SuccessMessage"] = "Xóa sản phẩm thành công!";
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xóa sản phẩm với ID: {ProductId}", id);
                TempData["ErrorMessage"] = "Có lỗi xảy ra khi xóa sản phẩm. Vui lòng thử lại.";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Search(string query, string searchType)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                // Trả về một View trống hoặc thông báo không tìm thấy.
                return View("Search", new List<Product>());
            }

            if (searchType == "product")
            {
                // Chuyển đổi query để tìm kiếm các sản phẩm chứa các từ được phân tách bởi khoảng trắng
                var keywords = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var products = await _context.Products
                    .Where(p => keywords.Any(keyword => p.Name.Contains(keyword)))
                    .ToListAsync();

                return View("Search", products);
            }
            else if (searchType == "category")
            {
                // Chuyển đổi query để tìm kiếm các sản phẩm chứa các từ được phân tách bởi khoảng trắng
                var keywords = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var categories = await _context.Categories
.Where(c => keywords.Any(keyword => c.Name.Contains(keyword)))
                    .ToListAsync();

                return View("SearchCategory", categories);
            }
            else if (searchType == "user")
            {
                // Chuyển đổi query để tìm kiếm các sản phẩm chứa các từ được phân tách bởi khoảng trắng
                var keywords = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var users = _userManager.Users
                    .Where(u => keywords.Any(keyword => u.UserName.Contains(keyword) || u.Email.Contains(keyword)))
                    .OrderBy(u => u.UserName);

                var searchResults = await users.ToListAsync();

                return View("SearchUser", searchResults);
            }

            return NotFound(); // Trong trường hợp searchType không hợp lệ
        }




    }
}