using PureVoteSystemWebApi.Dto;
using PuroVoteSystem.Mvc.Models.BackDto.ActivityManage;
using PuroVoteSystem.Mvc.Models.DoorViewModel;

namespace PureVoteSystemWebApi
{
    public class AutoMapper:Profile
    {      
        public AutoMapper()
        {
            CreateMap<RegisterViewModel, SystemUser>();

            CreateMap<SystemActivity, ActivityIndexViewModel>();

            CreateMap<ActivityAddDto, SystemActivity>();

            CreateMap<SystemUserDto, SystemUser>();
        }
       
    }
}
