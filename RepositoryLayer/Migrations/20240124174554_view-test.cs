using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class viewtest : Migration
    {
        /// <inheritdoc />

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE VIEW View_1 as 
         SELECT        dbo.Employees.Id
                      , dbo.Employees.Name
                     , dbo.Employees.Surname
                     , dbo.Employees.Salary
                     , dbo.Employees.Email
                     , dbo.Employees.Phone
                     , dbo.Employees.JobStartDate
                     , dbo.Departments.Name AS Departments
                     FROM dbo.Departments 
                     INNER JOIN dbo.Employees ON dbo.Departments.Id = dbo.Employees.DepartmentId";
            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW View_1");
        }
    }
}
