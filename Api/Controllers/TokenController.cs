using Data.Context;
using Data.DomainClass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly DonutOkitaContext _context;

        public TokenController(IConfiguration configuration, DonutOkitaContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(NhanVien nhanVien)
        {
            var user = await _context.NhanVien.FirstOrDefaultAsync(c => c.Sdt == nhanVien.Sdt && c.MatKhau == nhanVien.MatKhau);
            if (user != null)
            {
                var claims = new[]
                    {
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("FirstName", user.Ten),
                        new Claim("Subname", user.TenDem),
                        new Claim("Lastname", user.Ho),
                    };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: signIn);
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
