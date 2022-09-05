using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureVoteSystem.Model
{
    /// <summary>
    /// 投票活动
    /// </summary>
    public class SystemActivity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        /// <summary>
        /// 每个人允许的票数
        /// </summary>
        public int EachVoteNumber { get; set; } = 1;
        /// <summary>
        /// 活动图片 地址
        /// </summary>
        public string Photo { get; set; } = "default.jpg";
        /// <summary>
        /// 活动发起人
        /// </summary>
        [Required]
        public string WhoSend { get; set; }
        [Required]
        public DateTime WhenStart { get; set; }
        [Required]
        public DateTime WhenEnd { get; set; }
 
        public List<SystemCandidateManager> SystemCandidateManagers { get; set; }
    }
}
