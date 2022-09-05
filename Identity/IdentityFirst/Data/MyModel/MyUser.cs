
using Microsoft.AspNetCore.Identity;

namespace IdentityFirst.Data.MyModel
{
    public class MyUser:IdentityUser<string>    
    {
        public string? MySpecificUser { get; set; }
    }
}
