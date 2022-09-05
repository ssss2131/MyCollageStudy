using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace ShopStoreCore.System
{
    public class SystemUser
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? UserPassword { get; set; }
        public string? Sex { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        [ForeignKey(name: "SystemRole")]
        public int SysRoleId { get; set; }


        public SystemRole? SystemRole { get; set; }
    }
}
