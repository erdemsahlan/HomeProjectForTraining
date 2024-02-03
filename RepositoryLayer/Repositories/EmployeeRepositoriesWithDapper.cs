using CoreLayer.DTOs;
using CoreLayer.Repositories;
using Dapper;


namespace RepositoryLayer.Repositories
{
    public class EmployeeRepositoriesWithDapper : IEmployeeRepoWithDapper
    {
        private readonly ContextForDapper _context;

        public EmployeeRepositoriesWithDapper(ContextForDapper context)
        {
            _context = context;
        }

        public async Task<List<EmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "Select * From Employees";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<EmployeeDto>(query);
                return values.ToList(); 
            };
        }
    }
}
