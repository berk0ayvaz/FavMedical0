using FavFay.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FavFay.Controllers
{
    public class AccountController : Controller
    {
        private readonly Context _context;
        private string code = null;
        public AccountController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/Home/Index");
            }
            return View();

        }

        public IActionResult ForgotPassword()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/Home/Index");
            }
            return View();

        }

        public IActionResult ResetPassword()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/Home/Index");
            }
            return View();

        }

        public IActionResult Login(string email, string pass)
        {
            var kullanici = _context.kullanıcilars.FirstOrDefault(w => w.Email.Equals(email)&& w.Password.Equals(pass));
            if(kullanici != null)
            {
                HttpContext.Session.SetInt32("id",kullanici.UserId);
                HttpContext.Session.SetString("fullname", kullanici.Name + " " + kullanici.SurName);
               return Redirect("/Home/Index");
            }

            return Redirect("Index");
        }
         
        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("Anonymous");
        }

        public async Task<IActionResult> Register(kullanici model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return Redirect("Index");
        }

        public IActionResult Anonymous()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/Home/Index");
            }

            return View();
        }
     

        

       
        public string getCode()
        {
            if (code == null)
            {
                Random rand = new Random();
                code = "";
                for (int i = 0; i < 6; i++)
                {
                    char tmp = Convert.ToChar(rand.Next(48, 58));
                    code += tmp;
                }

            }
            return code;
        }

        public IActionResult SendCode(string email)
        {
            var user = _context.kullanıcilars.FirstOrDefault(w => w.Email.Equals(email));
            if (user != null)
            {
                _context.Add(new PasswordCode { UserId = user.UserId, Code = getCode() });
                _context.SaveChanges();
                string text = "<h1>Sıfırlama için kodunuz:</h1>" + getCode() + " ";
                string subject = "Parola sıfırlama";
                MailMessage msg = new MailMessage("noreplyfavfay@gmail.com", email, subject, text);
                msg.IsBodyHtml = true;
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.UseDefaultCredentials = false;
                NetworkCredential cre = new NetworkCredential("noreplyfavfay@gmail.com", "Favfay123321.");
                sc.Credentials = cre;
                sc.EnableSsl = true;
                sc.Send(msg);
                return Redirect("ResetPassword");

            }
            return Redirect("Index");
        }

        public IActionResult ResetPasswordCode(string code, string newPassword)
        {
            var passwordcode = _context.PasswordCodes.FirstOrDefault(w => w.Code.Equals(code));
            if (passwordcode != null)
            {
                var user = _context.kullanıcilars.Find(passwordcode.UserId);
                user.Password = newPassword;
                _context.Update(user);
                _context.Remove(passwordcode);
                _context.SaveChanges();
                return Redirect("Index");
            }
            return Redirect("Index");

        }




    }
}
