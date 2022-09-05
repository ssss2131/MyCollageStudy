using Repository.Base;
using ShopStoreCore.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRep
{
    public interface IUserRep:IBase<SystemUser>
    {
        SystemUser Login(string Email, string Password);
    }
}
