

using VoteSystem.Application.Utils.UserTools;
using VoteSystem.Core.Enums;

namespace VoteSystem.Application.VoteDto.UserDto
{
    public class RegisterViewModel
    {
        [Required] 
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public YourRoles YourRoles { get; set; }

    }
}
