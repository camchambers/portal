using Microsoft.AspNetCore.Identity;
using portal.Constants;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace portal.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedSuperAdminAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] adminUsers = {
               "portaladmin@test.com"
            };

            foreach (string adminUser in adminUsers)
            {
                var profile = new IdentityUser
                {
                    UserName = adminUser,
                    Email = adminUser,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };

                if (userManager.Users.All(u => u.Id != profile.Id))
                {
                    var user = await userManager.FindByEmailAsync(profile.Email);
                    if (user == null)
                    {
                        await userManager.CreateAsync(profile, "@dm1nU$erP@ssword");
                        await userManager.AddToRoleAsync(profile, Roles.Member.ToString());
                        await userManager.AddToRoleAsync(profile, Roles.Admin.ToString());
                        await userManager.AddToRoleAsync(profile, Roles.SuperAdmin.ToString());
                    }
                }
            }
        }

        public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsForModule(module);
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                }
            }
        }
    }
}