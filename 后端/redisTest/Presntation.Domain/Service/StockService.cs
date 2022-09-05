using HelloRedis.Domain;
using HelloRedis.Repository;
using HelloRedis.RepositoryImp;
using Microsoft.EntityFrameworkCore;
using Presntation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Presntation.Domain.Service
{
    public class StockService : BaseSerivceImp<Stock>,IStockService,IRedis
    {
        public StockService(AbsDbcontext context) : base(context)
        {
        }

        public async Task<List<Stock>> GetStokWithBookInfo()
        {

            var query = from o in base.Npgcontext.Set<Stock>().Include(o=>o.Book)                      
                        select o;
            return await query.ToListAsync();
                     
        }
    }
}
