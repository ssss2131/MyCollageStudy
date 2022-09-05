using System.ComponentModel.DataAnnotations;

namespace JwtServer.Model
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string? LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string? Password { get; set; }
    }
}
