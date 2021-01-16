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
                return this.Ok(new { success = true, Message = "Data Added successfully", Data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Data is Not Added Succesfully " });
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
        [Route("api/deleteRecord/{id}/")]
        public IActionResult DeletePersonalDetails([FromRoute]int id)
        {
            var result = this.repository.DeleteEmployee(id);
            if (result.Equals("Employee Deleted"))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Updates the personal details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/updateRecord")]
        public IActionResult Edit(int id)
        {
            try
            {
                IEnumerable<EmployeeModel> employeeList = this.repository.GetEmployeeBy_ID(id);
                return this.Ok(employeeList);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }


    }
}