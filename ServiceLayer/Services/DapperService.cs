using CoreLayer.DTOs;
using CoreLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class DapperService
    {
        private readonly IEmployeeRepoWithDapper _dapperRepo;
        
        public async Task<IEnumerable<EmployeeDto>> DapperGetAll()
        {
             return await _dapperRepo.GetAllEmployeeAsync();
        }
}
}
