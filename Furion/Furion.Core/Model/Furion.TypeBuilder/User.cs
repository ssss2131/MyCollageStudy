

using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furion.Core.Model.Furion.TypeBuilder
{
    public class User : Entity,IEntityTypeBuilder<User>
    {
        public string? Name { get; set; }
        public void Configure(EntityTypeBuilder<User> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(c => c.Id);
            entityBuilder.HasIndex(c => c.Name);
        }
    }
}
