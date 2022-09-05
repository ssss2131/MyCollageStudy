

using Microsoft.AspNetCore.Mvc;

namespace PuroVoteSystem.Mvc.Models.DoorViewModel
{
    public class RegisterViewModel
    {
        [Display(Name ="头像")]
        public IFormFile Avator { get; set; }

        [Required]
        [Display(Name = "密码")]
        public string Password { get; set; }
        public int RoleId { get; set; } = 1;
        [Required]
        [Display(Name = "姓名")]
        public string UserName { get; set; }
        [Display(Name = "出生日期")]
        [Required]
        public DateTime Birthday { get; set; }
        [Display(Name = "邮箱")]
        [Required]
        [EmailAddress]
        [Remote(action: "ValidateForEmail", controller: "Validate")]
        public string Email { get; set; }

        private int age;
        public int Age
        {
            get { return GetAgeByBirthdate(this.Birthday); }
            private set { age = value; }
        }
        private int GetAgeByBirthdate(DateTime birthdate)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthdate.Year;
            if (now.Month < birthdate.Month || (now.Month == birthdate.Month && now.Day < birthdate.Day))
            {
                age--;
            }
            return age < 0 ? 0 : age;
        }

 
    }
}
