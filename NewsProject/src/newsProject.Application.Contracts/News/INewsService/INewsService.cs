using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;


namespace newsProject.News.INewsService;

public interface INewsService:
        ICrudAppService< //Defines CRUD methods
            NewsDto, //Used to show books
            int, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateNewsDto> //Used to create/update a book
{
    
       


}