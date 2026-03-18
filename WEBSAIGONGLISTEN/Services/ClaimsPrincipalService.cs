using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WEBSAIGONGLISTEN.Models;

namespace WEBSAIGONGLISTEN.Services
{
    public class ClaimsPrincipalService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ClaimsPrincipalService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ClaimsPrincipal> CreateClaimsPrincipalAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            // Thêm FullName vào claims nếu có
            if (!string.IsNullOrEmpty(user.FullName))
            {
                claims.Add(new Claim("FullName", user.FullName));
            }

            // Thêm roles vào claims
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var claimsIdentity = new ClaimsIdentity(claims, IdentityConstants.ApplicationScheme);
            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}


