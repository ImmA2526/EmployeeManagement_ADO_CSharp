using EmployeeModels.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepository
{
   public interface IRepository
    {
        public string CreateEmployee(EmployeeModel models);
        public IEnumerable<EmployeeModel> GetEmployee(string id);
        public string LoginToSystem(string Email, string Password);
        public string DeleteEmployee(int id);
        public IEnumerable<EmployeeModel> GetEmployeeBy_ID(int id);
        public string UpdateEmployee(EmployeeModel updateModel);
        public string ResetPassword(string oldpass, string newpass);
    }
}
