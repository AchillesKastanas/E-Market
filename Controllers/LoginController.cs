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
                    var query = db.users.FirstOrDefault(
                        usr => usr.email.Equals(user.Email) &&
                               usr.passwordHash.Equals(user.Password)
                    );
                    if (query != null)
                    {
                        Session["UserID"] = query.userID.ToString();
                        Session["email"] = query.email;
                        Session["UserName"] = query.fName + " " + query.lName;
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
                    var query = db.users.FirstOrDefault(
                        usr => usr.email.Equals(Reguser.Email)
                    );
                    //if (query != null)
                    //{
                    //    // not ready
                    //    Reguser.FirstName = ModelState.;
                    //    Reguser.LastName = query.lName;
                    //    Reguser.Email = query.email;
                    //    Reguser.Password = query.passwordHash;
                    //    Reguser.FirstName = query.fName;
                    //    Reguser.FirstName = query.fName;

                    //    db.users.Add();
                    //}
                }
            }
            return View("Index");
        }
    }
}
