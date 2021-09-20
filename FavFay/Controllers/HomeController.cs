using FavFay.Filter;
using FavFay.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavFay.Controllers
{
    [UserFilter]
    public class HomeController : Controller
    {
       
        //varsayılan
        public IActionResult Index()
        {
          

            return View();
        }

        public IActionResult About()
        {
            return View();
        }


        public IActionResult List()
        {
          

           
            return View();
        }

        public IActionResult SuccesPage()
        {

            return View();
        }
    }
}
