using EfRelation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfRelation.RelationApi
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.StudentName).HasColumnType("varchar").HasColumnName("学生姓名");
            builder.Property(c => c.JoinDay).HasColumnType("Date").HasColumnName("入学时间");
            builder.HasOne(c => c.Teacher).WithMany(c => c.Students).IsRequired();
            builder.HasIndex(c => c.JoinDay);
            
        }
    }
}
