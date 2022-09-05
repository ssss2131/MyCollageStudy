
using System.ComponentModel.DataAnnotations;

namespace StoreShare.Dto.Menu
{
    public class MenuAddDto
    {
        public string? MenuName { get; set; }
        public string? Url { get; set; }
        public int? ParentId { get; set; } = null;
    }
}
