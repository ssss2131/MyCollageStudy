using System.ComponentModel.DataAnnotations;

namespace Cache.Data.Models
{
    public class Numbers
    {
        public Numbers(string url)
        {
            this.Url = url;
        }
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
       
    }
}
