using EmployeeModels.Models;

using System.Collections.Generic;
using System.Linq;
using System;

using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

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
            var Login = this.employeeContext.EmployeeTB.Where(x => x.Email == Email && x.Password == Password).SingleOrDefault();
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

        /// <summary>
        /// Gets the employee by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IEnumerable<EmployeeModel> GetEmployeeBy_ID(int id)
        {
            List<EmployeeModel> employ = new List<EmployeeModel>();
            employ.Add(employeeContext.EmployeeTB.Find(id));
            return employ;
        }

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns></returns>
        public string UpdateEmployee(EmployeeModel updateModel)
        {
            try
            {
                this.employeeContext.EmployeeTB.Update(updateModel);
                this.employeeContext.SaveChangesAsync();
                return "SUCCESS";
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="oldpass">The oldpass.</param>
        /// <param name="newpass">The newpass.</param>
        /// <returns></returns>
        public string ResetPassword(string oldPass, string newPass)
        {
            var resetPwd = employeeContext.EmployeeTB.FirstOrDefault(pass => pass.Password == oldPass);
            if (resetPwd != null)
            {
                resetPwd.Password = newPass;
                employeeContext.Entry(resetPwd).State = EntityState.Modified;
                employeeContext.SaveChanges();
                return "SUCCESS";
            }
            else
            {
                return "NOT_FOUND";
            }
        }

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="body">The body.</param>
        /// <param name="subject">The subject.</param>
        
        public string SendEmail(string emailAddress)
        {
            string body;
            string subject = "EmployeeManagement Password";
            var dbEntry = employeeContext.EmployeeTB.FirstOrDefault(e => e.Email == emailAddress);
            if (dbEntry != null)
            {
                body = dbEntry.Password;
            }
            else
            {
                return "NOT_FOUND";
            }

            using (MailMessage mailMessage = new MailMessage("imraninfo.1996@gmail.com", emailAddress))
            {
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("imraninfo.1996@gmail.com", "Password****");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
                return "SUCCESS";
            }
        }
    }
}