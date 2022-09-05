using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Application.VoteDto.UserDto
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public YourSex YourSex { get; set; }
        //public string Img { get; set; }
        public int Age { get; set; }
        public string Introduce { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
