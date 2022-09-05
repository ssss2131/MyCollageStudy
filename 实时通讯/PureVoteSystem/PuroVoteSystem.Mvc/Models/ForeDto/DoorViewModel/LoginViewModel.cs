using System.Security.Cryptography;

namespace PuroVoteSystem.Mvc.Models.DoorViewModel
{
    public class LoginViewModel
    {
        [Display(Name = "账号")]
        [Required]
        //[RegularExpression()]
        public string Account { get; set; }
        [Required]
        [Display(Name = "密码")]
        public string Password { get; set; }

        public bool RemeberMe { get; set; }


    }
}
