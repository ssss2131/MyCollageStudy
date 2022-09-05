using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreShare.Dto.Operation
{
    public class OprsAddDto
    {
        [Required]
        public string? OperationName { get; set; }
    }
}
