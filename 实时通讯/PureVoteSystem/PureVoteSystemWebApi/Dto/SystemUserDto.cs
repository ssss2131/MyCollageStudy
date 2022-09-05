

using System.ComponentModel.DataAnnotations;

namespace PureVoteSystemWebApi.Dto
{
    public class SystemUserDto
    {
        [Required]
        public string TimeStamp { get; set; }
        [Required]
        public int Id { get; set; }
        public string Photo { get; set; } = "default.jpg";
        [Required]
        public string Account { get; set; }
        [Required]
        public string Password
        {
            get { return password; }
            set { password = passwordHash(value); }
        }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        //[MaxLength(200)]
        //public string Introduce { get; set; }
        public int SystemActivityId { get; set; }
        public int Age { get; set; }

        public int RoleId { get; set; } = 1;


        private string password;
        private string passwordHash(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                var output = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                var text = BitConverter.ToString(output).Replace("-", " ");
                return text;
            }
        }
    }
}
