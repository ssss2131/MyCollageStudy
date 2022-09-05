using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRedis.Domain
{
    public class bookmark
    {
        private readonly Dictionary<string, object> _data = new Dictionary<string, object>();
        [Required]
        [Key]
        public int Mark { get; set; }
        public object this[string key]
        {
            get => _data[key];
            set => _data[key] = value;
        }



    }
}
