using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WEBSAIGONGLISTEN.Models;

namespace WEBSAIGONGLISTEN.ViewComponents
{
    public class UserInfoViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserInfoViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Content("");
            }

            var userId = ((ClaimsPrincipal)User).FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Content("");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Content("");
            }

            var fullName = user.FullName;
            if (string.IsNullOrEmpty(fullName))
            {
                // Nếu không có FullName, lấy từ email và format đẹp hơn
                var email = user.Email;
                if (!string.IsNullOrEmpty(email) && email.Contains("@"))
                {
                    var emailPart = email.Split('@')[0];
                    // Loại bỏ số và ký tự đặc biệt, chỉ giữ chữ cái
                    var cleanName = new string(emailPart.Where(c => char.IsLetter(c)).ToArray());
                    if (!string.IsNullOrEmpty(cleanName))
                    {
                        fullName = char.ToUpper(cleanName[0]) + cleanName.Substring(1).ToLower();
                    }
                    else
                    {
                        fullName = char.ToUpper(emailPart[0]) + emailPart.Substring(1);
                    }
                }
                else
                {
                    fullName = email ?? "Người dùng";
                }
            }

            return View("Default", fullName);
        }
    }
}
