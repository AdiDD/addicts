using server.DTOs;
using server.Models;
using server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenService _tokenService;

        public AccountController(UserManager<ApplicationUser> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="credentialDto">User Credentials</param>
        /// <returns>Session Token</returns>
        [HttpPost("login")]
        public async Task<ActionResult<UserIdAndTokenDto>> Login(CredentialDto credentialDto)
        {
            var user = await _userManager.FindByEmailAsync(credentialDto.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, credentialDto.Password))
            {
                return Unauthorized();
            }

            return new UserIdAndTokenDto
            {
                UserId = user.Id,
                Token = await _tokenService.GenerateToken(user)
            };
        }

        /// <summary>
        /// Register new User
        /// </summary>
        /// <param name="credentialDto">User Credentials</param>
        /// <returns>Status Message</returns>
        [HttpPost("register")]
        public async Task<ActionResult> Register(CredentialDto credentialDto)
        {
            var user = new ApplicationUser 
            { 
                FirstName = credentialDto.FirstName,
                LastName = credentialDto.LastName,
                UserName = credentialDto.FirstName + credentialDto.LastName,
                Email = credentialDto.Email 
            };

            var result = await _userManager.CreateAsync(user, credentialDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return ValidationProblem();
            }

            await _userManager.AddToRoleAsync(user, "User");
            return StatusCode(201);
        }
    }
}
