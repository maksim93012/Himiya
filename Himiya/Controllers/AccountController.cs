using Himiya.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Himiya.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string login, string password)
        {
            if (login == null) throw new Exception();
                User user = null;
                using(HimiyaDbContext db = new HimiyaDbContext())
                {
                user = db.Users.FirstOrDefault(u => u.Login == login);

                if (user != null && user.Password == password)
                {
                    FormsAuthentication.SetAuthCookie(user.Login, true);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Невірний логін або пароль");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Testing");
        }
    }
}