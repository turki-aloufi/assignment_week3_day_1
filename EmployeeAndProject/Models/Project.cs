﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAndProject.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }  
        public DateTime ProjectDeadline { get; set; }  
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
