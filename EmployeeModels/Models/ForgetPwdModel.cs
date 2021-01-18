using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeModels.Models
{
    public class ForgetPwdModel
    {
        [Required(ErrorMessage = "New password required", AllowEmptyStrings = false)]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "New password and confirm password does not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string ResetCode { get; set; }
    }
}
