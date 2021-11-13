using System.Threading.Tasks;
using BookStoreApi.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStoreApi.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> SignUpUserAsync(SignupModel signupModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = signupModel.FirstName,
                LastName = signupModel.LastName,
                Email = signupModel.Email,
                UserName = signupModel.Email,
            };

           return await _userManager.CreateAsync(user, signupModel.Password);
        }
    }
}