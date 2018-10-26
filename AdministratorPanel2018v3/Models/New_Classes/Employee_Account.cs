using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorPanel2018v3.Models.New_Clases
{
    public class Employee_Account
    {
        public int EmployeeID { get; set; }
        public  int AccountID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Status { get; set; }

        public string Email { get; set; }
    }

    
}