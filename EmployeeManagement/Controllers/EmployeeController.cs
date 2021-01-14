using EmployeeManagement.Models;
using EmployeeModels.Models;
using EmployeeRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IRepository repository;
        public EmployeeController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("api/addEmployee")]
        public IActionResult AddEmployee([FromBody] EmployeeModel employee)
        {
            var result = this.repository.CreateEmployee(employee);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Logins to system.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/loginEmployee")]
        public IActionResult Login(string Email, string Password)
        {
            var result = this.repository.LoginToSystem(Email, Password);
            if (result.Equals("LOGIN SUCCESS"))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }


        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/getEmployee")]
        public IActionResult GetEmployees(string id)
        {
            try
            {
                IEnumerable<EmployeeModel> employeeList = this.repository.GetEmployee(id);
                return this.Ok(employeeList);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deletes the personal details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/delete")]
        public IActionResult DeletePersonalDetails(string id)
        {
            var result = this.repository.DeleteEmploye(id);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }
    }
}