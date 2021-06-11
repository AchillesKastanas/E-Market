using emarket.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using emarket.Helpers;


namespace emarket.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminPageUsers()
        {
            using (emarketEntities database = new emarketEntities())
            {
                var listData = database.users.ToList().Where(x => x.isAdmin != 1).Select(x => new Users
                {
                    UserId = Convert.ToInt32(x.userID),
                    FirstName = x.fName,
                    LastName = x.lName,
                    Email = x.email,
                    Password = x.passwordHash,
                }).ToList();

                return View(listData);
            }
        }

        public ActionResult AdminPageProducts()
        {
            try
            {
                using (emarketEntities database = new emarketEntities())
                {

                    var listData = database.products.ToList().Select(x => new Product
                    {
                        categoryID = Convert.ToString(x.categoryID),
                        categoryName = database.product_category.FirstOrDefault(y => y.categoryID == x.categoryID).categoryName,
                        productID = Convert.ToString(x.productID),
                        Info = x.productInfo,
                        Price = Convert.ToString(x.price),
                        AvailableQuantity = Convert.ToString(x.availableQTY),
                        sourceOfImage = x.sourceOfImage,
                    }).ToList();
                    return View(listData);
                }
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Index");
            }
            
        }

        public ActionResult DeleteUser(Users user)
        {
            try
            {
                using (emarketEntities database = new emarketEntities())
                {
                    var currentLine = database.users.FirstOrDefault(x => x.userID == user.UserId);
                    database.users.Remove(currentLine);
                    database.SaveChanges();
                    AdminPageUsers();
                    return View("AdminPageUsers");
                }
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Index");
            }
        }

        public ActionResult DeleteProduct(Product product)
        {
            try
            {
                using (emarketEntities database = new emarketEntities())
                {
                    long productID = Convert.ToInt64(product.productID);

                    var currentLine = database.products.FirstOrDefault(x => x.productID == productID);
                    database.products.Remove(currentLine);
                    database.SaveChanges();
                    AdminPageProducts();

                    return View("AdminPageProducts");
                }
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Index");
            }
        }
    }
}