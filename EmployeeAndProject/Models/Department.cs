using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAndProject.Models
{
    public class Department
    {
        public int DepId { get; set; }
        public string DepName { get; set; }
        public ICollection<Employee> employees { get; set; }
    }
}
