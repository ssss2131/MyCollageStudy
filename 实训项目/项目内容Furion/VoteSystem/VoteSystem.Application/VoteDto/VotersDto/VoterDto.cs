
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Application.VoteDto.VotersDto
{
    public class VoterDto
    {   //投票人Id
        public int VoterId { get; set; }
        //候选人Id
        public int CandidateId { get; set; }
        //活动Id
        public int ActivityId { get; set; }
    }
}
