using Microsoft.AspNetCore.Mvc;


namespace PuroVoteSystem.Mvc.Controllers
{
    public class InitialDbController : Controller
    {
        public IActionResult InitialDb([FromServices]AppDbContext context)
        {
            context.Database.EnsureCreated();
            Initail(context);
            return View();
        }
      
        private void Initail(AppDbContext context)
        {

            var userList = new List<SystemUser>();
         
            for (int i = 0; i < 10; i++)
            {
                userList.Add(
                    new SystemUser
                    {
                        Account = "Account" + i,
                        Birthday = DateTime.Now,
                        Email = "Email@Account" + i + ".com",
                        Password = "password" + i,
                        UserName = "UserName" + i,
                    });          
            }
            var roleList = new List<SystemRole> {
                new SystemRole { RoleName = "普通用户"  },
                new SystemRole { RoleName = "候选人"  },
                new SystemRole { RoleName = "管理员"  }
               };

            var activityList = new List<SystemActivity> {
                new SystemActivity{ WhenStart=DateTime.Now,WhenEnd=DateTime.Now.AddDays(3),WhoSend="Account1",Title="Title",Content="mycontent",Photo="" },
                new SystemActivity{ WhenStart=DateTime.Now,WhenEnd=DateTime.Now.AddDays(3),WhoSend="Account2",Title="Title2",Content="mycontent",Photo="" }
            };

            context.SystemUser.AddRange(userList);
            context.SystemActivity.AddRange(activityList);
            context.SystemRole.AddRange(roleList);
            context.SaveChanges();


        }
    }
}
