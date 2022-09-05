using HelloRedis.Domain;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models.ViewModel
{
    public class CreateNewBookViewModel
    {
        [Required]
        public string? BookName { get; set; }

        //public DateTime CreateTime { get; set; }
        [Required]
        public string? Publisher { get; set; }
        [Required]
        public string? ISBN { get; set; }

        [Required]
        public string? AuthorName { get; set; }
        [Required]
        public DateTime BirthTime { get; set; }


        [Required]
        public float Count { get; set; }


    }
}
