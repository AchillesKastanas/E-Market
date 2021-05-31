using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emarket.Models;

namespace emarket.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users user)
        {
            if (ModelState.IsValid)
            {
                using (emarketEntities db = new emarketEntities())
                {
                    var obj = db.users.FirstOrDefault(
                        usr => usr.email.Equals(user.Email) &&
                        usr.passwordHash.Equals(user.Password)
                    );
                    if (obj != null)
                    {
                        Session["UserID"] = obj.userID.ToString();
                        Session["email"] = obj.fName.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View("Index");
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}