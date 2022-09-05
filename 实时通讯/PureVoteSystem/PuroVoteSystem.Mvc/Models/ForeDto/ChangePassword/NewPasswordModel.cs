namespace PuroVoteSystem.Mvc.Models.ForeDto.ChangePassword
{
    public class NewPasswordModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="电子邮箱")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "密码一")]
        public string Password1 { get; set; }
        [Required]
        [Display(Name = "密码二")]
        public string Password2 { get; set; }
        [Required]
        [Display(Name = "您的代码Code")]
        public string Code { get; set; }
    }
}
