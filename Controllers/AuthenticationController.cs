using ChallengeDisney.Entities;
using ChallengeDisney.ViewModels.Auth.Login;
using ChallengeDisney.ViewModels.Auth.Register;
using Jose;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace ChallengeDisney.Controllers
{
    [ApiController]
    [Route("Api/[controller]") ]
    public class AuthenticationController : ControllerBase
    {

        


        private readonly UserManager<User> _userManager;
        private readonly JwtOptions _options;
        
        public AuthenticationController(UserManager<User> userManager,
            IOptions<JwtOptions> options)
        {
            _userManager = userManager;
            _options = options.Value;

        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if(userExists != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var user = new User
            {
                Email = model.Email,
                UserName = model.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        Status = "Error",
                        message = $"Creacion de usuario fallo! Error: {string.Join(',', result.Errors.Select(X => X.Description))}"
                    }); 
            }

            return Ok(new
            {
                Status = "Success",
                message = "User creado exitosamente"
            }); 
        }

        //[HttpPost]
        //[Route("Login")]
        //public async Task<IActionResult> login([FromBody] LoginModel model)
        ////{
        //    var user = await _userManager.FindByNameAsync(model.Username);
        //    if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password)) return Unauthorized();

        //    var userRoles = await _userManager.GetRolesAsync(user);
        //    var authClaims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, user.UserName),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //    };

        //    authClaims.AddRange(userRoles.Select(userRoles => new Claim(ClaimTypes.Role, userRoles)));

        //  //  var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["EstaesunapruebadeToken"));
        //    var token = new JwtSecurityToken(
        //       // issuer: _options.ValidIssuer,
        //      //  audience: _options.ValidAudience,
        //        expires: DateTime.Now.AddHours(3),
        //        claims: authClaims,
        //        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        //        );

        //    return Ok(new { 
        //    token = new JwtSecurityTokenHandler().WriteToken(token),
        //    Exception = token.ValidTo
        //    });
        //}


    }
}

