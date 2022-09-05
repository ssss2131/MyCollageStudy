using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Application.VoteDto.ActivityDto
{
    public class QueryVoteActivityPageDto
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }//负责人的姓名     
        public ActivityCatagory Catagory { get; set; }//类别
        public int EachInvoteNumber { get; set; }//每个人的票数限制
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime WhenStart { get; set; }
        public DateTime WhenEnd { get; set; }

    }
}
