using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WEBSAIGONGLISTEN.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEBSAIGONGLISTEN.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AccountController> _logger;
        private readonly int _pageSize = 10;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int page = 1, string searchName = "", string searchAddress = "", string roleFilter = "")
        {
            var users = _userManager.Users.AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(searchName))
            {
                users = users.Where(u => u.FullName.ToLower().Contains(searchName.ToLower()));
            }

            if (!string.IsNullOrEmpty(searchAddress))
            {
                users = users.Where(u => u.Address != null && u.Address.ToLower().Contains(searchAddress.ToLower()));
            }

            if (!string.IsNullOrEmpty(roleFilter))
            {
                // Get users with specific role
                var usersInRole = await _userManager.GetUsersInRoleAsync(roleFilter);
                var userIdsInRole = usersInRole.Select(u => u.Id);
                users = users.Where(u => userIdsInRole.Contains(u.Id));
            }

            // Order by username
            users = users.OrderBy(u => u.UserName);

            // Get all roles for filter dropdown
            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();
            ViewBag.AllRoles = allRoles;
            ViewBag.SearchName = searchName;
            ViewBag.SearchAddress = searchAddress;
            ViewBag.SelectedRole = roleFilter;

            int totalUsers = await users.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalUsers / _pageSize);

            var paginatedUsers = await users.Skip((page - 1) * _pageSize).Take(_pageSize).ToListAsync();

            // Get roles for each user
            var usersWithRoles = new List<(ApplicationUser User, string Role)>();
            foreach (var user in paginatedUsers)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var role = userRoles.FirstOrDefault() ?? "Không có vai trò";
                usersWithRoles.Add((user, role));
            }

            ViewData["TotalPages"] = totalPages;
            ViewData["CurrentPage"] = page;
            ViewData["UsersWithRoles"] = usersWithRoles;

            return View(paginatedUsers);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var roles = _roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Name
            });

            var model = new ChangeRoleViewModel
            {
                UserId = userId,
                CurrentRole = await GetCurrentUserRole(user),
                Roles = roles.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(ChangeRoleViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var selectedRole = model.SelectedRole;

            var userRoles = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, userRoles.ToArray());

            await _userManager.AddToRoleAsync(user, selectedRole);

            _logger.LogInformation($"User '{user.UserName}' role changed to '{selectedRole}'.");

            return RedirectToAction(nameof(Index));
        }

        private async Task<string> GetCurrentUserRole(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.FirstOrDefault();
        }
    }
}
