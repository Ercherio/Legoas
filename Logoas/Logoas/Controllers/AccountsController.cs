using Legoas.Base;
using Legoas.Repository.Data;
using Legoas.Models;
using Legoas.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Logoas.ViewModel;
using Legoas.Repository.Interface;

namespace Legoas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;
        public IConfiguration configuration;
        public AccountsController(IConfiguration config, AccountRepository repository) : base(repository)
        {
            this.accountRepository = repository;
            this.configuration = config;
        }

        [HttpPost("/Register")]
        public async Task<ActionResult> Register(RegistrasiVM registerVM)
        {
            try
            {
                var result = accountRepository.Register(registerVM);
                if (result == null)
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Message = "Failed to Create a New Data."
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Succeed to Create a New Data.",
                        Data = result
                    });
                }
            }
            catch
            {
                return BadRequest(new
                {
                    StatusCode = 500,
                    Message = "Something Wrong. Please Try Again."
                });
            }
        }

        [HttpPost("Login")]

        public ActionResult Login(LoginVM loginVM)
        {
            string Email = accountRepository.CheckEmail(loginVM.Email);
            if (string.IsNullOrEmpty(Email))
            {
                return NotFound(new JWTokenVM { Token = null, Messages = "Email not found"});
            }
            else if (accountRepository.CheckPassword(Email, loginVM.Password))
            {
                string[] roles = accountRepository.GetRole(Email);
                var claims = new List<Claim>
                {
                    new Claim("email", loginVM.Email)
                };
                foreach (string role in roles)
                {
                    claims.Add(new Claim("roles", role));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                return Ok(new JWTokenVM { Token = new JwtSecurityTokenHandler().WriteToken(token), Messages = "Login success"});
            }
            else
            {
                return Ok(new JWTokenVM { Token = null, Messages = "Wrong password"});
            }
        }
    }
}
