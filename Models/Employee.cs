using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeRegisterApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Emp_Name { get; set; }
       
        public string SurName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string Title { get; set; }
        
        public string Con_Start { get; set; }
        
        public string Con_End { get; set; }
        [Required]
        public string Manager_Name { get; set;}
        [Required]
        public string Dept_Name { get; set;}

    }
}