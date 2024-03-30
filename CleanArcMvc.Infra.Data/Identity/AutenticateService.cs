using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity
{
    public class AutenticateService : IAutenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AutenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicaitonUser = new ApplicationUser
            {
                Email = email,
                UserName = email,
            };

            var result = await _userManager.CreateAsync(applicaitonUser);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(applicaitonUser, isPersistent: false);
            }

            return result.Succeeded;
        }
    }
}
