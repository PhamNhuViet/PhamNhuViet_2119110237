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
    public class EmployeeDAL : DBConnection
    {
        public List<EmployeeBEL> ReadEmployee()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SelectAllEmployee", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = cmd.ExecuteReader();
            List<EmployeeBEL> lstep = new List<EmployeeBEL>();
            DepartmentDAL de = new DepartmentDAL();
            while (reader.Read())
            {
                EmployeeBEL ep = new EmployeeBEL();

                ep.EmployeeId = reader["idEmployee"].ToString();
                ep.EmployeeName = reader["Name"].ToString();
                ep.EmployeeDateBirth = (DateTime)reader["DateBirth"];
                int flag = (int)reader["Gender"];
                if (flag == 1)
                {
                    ep.EmployeeGender = true;
                }
                else
                {
                    ep.EmployeeGender = false;
                }
                ep.EmployeePlaceBirth = reader["PlaceBirth"].ToString();
                ep.Department = de.ReadDepartment(reader["idDepartment"].ToString());
                lstep.Add(ep);
            }
            conn.Close();
            return lstep;
        }
        public void EditEmployee(EmployeeBEL ep)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();              
                SqlCommand cmd = new SqlCommand("UpdateEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("@IdEmployee", SqlDbType.NVarChar).Value = ep.EmployeeId;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = ep.EmployeeName;
                cmd.Parameters.Add("@DateBirth", SqlDbType.Date).Value = ep.EmployeeDateBirth;
                cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = ep.EmployeeGender;
                cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = ep.EmployeePlaceBirth;
                cmd.Parameters.Add("@IdDepartment", SqlDbType.VarChar).Value = ep.Department.DepartmentId;
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Sua thanh cong !!!");

            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }
        }
        public void DeleteEmployee(EmployeeBEL ep)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DeleteEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("@IdEmployee", SqlDbType.NVarChar).Value = ep.EmployeeId;
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Xoa thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }
        }
        public void NewEmployee(EmployeeBEL ep)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InsertEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("@IdEmployee", SqlDbType.NVarChar).Value = ep.EmployeeId;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = ep.EmployeeName;
                cmd.Parameters.Add("@DateBirth", SqlDbType.Date).Value = ep.EmployeeDateBirth;
                cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = ep.EmployeeGender;
                cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = ep.EmployeePlaceBirth;
                cmd.Parameters.Add("@IdDepartment", SqlDbType.VarChar).Value = ep.Department.DepartmentId;
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Them thanh cong !!!");


            }
            catch (Exception e)
            {

                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }
        }
    }
}
