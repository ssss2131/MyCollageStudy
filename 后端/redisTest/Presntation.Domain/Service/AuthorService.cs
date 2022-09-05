using HelloRedis.Domain;
using HelloRedis.RepositoryImp;
using Presntation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Service
{
    public class AuthorService : BaseSerivceImp<Author>, IAuthorService
    {
        public AuthorService(AbsDbcontext context) : base(context)
        {
        }
    }
}
