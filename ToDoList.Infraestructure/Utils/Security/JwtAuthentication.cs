
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Encodings;
using ToDoList.Model.MyModels;
using ToDoList.Model.Security;

namespace ToDoList.Infraestructure.Utils.Security
{
    public class JwtAuthentication: IJwtAuthentication
    {
        private IConfiguration _configuration;
        public JwtAuthentication(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJSONWebToken(User userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Identification),
                new Claim("FullName", $"{userInfo.FirstName} {userInfo.LastName}")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(60);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
