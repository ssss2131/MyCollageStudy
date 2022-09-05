using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using newsProject.News.INewsService;
using Volo.Abp.Domain.Repositories;


namespace newsProject.News.INewsService;

public class NewsServiceImp:CrudAppService<New,NewsDto,int,PagedAndSortedResultRequestDto,CreateUpdateNewsDto>,INewsService

{
    public NewsServiceImp(IRepository<New, int> repository)
                : base(repository)
            {

            }

}