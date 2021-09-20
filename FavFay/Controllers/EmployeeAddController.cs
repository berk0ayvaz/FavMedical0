using FavFay.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FavFay.Controllers
{


    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeAddController : ControllerBase
    {
 
            private readonly Context _context;

            public EmployeeAddController(Context context)
            {
        
            _context = context;
            }

        [HttpGet]
        public IActionResult GetAllEmployees(Employee employee)
        {
            
            return Redirect("/Home/SuccesPage");
        }

        [HttpGet("{id}")]
        public string GetEmployeeById(int id)
        {
            return "tuna";
        }

        [HttpPost]
        public IActionResult AddNewEmployee([FromForm] Employee model)
        {

            _context.AddAsync(model);
            _context.SaveChangesAsync();



            return Redirect("/Home/SuccesPage");


        }


        [HttpPut("{id}")]
        public void UpdateEmployee()
        {
         
        }

        [HttpDelete]
        public IActionResult DeleteEmployee([FromForm] int id) 
        {
            Employee employee= new Employee() { EmployeeID = id };
            _context.employees.Attach(employee);
            _context.employees.Remove(employee);
            _context.SaveChanges();
            return Redirect("/Home/SuccesPage");
        }
    }

  
}
