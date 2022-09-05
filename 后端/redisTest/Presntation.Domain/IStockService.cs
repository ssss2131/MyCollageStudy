using HelloRedis.Domain;
using HelloRedis.Repository;
using Presntation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presntation.Domain
{
    public interface IStockService:IBaseService<Stock>
    {
        Task<List<Stock>> GetStokWithBookInfo();
    }
}
