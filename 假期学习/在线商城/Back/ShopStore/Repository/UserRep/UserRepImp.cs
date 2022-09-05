using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Repository.Base;
using ShopStoreCore.System;
using StoreEfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRep
{
    public class UserRepImp : BaseImp<SystemUser>,IUserRep
    {
        private readonly AppDbContext _Context;

        public UserRepImp(AppDbContext appDbContext) : base(appDbContext)
        {
            _Context = appDbContext;
        }

        public SystemUser? Login(string Email, string Password)
        {
            var user =  _Context.Set<SystemUser>().Where(c => c.Email == Email && c.UserPassword == Password).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            var query = from o in _Context.Set<SystemRole>()
                        where o.Id == user.SysRoleId
                        select new SystemRole { Id = o.Id, Name = o.Name };
        
            user.SystemRole = query.FirstOrDefault();
            return user;
        }





    }
}
