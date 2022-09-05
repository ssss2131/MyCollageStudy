
using AutoMapper;
using Jwt.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository.Base;
using Repository.UserRep;
using ShopStore.FontData.Login;
using ShopStore.tools;
using ShopStoreCore.System;
using StoreShare.Dto.User.Door;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopStore.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoorController : ControllerBase
    {
        private readonly IUserRep _userRep;
        private readonly IMapper _mapper;
        private readonly IOptions<Audience> _options;

        public DoorController(IUserRep userRep,IMapper mapper, IOptions<Audience> options)
        {
            _userRep = userRep;
            _mapper = mapper;
            _options = options;
        }
        [HttpPost]
        public IActionResult Login([FromServices] MyMD5 myMD5,LoginDto loginDto)
        {
            var response = new LoginResponse();
            if (string.IsNullOrEmpty(loginDto.UserPassword)||string.IsNullOrEmpty(loginDto.Email))
            {
                return new JsonResult(response);
            }
            loginDto.UserPassword = myMD5.EncryptPasswordMD5(loginDto.UserPassword);
            var res = _userRep.Login(loginDto.Email, loginDto.UserPassword);           
            if (res == null)
            {
                return new JsonResult(response);
            }
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, res.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, res.SystemRole.Name));
            claims.Add(new Claim(ClaimTypes.Email, res.Email));
            claims.Add(new Claim(ClaimTypes.MobilePhone, res.PhoneNumber));
            claims.Add(new Claim(ClaimTypes.Name, res.UserName));
               

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.Value.Secret));
            var now = DateTime.UtcNow;
            var validationParameter = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _options.Value.Iss,

                ValidateAudience = true,
                ValidAudience = _options.Value.Aud,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true
            };
            var token = new JwtSecurityToken(
                   issuer: validationParameter.ValidIssuer,
                   audience: validationParameter.ValidAudience,
                   claims: claims,
                   notBefore: now,
                   expires: now.Add(TimeSpan.FromMinutes(2)),//jwt令牌过期时间
                   signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)//签名凭证: 安全密钥、签名算法
                   );
            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            response.access_token = "Bearer " + encodeToken;
            response.expires_in = (int)TimeSpan.FromSeconds(120).TotalSeconds;
            response.loginStatus = true;
             
            return new JsonResult(response);
        }
     
        [HttpPost]
        public IActionResult SignUp()
        {
            return Ok();
        }
    }
}
