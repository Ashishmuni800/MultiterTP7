using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Data;

namespace DataAccessLayer
{
    public class EmployeeDataAccessDb
    {
        private DbConnection db = new DbConnection();

        public List<Employee> GetEmployees()
        {
            string query = "select * from employees";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = query;
            sqlCommand.Connection = db.cnn;
            if (db.cnn.State == System.Data.ConnectionState.Closed)
                db.cnn.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (sqlDataReader.Read())
            {
                Employee emp = new Employee();
                emp.Id = (int)sqlDataReader["Id"];
                emp.Name = sqlDataReader["Name"].ToString();
                emp.Email = sqlDataReader["Email"].ToString();
                emp.Mobile = sqlDataReader["Mobile"].ToString();
                emp.Address = sqlDataReader["Address"].ToString();
                emp.Gender = sqlDataReader["Gender"].ToString();
                employees.Add(emp);
            }
            db.cnn.Close();
            return employees;
        }

        public Employee GetEmployeesById(int id)
        {
            string query = "select * from employees where Id="+id+"";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = query;
            sqlCommand.Connection = db.cnn;
            if (db.cnn.State == System.Data.ConnectionState.Closed)
                db.cnn.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Read();

                Employee emp = new Employee();
                emp.Id = (int)sqlDataReader["Id"];
                emp.Name = sqlDataReader["Name"].ToString();
                emp.Email = sqlDataReader["Email"].ToString();
                emp.Mobile = sqlDataReader["Mobile"].ToString();
                emp.Address = sqlDataReader["Address"].ToString();
                emp.Gender = sqlDataReader["Gender"].ToString();
                
            
            db.cnn.Close();
            return emp;
        }

        public bool CreateEmployee(Employee employee)
        {
            string query = "insert into Employee values(" + employee.Name+"','"+employee.Email+"','"+employee.Mobile+"','"+employee.Address+"','"+employee.Gender+")";
            SqlCommand cmd = new SqlCommand(query, db.cnn);
            if (db.cnn.State == System.Data.ConnectionState.Closed)
                db.cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.cnn.Close();
            return Convert.ToBoolean(i);
        }

        public bool DeleteEmployee(int id)
        {
            string query = "delete from Employee where id=" + id+"";
            SqlCommand cmd = new SqlCommand(query, db.cnn);
            if (db.cnn.State == System.Data.ConnectionState.Closed)
                db.cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.cnn.Close();
            return Convert.ToBoolean(i);
        }

        public bool UpdateEmployee(Employee employee)
        {
            string query = "update Employee set Name=" + employee.Name + ", Email=" + employee.Email + ",Mobile=" + employee.Mobile + ", Address=" + employee.Address + ",Gender=" + employee.Gender +" where Id="+employee.Id+"";
            SqlCommand cmd = new SqlCommand(query, db.cnn);
            if (db.cnn.State == System.Data.ConnectionState.Closed)
                db.cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.cnn.Close();
            return Convert.ToBoolean(i);
        }
    }
}
