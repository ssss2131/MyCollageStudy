using Furion.Core.CommanClass;
using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Core.Model
{
    public class FurionPeople: PrivateCommonEntity<int>//IEntity//EntityNotKey//IEntity
    {
        public string? Name { get; set; }
    }
}
