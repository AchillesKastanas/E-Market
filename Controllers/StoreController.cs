using emarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using emarket.Helpers;

namespace emarket.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Payment()
        {
            try{
                double price = 0;
                var payment = new Payment();
                List<Product> productsInCart = (List<Product>)Session["cartitem"];
                foreach (var p in productsInCart)
                {
                    price += Convert.ToDouble(p.Quantity) * Convert.ToDouble(p.Price);
                }
                payment.CartPrice = price;
                payment.TotalPrice = price + 5;

                return View(payment);
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Index");
            }
        }

        public ActionResult RemoveCart(Product product)
        {
            try
            {
                List<Product> products = (List<Product>)Session["cartitem"];

                var productForRemove = products.Find(x => x.productID == product.productID);
                products.Remove(productForRemove);
                Session["cartitem"] = products;
                Cart();
                return View("Cart");
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Index");
            }
        }
        public ActionResult Cart()
        {
            try
            {
                Cart cart = new Cart();
                if (Session["cartitem"] == null)
                {
                    //Check if the user has a cart in his session if not make one
                    MakeCartSession();
                }
                cart.CartID = Convert.ToString(Session["CartID"]);
                List<Product> products = (List<Product>)Session["cartitem"];
                foreach (Product p in products)
                {
                    cart.AddToCart(p);
                }
                return View(cart);
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Index");
            }
        }

        public ActionResult ShopDashBoard(string submitButton)
        {
            try
            {
                using (emarketEntities database = new emarketEntities())
                {
                    long id = 0;
                    switch (submitButton)
                    {
                        case "Diary":
                            id = 1;
                            ViewBag.Category = "Γαλακτοκομικά";
                            break;
                        case "Lunch meat":
                            id = 2;
                            ViewBag.Category = "Αλλαντικά";
                            break;
                        case "Snacks":
                            id = 3;
                            ViewBag.Category = "Snacks";
                            break;
                        case "Vegetables":
                            id = 4;
                            ViewBag.Category = "Λαχανικά";
                            break;
                        case "Fruit":
                            id = 5;
                            ViewBag.Category = "Φρούτα";
                            break;
                    }

                    var listData = database.products.ToList().Where(x => x.categoryID == id).Select(x => new Product
                    {
                        productID = Convert.ToString(x.productID),
                        Info = x.productInfo,
                        Price = Convert.ToString(x.price),
                        AvailableQuantity = Convert.ToString(x.availableQTY),
                        sourceOfImage = x.sourceOfImage,
                    }).ToList();
                    return View("Shop1", listData);
                }
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Shopping(Product prod)
        {
            try
            {
                List<Product> products = (List<Product>)Session["cartitem"]; // Get the list from the session value
                products.Add(prod); // add the new products 
                Session["cartitem"] = products; // and add the new updated value back to the session value
                ViewBag.AddedString = "The item " + prod.Info + " has been added to the cart";

                //Create a List<Product> from the product table in database
                var listData = GetListData();
                return View("Shop1", listData);
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Index");
            }
        }

        public dynamic GetListData()
        {
            using (emarketEntities database = new emarketEntities())
            {
                if (Session["cartitem"] == null)
                {
                    //Check if the user has a cart in his session if not make one
                    MakeCartSession();
                }
                //Create a List<Product> from the product table in database
                var listData = database.products.ToList().Select(x => new Product
                {
                    productID = Convert.ToString(x.productID),
                    Info = x.productInfo,
                    Price = Convert.ToString(x.price),
                    AvailableQuantity = Convert.ToString(x.availableQTY),
                    sourceOfImage = x.sourceOfImage
                }).ToList();
                return listData;
            }
        }

        public void MakeCartSession()
        {
            List<Product> prods = new List<Product>();
            Session["cartitem"] = prods;
        }

        public ActionResult Shop1()
        {
            try
            {
                var listData = GetListData();
                return View(listData);
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Index");
            }
        }
        public ActionResult Shop2()
        {
            try
            {
                var listData = GetListData();
                return View(listData);
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Index");
            }
        }
        public ActionResult Shop3()
        {
            try
            {
                var listData = GetListData();
                return View(listData);
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Index");
            }
        }
        public ActionResult Shop4()
        {
            try
            {
                var listData = GetListData();
                return View(listData);
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Index");
            }
        }
        public ActionResult Shop5()
        {
            try
            {
                var listData = GetListData();
                return View(listData);
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