using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureVoteSystem.Model
{
    /// <summary>
    /// 投票管理
    /// </summary>
    public class SystemCandidateManager
    {
        [Key]
        public int Id { get; set; }

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
