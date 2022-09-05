using System.Text.Json;
using VoteSystem.Application.UserInfoService.VoterService.IService;
using VoteSystem.Application.VoteDto.ActivityDto;
using VoteSystem.Application.VoteDto.VotersDto;
using VoteSystem.Core.VoteModelCore;

namespace VoteSystem.Application.UserInfoService.VoterService.Service
{
    [DynamicApiController]
    public class VoterServiceImp : IVoterService
    {
        private readonly IRepository<ActivityManager> _activityMRep;
        private readonly IRepository<VoteManager> _voteMRep;
        private readonly IRepository<VoteActivity> _voteARep;
        private readonly IRepository<Activity> _ARep;

        public VoterServiceImp(IRepository<ActivityManager> activityRep,IRepository<VoteManager> voteRep,
            IRepository<VoteActivity> voteARep,IRepository<Activity> ARep)
        {
            _activityMRep = activityRep;
            _voteMRep = voteRep;
            _voteARep = voteARep;
            _ARep = ARep;
        }
        /// <summary>
        /// 用户投票
        /// </summary>
        /// <param name="voterDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> PostAVote(VoterDto voterDto)
        {

            var voteManager = voterDto.Adapt<VoteManager>();

            var activity = await _ARep.FirstOrDefaultAsync(c => c.Id == voterDto.ActivityId);
            //获取规则允许投的票数
            var EachInvoteNumber = _voteARep.FirstOrDefaultAsync(c => c.Id == voterDto.ActivityId).Result.EachInvoteNumber;
            //获取投票的起止事件 当前时间
            var startTime = activity.WhenStart;
            var endTime = activity.WhenEnd;

            var nowTime = DateTime.Now;
            //获取投票管理器中用户已投的票数
            var votedNumber = _voteMRep.AsQueryable(c => c.VoterId == voterDto.VoterId && c.CandidateId == voterDto.CandidateId).Count();
            
            //获取活动管理器中的相关数据
            var res = await _activityMRep.FirstOrDefaultAsync(c => c.Id == voterDto.ActivityId && c.CandidateId == voterDto.CandidateId);

            //票数限制
            //时间限制
            if (EachInvoteNumber > votedNumber&& nowTime<=endTime&&nowTime>=startTime)
            {             
                res.CandidateVoteNumber += 1;
                _activityMRep.Update(res);
                _voteMRep.Insert(voteManager);
                return 1;
            }
            if (!(nowTime <= endTime && nowTime >= startTime))
            {
                throw new Exception("该时间不是规定时间");
            }
            throw new Exception("超过规定投票次数");

 
        }
    }
}
