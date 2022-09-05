namespace PuroVoteSystem.Mvc.Models.ForeDto.ChangePassword
{
    public class ChangePasswordIndex
    {
        [Required]
        public string Account { get; set; }
        [Required]
        [EmailAddress]
    
        [Remote(action: "VerifyEmail", controller: "Door")]
        public string Email { get; set; }
    }
}
