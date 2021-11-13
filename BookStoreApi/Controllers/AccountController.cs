using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApi.Models;
using BookStoreApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignupModel signupModel)
        {
            var result = await _accountRepository.SignUpUserAsync(signupModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized(result.Errors);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> SignIn([FromBody] SignInModel signupModel)
        {
            var result = await _accountRepository.LoginAsync(signupModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized("login error");
            }

            return Ok(result);
        }
    }
}