using System;
using System.Linq;
using System.Web.Mvc;
using emarket.Helpers;
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
                using (emarketEntities db = new emarketEntities())
                {
                    var query = db.users.FirstOrDefault(
                        usr => usr.email.Equals(user.Email) &&
                               usr.passwordHash.Equals(user.Password)
                );
                    if (query != null)
                    {
                        Session["IsAdmin"] = Convert.ToInt32(query.isAdmin);
                        Session["UserID"] = query.userID.ToString();
                        Session["email"] = query.email;
                        Session["UserName"] = query.fName + " " + query.lName;

                        var query1 = db.carts.FirstOrDefault(usr => usr.userID.Equals(query.userID));
                        if (query1 != null)
                        {
                            Session["CartID"] = query1.cartID;
                        }
                        else
                        {
                            cart cart = new cart
                            {
                                userID = Convert.ToInt64(Session["UserID"])
                            };
                            db.carts.Add(cart);
                            db.SaveChanges();
                            Session["CartID"] = cart.cartID;
                        }

                        if (Session["UserID"] != null && Session["CartID"] != null)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return View("Index");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Index");
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            try
            {
                Session.Clear();
                Session.Abandon();
                return View("Index");
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Index");
            }
        }

        public ActionResult ResetPass()
        {
            //Update Password
            return View("ResetPassword");
        }

        public ActionResult Register()
        {
            return View();
        }


        public ActionResult userRegister(Users Reguser)
        {
            try
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
                        var newUser = new user
                        {
                            fName = Reguser.FirstName,
                            lName = Reguser.LastName,
                            passwordHash = Reguser.Password,
                            mobile = Reguser.Phone,
                            email = Reguser.Email,
                            isAdmin = Convert.ToByte(0),
                            isVendor = Convert.ToByte(0)
                        };

                        cart cart = new cart
                        {
                            userID = Convert.ToInt64(Reguser.UserId)
                        };

                        db.users.Add(newUser);
                        db.carts.Add(cart);
                        db.SaveChanges();
                        Login(Reguser); //since the user registered log him in
                        if (Session["UserID"] != null)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return View("Index");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Register");
            }
        }
    }
}
