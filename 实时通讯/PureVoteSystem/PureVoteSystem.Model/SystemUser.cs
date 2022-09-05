using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PureVoteSystem.Model
{
    public class SystemUser
    {

        [Key]
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
        public DateTime Birthday { get; set; }
        [Required]
        [EmailAddress]
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
 
     
        public SystemRole Role { get; set; }
 
        public List<SystemCandidateManager> SystemCandidateManagers { get; set; }
       
    }
}
