using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
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
                        Session["email"] = obj.email;
                        Session["UserName"] = obj.fName + " " + obj.lName;
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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult userRegister(Users Reguser)
        {
            if (ModelState.IsValid)
            {
                using (emarketEntities db = new emarketEntities())
                { 
                    // Check if the email used already exists in the DB
                    var obj = db.users.FirstOrDefault(
                        usr => usr.email.Equals(Reguser.Email)
                    );
                    //if (obj != null)
                    //{
                    //    // not ready
                    //    Reguser.FirstName = obj.fName;
                    //    Reguser.LastName = obj.lName;
                    //    Reguser.Email = obj.email;
                    //    Reguser.Password = obj.passwordHash;
                    //    Reguser.FirstName = obj.fName;
                    //    Reguser.FirstName = obj.fName;

                    //    db.users.Add(mod);
                    //}
                }
            }
            return View("Index");
        }
    }
}