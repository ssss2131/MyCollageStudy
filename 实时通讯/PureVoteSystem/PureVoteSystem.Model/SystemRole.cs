using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureVoteSystem.Model
{
    public class SystemRole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        public List<SystemUser> SystemUsers { get; set; }


    }
}
