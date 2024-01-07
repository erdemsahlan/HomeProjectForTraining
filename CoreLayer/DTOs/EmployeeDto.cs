using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public DateTime JobStartDate { get; set; }

        public int DepartmentId { get; set; }
    }
}
