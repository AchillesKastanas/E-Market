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
            try
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
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                Console.WriteLine(e);
                return View("Index");
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
            try
            {
                if (ModelState.IsValid)
                {
                    using (emarketEntities db = new emarketEntities())
                    {
                        // Check if the email used already exists in the DB
                        var query = db.users.FirstOrDefault(
                            usr => usr.email.Equals(Reguser.Email)
                        );
                        if (query != null) //If the email exists in the db
                        {
                            ViewBag.MyString = "User already exists!";
                            return View("Register");
                        }
                        else
                        {
                            // if the provided email is not in the db,
                            // make a db user object pass the provided values to it
                            // and add it to the database
                            user newUser = new user();
                            newUser.userID = Reguser.UserId;
                            newUser.fName = Reguser.FirstName;
                            newUser.lName = Reguser.LastName;
                            newUser.passwordHash = Reguser.Password;
                            newUser.mobile = Reguser.Phone;
                            newUser.email = Reguser.Email;
                            newUser.isAdmin = Convert.ToByte(Reguser.IsAdmin);
                            newUser.isRegistered = Convert.ToByte(true);
                            newUser.isVendor = Convert.ToByte(Reguser.IsVendor);

                            db.Configuration.ValidateOnSaveEnabled = false;
                            db.users.Add(newUser);
                            db.SaveChanges();
                            Login(Reguser); //since the user registered log him in
                            return RedirectToAction("UserDashBoard");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                Console.WriteLine(e);
                return View("Register");
            }
            return View("Register");
        }
    }
}
