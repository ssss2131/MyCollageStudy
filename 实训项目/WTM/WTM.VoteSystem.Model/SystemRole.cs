using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WalkingTec.Mvvm.Core
{
    public class SystemRole: TopBasePoco
    {
        [Key]
        [Display(Name ="角色编号")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public new int ID { get; set; }
        [Required]
        [Display(Name ="角色名")]
        public string RoleName { get; set; }
        public List<SystemUser> SystemUsers { get; set; }


    }
}
