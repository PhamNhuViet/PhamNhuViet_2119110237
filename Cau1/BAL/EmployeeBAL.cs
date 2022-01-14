using Cau1.DAL;
using Cau1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.BAL
{
    public class EmployeeBAL
    {
        EmployeeDAL de = new EmployeeDAL();
        public List<EmployeeBEL> ReadEmployee()
        {
            List<EmployeeBEL> lstCus = de.ReadEmployee();
            return lstCus;
        }
        public void NewEmployee(EmployeeBEL emp)
        {
            de.NewEmployee(emp);
        }
        public void DeleteEmployee(EmployeeBEL emp)
        {
            de.DeleteEmployee(emp);
        }
        public void EditEmployee(EmployeeBEL emp)
        {
            de.EditEmployee(emp);
        }

    }
}
