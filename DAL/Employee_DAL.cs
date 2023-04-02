using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using EmployeeRegisterApp.Models;
using System.Data;

namespace EmployeeRegisterApp.DAL
{
    public class Employee_DAL
    {
        string constring = ConfigurationManager.ConnectionStrings["addConString"].ToString();

        public List<Employee> GetAllEmp()
        {
            List<Employee> employees = new List<Employee>();

            using(SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetAllEmployee";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable allEmp = new DataTable();
                da.Fill(allEmp);
                con.Close();
                foreach(DataRow dr in allEmp.Rows) {
                    employees.Add(new Employee
                    {

                        Emp_Name = dr["Emp_Name"].ToString(),
                        DOB = dr["DOB"].ToString(),
                        Title = dr["Title"].ToString(),
                        Con_Start = dr["Con_Start"].ToString(),
                        Con_End = dr["Con_End"].ToString(),
                        Manager_Name = dr["Manager_Name"].ToString(),
                        Dept_Name = dr["Dept_Name"].ToString()
                    });
                }
            }
            return employees;
        } 

       

        public bool InsertEmployee(Employee emp)
        {
            string ename = emp.Emp_Name + " " + emp.SurName + " " + emp.LastName;
            emp.Emp_Name = ename;
            int id = 0;
            
            DateTime today = DateTime.Now;
            if (emp.Con_Start == null)
            {
                string startdate = DateTime.Now.ToShortDateString();
                emp.Con_Start = startdate;
            }

            if (emp.Con_End == null)
            {
                string enddate = today.AddYears(1).ToShortDateString();
                emp.Con_End = enddate;
            }
            
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertEmp",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empna", emp.Emp_Name);
                cmd.Parameters.AddWithValue("@dob",emp.DOB);
                cmd.Parameters.AddWithValue("@title", emp.Title);
                cmd.Parameters.AddWithValue("@constart", emp.Con_Start);
                cmd.Parameters.AddWithValue("@conend", emp.Con_End);
                cmd.Parameters.AddWithValue("@mname", emp.Manager_Name);
                cmd.Parameters.AddWithValue("@dname", emp.Dept_Name);

                con.Open();
                id = cmd.ExecuteNonQuery();
                con.Close();
                
            }
            if(id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}