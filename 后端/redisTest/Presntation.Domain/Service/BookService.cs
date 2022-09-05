using HelloRedis.Domain;
using HelloRedis.Repository;
using HelloRedis.RepositoryImp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presntation.Domain.Service
{
    public class BookService : BaseSerivceImp<Book>, IBookService
    {
        public BookService(AbsDbcontext context) : base(context)
        {
        }
    }
}
