namespace PuroVoteSystem.Mvc.Models.ActivityDto
{
    /// <summary>
    /// 候选人在比赛中的信息
    /// </summary>
    public class UserInfoViewModel
    {
        [Display(Name = "选手编号")]
        public int UserId { get; set; }

        [Display(Name = "选手姓名")]
        public string UserName { get; set; }
        [Display(Name ="活动编号")]
        public int ActivityId { get; set; }
        [Display(Name = "活动标题")]
        public string ActivityName { get; set; }
    }
}
