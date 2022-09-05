

using VoteSystem.Application.VoteDto.ActivityDto;
using VoteSystem.Application.VoteDto.ActivityManagerDtos;
using VoteSystem.Core.VoteModelCore;

namespace VoteSystem.Application.UserInfoService.CandidateService.IService
{
 
    public interface ICandidateService
    {
        #region 并分页 查询
        /// <summary>
        /// 通过账号查询候选人信息 并分页
        /// </summary>
        /// <param name="Account">查询条件</param>
        /// <param name="size">页面大小</param>
        /// <param name="index">查询的是第几页</param> 
        /// <returns>指定条数的候选人</returns>
        Task<PagedList<Candidate>> QueryByAccountAsync(string Account,int size,int index);
        /// <summary>
        /// 通过Name查询候选人信息 并分页
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        Task<PagedList<Candidate>> QueryByNameAsync(string Name, int size, int index);

        /// <summary>
        /// 通过活动查询候选人
        /// </summary>
        /// <param name="ActivityId"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<PagedList<Candidate>> QueryByActivityAsync(int ActivityId,string name, int size, int index);
        #endregion
        /// <summary>
        /// 参加活动
        /// </summary>
        /// <param name="voteActivityDto"></param>
        /// <returns></returns>
        Task<ActivityManager> JoinAVoteActivity(ActivityManagerDto voteActivityDto);

        Task<PagedList<Candidate>> PageCandidate(int size, int index);


    }
}
