using FavFay.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavFay.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Context _context;
        public EmployeeController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/Home/Index");
            }
            return View();
         
        }

        public IActionResult List()
        {
            var filmListesi = new List<Movie>()
            {
                new Movie {Title = "Esaretin Bedeli", Description = "Aciklama 1", Director="Yonetmen 1", Players= new string[] {"oyuncu 1","oyuncu 2"},ImgURL="1.png",mainContent="A man with short-term memory loss attempts to track down his wife's murderer.",movieId=1},
                new Movie {Title = "Film 2", Description = "Aciklama 2", Director="Yonetmen 2", Players= new string[] {"oyuncu 3","oyuncu 4"},ImgURL="2.png",mainContent="A man with short-term memory loss attempts to track down his wife's murderer.",movieId=2},
                new Movie {Title = "Film 3", Description = "Aciklama 3", Director="Yonetmen 3", Players= new string[] {"oyuncu 5","oyuncu 6"},ImgURL="3.png",mainContent="A man with short-term memory loss attempts to track down his wife's murderer.",movieId=3}
            };
            return View(filmListesi);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        public IActionResult DeleteEmployee()
        {
            return View();
        }




    }
}
