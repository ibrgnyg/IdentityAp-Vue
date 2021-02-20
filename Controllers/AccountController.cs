using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IdentityApıV.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IdentityApıV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _sigInManager;
        private IConfiguration _configration;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager ,IConfiguration configuration)
        {
            _userManager = userManager;
            _sigInManager = signInManager;
            _configration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        //POST:  api/account/register
        public async Task<ActionResult> Register([FromBody]RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    Email = model.Email,
                    UserName = model.UserName

                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                    return Ok(result);
                }
                else
                {
                    return BadRequest(new { message = "email addres already been used  plase another try email addres !" });
                }
            }
            return Ok(model);
        }
        [HttpPost]
        [Route("Login")]
        //POST:  api/account/login
        public async Task<ActionResult> Login([FromBody]Login login)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(login.Email);
                if (user != null)
                {
                    var result = await _sigInManager.PasswordSignInAsync(user, login.Password, true, false);
                    if (result.Succeeded)
                    {
                        var handler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes(_configration["Secret"]);
                        var token = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[] {
                                 new Claim(ClaimTypes.Name, "user", user.Id.ToString())
                            }),
                            Expires = DateTime.UtcNow.AddDays(1),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var tokenCreate = handler.CreateToken(token);
                        login.Token = handler.WriteToken(tokenCreate);
                        return Ok(login);
                    }
                    else
                    {
                        return BadRequest(new { message= "Incorrect email or password!" });
                    }
                }

            }
           
            return Ok(login);
        }

        [HttpPost,Route("forgot")]
        public async Task<ActionResult> ForgotPassword([FromBody] Forgot forgot)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(forgot.Email);
                if(user == null)
                {
                    return BadRequest(new { message = "email is not found!" });
                }

            }
            return Ok(forgot);
        }
  

        [HttpGet]
        [Route("list")]
        [Authorize]
        public IEnumerable<AppUser> Get()
        {
            return _userManager.Users.ToList();
        }
    }
}