using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeModels.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long  Zip { get; set; }
       
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string Password { get; set; }
       
    }
}
