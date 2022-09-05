using Furion.Core.Locator;
using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Core.Model
{
    public class TestSqlServer:EntityBase<int, SqlServerDbContextLocator> /*IEntity<SqlServerDbContextLocator>*/
    {
        public int Age { get; set; }
        public DateTime DateTime { get; set; }
        public string? Name { get; set; }
    }
}
