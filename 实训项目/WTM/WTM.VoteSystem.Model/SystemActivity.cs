using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingTec.Mvvm.Core
{
    /// <summary>
    /// 投票活动
    /// </summary>
    public class SystemActivity: TopBasePoco
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="活动编号")]
        public new int ID { get; set; }
        
        [Required]
        [MaxLength(200)]
        [Display(Name = "活动标题")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "活动内容")]
        public string Content { get; set; }
        /// <summary>
        /// 每个人允许的票数
        /// </summary>
        [Required]
        [Display(Name = "允许票数")]
        public int EachVoteNumber { get; set; } = 1;
        /// <summary>
        /// 活动图片 地址
        /// </summary>
        [Display(Name="活动图片")]
        public Guid? PhotoId { get; set; } 

        public FileAttachment Photo { get; set; }
        /// <summary>
        /// 活动发起人
        /// </summary>
        [Required]
        [Display(Name = "活动发起人")]
        public string WhoSend { get; set; }
        [Required]
        [Display(Name = "活动开始时间")]
        public DateTime WhenStart { get; set; }
        [Required]
        [Display(Name = "活动结束时间")]
        public DateTime WhenEnd { get; set; }
 
        public List<SystemCandidateManager> SystemCandidateManagers { get; set; }
    }
}
