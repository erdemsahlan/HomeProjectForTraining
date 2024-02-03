using CoreLayer;
using CoreLayer.Modals;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }


        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ViewModal> View_1 { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //configlerin kullanılmasını sağlar ve mevcut assembly da ki hepsini uygular

            modelBuilder
                .Entity<ViewModal>()
                .ToView("View_1")
                .HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
