using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FavFay.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string  BirthDay { get; set; }
        public string Photo { get; set; }
    }
}
