using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreShare.Dto.User
{
    public class UsersDto
    {
        public string? UserName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? UserPassword { get; set; }
        public string? Sex { get; set; }
        public string? Address { get; set; }
  
        public string? PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }= DateTime.Now;
        public int SysRoleId { get; set; }  
    }
}
