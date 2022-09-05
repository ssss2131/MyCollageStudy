namespace PuroVoteSystem.Mvc.Models.BackDto.ActivityManage
{
    public class ActivityEditDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name ="活动标题")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "活动内容")]
        public string Content { get; set; }
        /// <summary>
        /// 每个人允许的票数
        /// </summary>
        [Display(Name = "活动票数")]
        public int EachVoteNumber { get; set; } = 1;
        /// <summary>
        /// 活动图片 地址
        /// </summary>
        [Display(Name = "活动图片")]
        public string Photo { get; set; }
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
    }
}
