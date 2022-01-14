using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cau1.Model
{
    public class EmployeeBEL
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime EmployeeDateBirth { get; set; }
        public bool EmployeeGender { get; set; }
        public string EmployeePlaceBirth { get; set; }
        public DepartmentBEL Department { get; set; }
        public string NameDepartment { get { return Department.Name; } }
    }
}
