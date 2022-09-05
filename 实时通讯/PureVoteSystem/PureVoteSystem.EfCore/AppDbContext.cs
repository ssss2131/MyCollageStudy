using Microsoft.EntityFrameworkCore;
using PureVoteSystem.Model;
namespace PureVoteSystem.EfCore
{
    public class AppDbContext:DbContext
    {
        public DbSet<SystemUser> SystemUser { get; set; }
        public DbSet<SystemActivity> SystemActivity { get; set; }
        public DbSet<SystemCandidateManager> SystemCandidateManager { get; set; }
        public DbSet<SystemRole> SystemRole { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> optoins):base(optoins)
        {

        }
    }
}