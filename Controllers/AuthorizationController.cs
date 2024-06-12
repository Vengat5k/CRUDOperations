using AuthorizationAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AuthorizationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : Controller
    {
        AuthorizationRepository _authRepo = new AuthorizationRepository();
        private readonly IConfiguration _configuration;
        public AuthorizationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Post(string Empid)
        {
            if (Empid != null)
            {
                bool isValidUser = _authRepo.IsValidEmployee(Empid);
                if (isValidUser == true)
                {
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                    var Sectoken = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                      _configuration["Jwt:Issuer"],
                      null,
                      expires: DateTime.Now.AddMinutes(5),
                      signingCredentials: credentials);
                    var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
                    return Ok(token);
                }
                else
                {
                    var jsonResponse = new
                    {
                        Result = "Invalid user",
                        Token = ""
                    };
                    return Ok(jsonResponse);
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
