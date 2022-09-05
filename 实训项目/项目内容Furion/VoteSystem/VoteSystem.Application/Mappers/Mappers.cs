using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteSystem.Application.VoteDto.ActivityDto;
using VoteSystem.Application.VoteDto.ActivityManagerDtos;
using VoteSystem.Application.VoteDto.UserDto;
using VoteSystem.Application.VoteDto.VotersDto;
using VoteSystem.Core.VoteModelCore;
using VoteSystem.Core.VoteModelCore.RootModel;

namespace VoteSystem.Application.Mappers
{
    public class Mappers : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //用户注册
            config.ForType<RegisterViewModel, Admin>()
                .Map(dest => dest.Account, src => src.UserName);
            config.ForType<RegisterViewModel, Candidate>()
                .Map(dest => dest.Account, src => src.UserName);
            config.ForType<RegisterViewModel, Voter>()
                .Map(dest => dest.Account, src => src.UserName);

            //活动注册
            config.ForType<VoteActivityDto, VoteActivity>();

            //活动管理注册
            config.ForType<ActivityManagerDto,ActivityManager>();
            //投票
            config.ForType<VoterDto, ActivityManager>().Map(dest=>dest.VoteActivityId, src=>src.ActivityId)
                .Map(dest=>dest.CandidateId,src=>src.CandidateId);
            config.ForType<VoterDto, VoteManager>().Map(dest => dest.VoterId, src => src.VoterId)
           .Map(dest => dest.CandidateId, src => src.CandidateId);

            #region 用户管理

            config.ForType<UpdateUserDto, Users>();
            #endregion
        }
    }
}
