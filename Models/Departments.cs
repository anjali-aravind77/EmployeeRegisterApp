using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeRegisterApp.Models
{
    public class Departments
    {
        [Key]
        public int Id { get; set; }
        public string DeptName { get; set; }
    }
}