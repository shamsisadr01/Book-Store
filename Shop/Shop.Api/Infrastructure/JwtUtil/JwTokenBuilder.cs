using Microsoft.IdentityModel.Tokens;
using Shop.L1.Domain.User_Aggregate;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Shop.L4.Query.Users.DTOs;

namespace Shop.Api.Infrastructure.JwtUtil
{
	public class JwTokenBuilder
	{
		public static string BuildToken(UserDto user,IConfiguration configuration)
        {
            var roles = user.Roles.Select(s => s.RoleTitle);
            var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
				new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Role,string.Join("-",roles))
            };
			var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SignInKey"]));
			var credential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: configuration["JwtConfig:Issuer"],
				audience: configuration["JwtConfig:Audience"],
				claims: claims,
				expires: DateTime.Now.AddDays(7),
				signingCredentials: credential);

			var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
			return jwtToken;
		}
	}
}
