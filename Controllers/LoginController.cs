using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TravelDesk.Data;
using TravelDesk.Models;
using TravelDesk.ViewModel;


namespace TravekDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TravelDeskContext _context;
        private readonly IConfiguration _configuration;

    

    public LoginController(TravelDeskContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;

    }
    [HttpPost]
    public IActionResult Login(LoginModel loginModel)
    {
        IActionResult response = Unauthorized();

        // Authenticate the user
        var user = Authenticate(loginModel);

        if (user == null)
        {
            return Unauthorized("Invalid email or password.");
        }

        // Retrieve the role from Role table based on RoleId
        var role = _context.Roles.FirstOrDefault(x => x.RoleId == user.RoleId);

        if (role == null)
        {
            return Unauthorized("Role not found.");
        }

        loginModel.RoleName = role.RoleName;

        // Generate JWT token
        var tokenString = GenerateJSONWebToken(user.UserId, user.Email, loginModel.RoleName);
        response = Ok(new
        {
            token = tokenString,
            employeeId = user.UserId,//for employee Autofill
            firstName = user.FirstName,
            lastName = user.LastName,
            department = user.Department,
            roleName = loginModel.RoleName,
            roleId= user.RoleId
        });

        return response;
    }

    private string GenerateJSONWebToken(int id, string email, string roleName)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sid, id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(ClaimTypes.Role, roleName),
            new Claim("Date", DateTime.Now.ToString())
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private User Authenticate(LoginModel loginModel)
    {
        return _context.Users.FirstOrDefault(x => x.Email == loginModel.Email && x.Password == loginModel.Password);
    }
}
}
