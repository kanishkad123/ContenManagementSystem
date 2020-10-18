using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string empName { get; set; } = "";

        public string position { get; set; } = "";

        public string pictureID { get; set; } = "";
    }
}