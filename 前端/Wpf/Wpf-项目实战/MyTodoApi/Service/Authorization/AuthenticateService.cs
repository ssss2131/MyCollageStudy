using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyTodo.Shared;
using MyTodo.Shared.Dtos;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyTodoApi.Service.Authorization
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly TokenManagement _tokenManagement;

        public AuthenticateService(IOptions<TokenManagement>   tokenManagement)
        {
            _tokenManagement = tokenManagement.Value;
        }
        public bool IsAuthenticated(ApiResponse<UserDto> response, out string token)
        {
            token = string.Empty;
            if (!response.Status)
            {
                return false;
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.Name ,response.Result.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(_tokenManagement.Issuer, _tokenManagement.Audience, claims,
                expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return true;
        }
    }
}
