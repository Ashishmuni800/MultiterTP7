using System;
using System.Collections.Generic;
using CommonLayer.Models;
using DataAccessLayer;

namespace BusinessLayer
{
    public class EmployeeBusiness
    {
        private EmployeeDataAccessDb employeeData;
        public EmployeeBusiness()
        {
            employeeData = new EmployeeDataAccessDb();
        }
        public List<Employee> GetList()
        {
            return employeeData.GetEmployees();
        }

        public Employee GetEmployeeById(int id)
        {
            return employeeData.GetEmployeesById(id);
        }

        public bool DeleteEmployee(int id)
        {
            return employeeData.DeleteEmployee(id);
        }
        public bool CreateEmployee(Employee emp)
        {
            return employeeData.CreateEmployee(emp);
        }
        public bool UpdateEmployee(Employee emp)
        {
            return employeeData.UpdateEmployee(emp);
        }
    }
}
