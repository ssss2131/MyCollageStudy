using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingTec.Mvvm.Core
{
    /// <summary>
    /// 投票管理
    /// </summary>
    public class SystemCandidateManager: TopBasePoco
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        public int SystemUserId { get; set; }
        public int SystemActivityId { get; set; }
        /// <summary>
        /// 总票数
        /// </summary>
        [Required]
        public int CountVote { get; set; }

        public  SystemUser SystemUser { get; set; }
        public SystemActivity SystemActivity { get; set; }
    }
}
