using JwtServer.EfCore;
using JwtServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly AppDbContext m_context;
        private readonly IOptions<Audience> m_options;
        private static bool m_Init = false;
        public AuthorizeController(AppDbContext context,IOptions<Audience> options)
        {
            m_context = context;
            m_options = options;
            if (!m_Init)
                init();
        }
        [HttpGet]
        public IActionResult GetToken(string userName,string password)
        {
            var user = m_context.Users.Where(c => c.LoginName == userName && c.Password == password).FirstOrDefault();
            #region 满足条件为你颁发Token 否则 返回一个空的用户
            
            if (user != null)
            {
                //生成Token所需要的原料
                var now = DateTime.UtcNow;
                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti ,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub,userName),
                    new Claim(JwtRegisteredClaimNames.Iat,now.ToUniversalTime().ToString(),ClaimValueTypes.Integer64),
                    new Claim("my","my")
                };
                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(m_options.Value.Secret));
                //在原料中所必须的条件---需要被验证的事物
                var validationParameter = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = m_options.Value.Iss,

                    ValidateAudience = true,
                    ValidAudience = m_options.Value.Aud,

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
                var responseJson = new
                {
                    access_token = encodeToken,
                    expires_in = (int)TimeSpan.FromSeconds(2).TotalSeconds
                };
                return new JsonResult(responseJson);

            }
            #endregion


            return new JsonResult(new User());
        }


        private void  init()
        {
            User user = new User
            {
                Id = 1,
                LoginName = "admin",
                Password = "123456"
            };
            m_context.Users.Add(user);
            m_context.SaveChanges();
            m_Init = true;
        }
    }
}
