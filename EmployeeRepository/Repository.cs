using EmployeeModels.Models;

using System.Collections.Generic;
using System.Linq;
using System;

using System.Web.Mvc;

namespace EmployeeRepository
{
    public class Repository : IRepository
    {
        private readonly EmployeeContext employeeContext;
        public Repository(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }
        public string CreateEmployee(EmployeeModel employee)
        {
            employeeContext.EmployeeTB.Add(employee);
            employeeContext.SaveChanges();
            string message = "SUCCESS";
            return message;
        }

        public IEnumerable<EmployeeModel> GetEmployee(string id)
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            employees = employeeContext.EmployeeTB.ToList();
            return employees;
        }

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <param name="Password">The password.</param>
        /// <returns></returns>
        public string LoginToSystem(string Email, string Password)
        {
            //EmployeeModel model = new EmployeeModel();
            var Login = this.employeeContext.EmployeeTB.Where(x => x.Email ==Email && x.Password == Password).SingleOrDefault();
            this.employeeContext.EmployeeTB.Find(Login);
            string message = "LOGIN SUCCESS";
            return message;
        }

        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public string DeleteEmployee(int id)
        {
            EmployeeModel employeeDelete = employeeContext.EmployeeTB.Find(id);
            if (employeeDelete == null)
            {
                return "Not Found.";
            }

            employeeContext.EmployeeTB.Remove(employeeDelete);
            employeeContext.SaveChangesAsync();
            return "Employee Deleted";
        }
    }
}
