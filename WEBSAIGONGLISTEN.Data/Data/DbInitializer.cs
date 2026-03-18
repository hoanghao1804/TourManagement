using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WEBSAIGONGLISTEN.Models;

namespace WEBSAIGONGLISTEN.Data.Data
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Đảm bảo database được tạo
            await context.Database.EnsureCreatedAsync();

            // Tạo roles nếu chưa có
            await SeedRolesAsync(roleManager);

            // Tạo admin user nếu chưa có
            await SeedAdminUserAsync(userManager);

            // Tạo dữ liệu mẫu
            await SeedDataAsync(context);
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "Customer", "Company" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            // Kiểm tra xem đã có admin user chưa
            var adminUser = await userManager.FindByEmailAsync("admin@saigonglisten.com");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = "admin@saigonglisten.com",
                    Email = "admin@saigonglisten.com",
                    EmailConfirmed = true,
                    FullName = "Administrator",
                    Address = "TP.HCM, Việt Nam"
                };

                var result = await userManager.CreateAsync(adminUser, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }

        private static async Task SeedDataAsync(ApplicationDbContext context)
        {
            // Kiểm tra và tạo categories
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Du lịch miền Bắc" },
                    new Category { Name = "Du lịch miền Trung" },
                    new Category { Name = "Du lịch miền Nam" },
                    new Category { Name = "Du lịch nước ngoài" },
                    new Category { Name = "Tour nghỉ dưỡng" },
                    new Category { Name = "Tour khám phá" }
                };

                context.Categories.AddRange(categories);
                await context.SaveChangesAsync();
            }

            // Kiểm tra và tạo products
            if (!context.Products.Any())
            {
                var categories = await context.Categories.ToListAsync();
                var products = ProductData.GetProducts(categories);

                context.Products.AddRange(products);
                await context.SaveChangesAsync();
            }

            // Kiểm tra và tạo tour days
            if (!context.TourDays.Any())
            {
                var products = await context.Products.ToListAsync();
                var categories = await context.Categories.ToListAsync();

                var tourDays = new List<TourDay>();

                foreach (var product in products)
                {
                    var productCategory = categories.First(c => c.Id == product.CategoryId);
                    int totalDays = (product.EndDate - product.StartDate).Days + 1;

                    for (int i = 1; i <= totalDays; i++)
                    {
                        tourDays.Add(new TourDay
                        {
                            DayNumber = i,
                            Description = $"Mô tả chi tiết cho ngày {i} của tour {product.Name}. Tham quan các địa điểm nổi tiếng, thưởng thức ẩm thực địa phương và trải nghiệm văn hóa đặc trưng.",
                            ProductId = product.Id,
                            CategoryId = product.CategoryId,
                            ImageUrl = GetTourDayImage(product.Name, i)
                        });
                    }
                }

                context.TourDays.AddRange(tourDays);
                await context.SaveChangesAsync();
            }

            // Kiểm tra và tạo thông báo mẫu (chỉ tạo nếu có admin user)
            if (!context.ThongBaos.Any())
            {
                var adminUser = await context.Users.FirstOrDefaultAsync(u => u.Email == "admin@saigonglisten.com");
                if (adminUser != null)
                {
                    var thongBaos = new List<ThongBao>
                    {
                        new ThongBao
                        {
                            Description = "Chào mừng đến với Saigon Listen Travel! Cảm ơn bạn đã tin tưởng và lựa chọn dịch vụ du lịch của chúng tôi. Chúng tôi cam kết mang đến những trải nghiệm du lịch tuyệt vời nhất.",
                            UserId = adminUser.Id
                        },
                        new ThongBao
                        {
                            Description = "Khuyến mãi tour hè 2024: Giảm giá 20% cho tất cả các tour trong tháng 6-8/2024. Đăng ký ngay để nhận ưu đãi tốt nhất!",
                            UserId = adminUser.Id
                        },
                        new ThongBao
                        {
                            Description = "Cập nhật chính sách hủy tour: Hủy trước 7 ngày được hoàn 100%, hủy trước 3 ngày được hoàn 50%, hủy trong vòng 3 ngày không được hoàn tiền.",
                            UserId = adminUser.Id
                        }
                    };

                    context.ThongBaos.AddRange(thongBaos);
                    await context.SaveChangesAsync();
                }
            }
        }

        private static string GetTourDayImage(string tourName, int dayNumber)
        {
            // Sử dụng ảnh từ Picsum (Lorem Picsum) - ảnh ngẫu nhiên và đảm bảo hoạt động
            var imageUrls = new List<string>
            {
                "https://picsum.photos/800/600?random=1", // Ảnh ngẫu nhiên 1
                "https://picsum.photos/800/600?random=2", // Ảnh ngẫu nhiên 2
                "https://picsum.photos/800/600?random=3", // Ảnh ngẫu nhiên 3
                "https://picsum.photos/800/600?random=4", // Ảnh ngẫu nhiên 4
                "https://picsum.photos/800/600?random=5"  // Ảnh ngẫu nhiên 5
            };

            // Tạo seed dựa trên tên tour và ngày để đảm bảo ảnh nhất quán
            string seed = $"{tourName.GetHashCode()}{dayNumber}";
            int imageIndex = Math.Abs(seed.GetHashCode()) % imageUrls.Count;
            return imageUrls[imageIndex];
        }
    }
}
