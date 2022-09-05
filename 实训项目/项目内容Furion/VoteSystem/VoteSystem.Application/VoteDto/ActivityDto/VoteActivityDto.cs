using VoteSystem.Core.Enums;

namespace VoteSystem.Application.VoteDto.ActivityDto
{
    //新增活动Dto
    public class VoteActivityDto
    {
        public int AdminId { get; set; }
        public ActivityCatagory Catagory { get; set; }//类别
        public int EachInvoteNumber { get; set; }//每个人的票数限制
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime WhenStart { get; set; }
        public DateTime WhenEnd { get; set; }
    }
}
