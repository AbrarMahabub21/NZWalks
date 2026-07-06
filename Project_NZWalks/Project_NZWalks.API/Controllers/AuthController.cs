using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_NZWalks.API.Models.DTO;
using Project_NZWalks.API.Repository;

namespace Project_NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        //User registration
        // A post method
        //api/Auth/register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> UserRegister([FromBody] RegisterRequestDto registerRequestDto)
            {

            var NewIdentity = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var NewUser = await userManager.CreateAsync(NewIdentity, registerRequestDto.Password);

            if (NewUser.Succeeded)
            {
                if(registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    NewUser = await userManager.AddToRolesAsync(NewIdentity, registerRequestDto.Roles);

                    if (NewUser.Succeeded)
                    {
                        return Ok("New user is created successfully!");
                    }
                }
            }

            return BadRequest("Something went wrong!! Please Try again.");
            }


        //User Login
        // A Post Method
        // api/auth/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginDto userLoginDto)
        {
            var User = await userManager.FindByEmailAsync(userLoginDto.Username);

            if(User != null)
            {
                var checkPassword = await userManager.CheckPasswordAsync(User, userLoginDto.Password);
                if (checkPassword)
                {
                    var roles = await userManager.GetRolesAsync(User);
                    if(roles != null)
                    {
                        //Provide a Token
                        var JWTtoken = tokenRepository.CreateJWTToken(User, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            jwttoken = JWTtoken
                        };

                        return Ok(response);
                    }  
                }
            }
            return BadRequest("User not Found! Please provide proper information.");
        }

    }
}
