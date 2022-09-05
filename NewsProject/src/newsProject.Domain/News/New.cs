using System.Security.AccessControl;
using System;
using Volo.Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

using System.ComponentModel.DataAnnotations.Schema;

namespace newsProject.News;

public enum Catagory
{
    游戏,学习,体育,健身,探索,音乐,新闻,焦点,关注
}
public class New:Entity<int>
{  
    [Column("title",TypeName = "varchar(255)")]   
     
    public string Title { get; set; }
    
    [Column("stitle",TypeName = "varchar(255)")]
    
    public string STitle { get; set; }
    [Column("data",TypeName = "longtext")]

    public string Data { get; set; }
    [Column("category",TypeName = "varchar(255)")]

    public string Category { get; set; }
    [Column("clickNum",TypeName = "int(11)")]
    public int? ClickNum { get; set; }
   
    [Column("dateTime",TypeName = "Date")]
    public DateTime? DateTime { get; set; }     

}