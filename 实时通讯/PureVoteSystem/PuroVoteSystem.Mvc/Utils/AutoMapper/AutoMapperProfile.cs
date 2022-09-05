



namespace PuroVoteSystem.Mvc.Utils.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterViewModel, SystemUser>();

            CreateMap<SystemActivity, ActivityIndexViewModel>();

            CreateMap<ActivityAddDto, SystemActivity>();
        }
    }
}
