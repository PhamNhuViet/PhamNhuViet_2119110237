using Cau1.DAL;
using Cau1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.BAL
{
    public class DepartmentBAL
    {
        DepartmentDAL de = new DepartmentDAL();
        public List<DepartmentBEL> ReadDepartmentList()
        {
            List<DepartmentBEL> lstdep = de.ReadDepartmentList();
            return lstdep;
        }
    }
}
