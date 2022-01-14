using Cau1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Cau1.DAL
{
    public class DepartmentDAL : DBConnection
    {
        public List<DepartmentBEL> ReadDepartmentList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SelectAllDepartment", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = cmd.ExecuteReader();
            List<DepartmentBEL> lstArea = new List<DepartmentBEL>();
            while (reader.Read())
            {
                DepartmentBEL area = new DepartmentBEL
                {
                    DepartmentId = reader["IdDepartment"].ToString(),
                    Name = reader["Name"].ToString()
                };
                lstArea.Add(area);
            }
            conn.Close();
            return lstArea;
        }
        public DepartmentBEL ReadDepartment(string idDepartment)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            // SqlCommand cmd = new SqlCommand("select*from Department where IdDepartment = "+"'"+IdDepartment.ToString()+"'", conn); ;
            //lấy dl 
            SqlCommand cmd = new SqlCommand("SelectDepartment", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add("@idDepartment", SqlDbType.NVarChar).Value = idDepartment;
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            DepartmentBEL de = new DepartmentBEL();
            if (reader.HasRows && reader.Read())
            {
                de.DepartmentId = reader["idDepartment"].ToString();
                de.Name = reader["Name"].ToString();
            }
            conn.Close();
            return de;
        }

    }
}
