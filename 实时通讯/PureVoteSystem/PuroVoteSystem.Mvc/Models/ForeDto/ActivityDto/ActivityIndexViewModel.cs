namespace PuroVoteSystem.Mvc.Models.ActivityDto
{
    public class ActivityIndexViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name ="标题")]
        public string Title { get; set; }
        /// <summary>
        /// 活动图片 地址
        /// </summary>
        [Display(Name ="活动内容")]
         public string Content { get; set; }
        public string Photo { get; set; }
        [Display(Name ="发起人")]
        public string WhoSend { get; set; }
        [Display(Name = "活动开始时间")]
        [Required]
        public DateTime WhenStart { get; set; }
        [Display(Name = "活动结束时间")]
        [Required]
        public DateTime WhenEnd { get; set; }

        private bool isShow;
        /// <summary>
        /// 是否展示
        /// </summary>
        public bool IsShow
        {
            get { return Counte(DateTime.Now, this.WhenEnd); }
            private set { isShow = value; }
        }


        private bool Counte(DateTime from, DateTime to)
        {
            var res = (int)(to - from).TotalSeconds;
             
            return res>0?true:false;
        }
    }
}
