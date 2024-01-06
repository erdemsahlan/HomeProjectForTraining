using CoreLayer.Modals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configuration
{
    internal class EmployeeConfigration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).UseIdentityColumn();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e=>e.Salary).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Department).WithMany(x => x.Employees).HasForeignKey(x=>x.DepartmentId);
        }
    }
}
