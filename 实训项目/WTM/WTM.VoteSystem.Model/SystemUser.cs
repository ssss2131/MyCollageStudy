using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WalkingTec.Mvvm.Core
{
    //public enum SysRoleEnum
    //{
    //    [Display(Name ="普通用户")]
    //    NormalUser=1,

    //    [Display(Name = "候选人")]
    //    Candidate =2,

    //    [Display(Name = "管理员")]
    //    Manager = 3
    //}
    public class SystemUser: TopBasePoco
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }  
        public Guid? UserPhotoId { get; set; }  

        public FileAttachment UserPhoto { get; set; }
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

        [ForeignKey("Role")]
        public int RoleId { get; set; } 
       

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
