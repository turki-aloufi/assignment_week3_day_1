using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAndProject.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public decimal BonusAmount { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set;}
    }
}
