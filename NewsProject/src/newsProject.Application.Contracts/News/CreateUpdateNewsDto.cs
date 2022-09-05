using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace newsProject.News;
public enum Catagory
{
    游戏,学习,体育,健身,探索,音乐,新闻,焦点,关注
}
public class CreateUpdateNewsDto
{
    
    [Column("title",TypeName = "varchar(255)")]   
    [Required(ErrorMessage ="标题不合法")]
    public string Title { get; set; }
    
    [Column("stitle",TypeName = "varchar(255)")]
    [Required(ErrorMessage ="小标题不合法")]
    public string STitle { get; set; }

    [Column("data",TypeName = "longtext")]
    [Required(ErrorMessage ="数据不合法")]
    public string Data { get; set; }

    [Column("catagory",TypeName = "varchar(255)")]
    [Required(ErrorMessage ="类别不合法")]
    public Catagory Category { get; set; }

    [Column("clickNum",TypeName = "int(11)")]
    public int ClickNum { get; set; }

    [Column("dateTime",TypeName = "DATE")]
    public DateTime? DateTime { get; set; } 

}