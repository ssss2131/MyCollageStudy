using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Dtos;
namespace newsProject.News;

public class NewsDto:EntityDto<int>
{  
    public string Title { get; set; }     
    public string STitle { get; set; } 
    public string Data { get; set; }
    public string Category { get; set; }   
    public int ClickNum { get; set; }

    public DateTime DateTime { get; set; }    
}
