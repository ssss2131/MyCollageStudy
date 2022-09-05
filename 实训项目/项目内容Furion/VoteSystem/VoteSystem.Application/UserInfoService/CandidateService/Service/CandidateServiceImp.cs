using VoteSystem.Application.UserInfoService.CandidateService.IService;
using VoteSystem.Core.VoteModelCore;
using VoteSystem.Core.VoteModelCore.RootModel;
using System.Linq;
using VoteSystem.Application.VoteDto.ActivityDto;
using VoteSystem.Application.VoteDto.ActivityManagerDtos;

namespace VoteSystem.Application.UserInfoService.CandidateService.Service
{
    [DynamicApiController]
    public class CandidateServiceImp : ICandidateService
    {
        private readonly IRepository<Candidate> _repository;
        private readonly IRepository<Activity> _activityRepository;
        private readonly IRepository<ActivityManager> _managerRep;

        public CandidateServiceImp(IRepository<Candidate> repository,IRepository<Activity> activityRepository,IRepository<ActivityManager> managerRep)
        {
            _repository = repository;
            _activityRepository = activityRepository;
            _managerRep = managerRep;
        }
        public async Task<PagedList<Candidate>> QueryByAccountAsync(string Account, int size, int index)
        {
            var entities =  _repository.AsQueryable(c => c.Account.Contains(Account));
          
            return await entities.ToPagedListAsync(index, size);
        }   

        public async Task<PagedList<Candidate>> QueryByNameAsync(string Name, int size, int index)
        {
            var entities = _repository.AsQueryable(c => c.Name.Contains(Name));

            return await entities.ToPagedListAsync(index, size);
        }
        public async Task<PagedList<Candidate>> QueryByActivityAsync(int ActivityId,string name, int size, int index)
        {
            var entities = _managerRep.AsQueryable(c=>c.VoteActivityId==ActivityId).Include(c => c.Candidate);//查询到id==ActivityId的所有项

            IList<Candidate> list = new List<Candidate>();
            foreach (var item in entities)
            {
                if(item.Candidate.Name.Contains(name))
                    list.Add(item.Candidate);
            }
            var query = from o in _managerRep.AsQueryable(c => c.VoteActivityId == ActivityId).Include(c => c.Candidate)
                        select new Candidate
                        {
                            Account = o.Candidate.Account,
                            Age = o.Candidate.Age,
                            Birthday = o.Candidate.Birthday,
                            YourSex = o.Candidate.YourSex,
                            Email = o.Candidate.Email,
                            Img = o.Candidate.Img,
                            Name = o.Candidate.Name,
                            PhoneNumber = o.Candidate.PhoneNumber,
                            Introduce = o.Candidate.Introduce                         
                        };


            return await query.ToPagedListAsync(index, size);
 
        }
        /// <summary>
        /// 竞选人参加竞选活动
        /// </summary>
        /// <param name="managerDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ActivityManager> JoinAVoteActivity(ActivityManagerDto managerDto)
        {
            var candidate = await _repository.FirstAsync(c => c.Id == managerDto.CandidateId);
            var activity = await _activityRepository.FirstOrDefaultAsync(c => c.Id == managerDto.VoteActivityId);
            if (candidate == null || activity == null)
            {
                throw new Exception("活动或者候选人Id有误");
            }
           
            var voteActivity = managerDto.Adapt<ActivityManager>();
            var ress = _managerRep.FirstOrDefault(c => c.CandidateId == managerDto.CandidateId &&
                c.VoteActivityId == managerDto.VoteActivityId);
            if (ress != null)
            {
                throw new Exception("该记录出现重复,禁止重复参加相同活动");
            }
            var res = await _managerRep.InsertAsync(voteActivity);
            return res.Entity;
        }
        /// <summary>
        /// 获取所有候选人信息
        /// </summary>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public async Task<PagedList<Candidate>> PageCandidate(int size, int index)
        {
            return await _repository.AsQueryable().ToPagedListAsync();
         
        }
    }
}
