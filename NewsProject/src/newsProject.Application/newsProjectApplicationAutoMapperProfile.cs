using AutoMapper;
using newsProject.News;
namespace newsProject;

public class newsProjectApplicationAutoMapperProfile : Profile
{
    public newsProjectApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */     
            CreateMap<New, NewsDto>();   
            CreateMap<CreateUpdateNewsDto,New>();   
    }
}
