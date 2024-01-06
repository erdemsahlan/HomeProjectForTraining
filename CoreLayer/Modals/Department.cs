using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Modals
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }


        public ICollection<Employee> Employees { get; set; }
    }
}
