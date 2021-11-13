using System.Threading.Tasks;
using BookStoreApi.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStoreApi.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpUserAsync(SignupModel signupModel);
    }
}