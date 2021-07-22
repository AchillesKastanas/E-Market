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
        public ActionResult Payment()
        {
            try
            {
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
                return View("Cart");
            }
        }

        public ActionResult PaymentComplete()
        {
            try
            {
                using (emarketEntities databases = new emarketEntities())
                {
                    bool deleteFromDb = false;
                    List<Product> productsInCart = (List<Product>)Session["cartitem"];
                    foreach (var i in productsInCart)
                    {
                        long prodID = Convert.ToInt64(i.productID);
                        short wantedQuantity = Convert.ToInt16(i.Quantity);
                        (from p in databases.products
                         where p.productID == prodID
                         select p).ToList()
                            .ForEach(x =>
                                x.availableQTY = (short?) (x.availableQTY - wantedQuantity));

                        databases.SaveChanges();
                        deleteFromDb = true;
                    }

                    if (deleteFromDb)
                    {
                        deleteFromDb = false; //reset flag
                        MakeCartSession(); // overwrite the current cart with a new empty one
                        Session["finishCart"] = "Your order has been sent, Thank you for choosing our stores!";
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ViewBag.MyString = "Something went wrong!\nPlease try again..";
                        return RedirectToAction("Cart");
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return RedirectToAction("Cart");
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
                return View("Cart");
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
                return View("Cart");
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
                        case "Dairies":
                            id = 1;
                            ViewBag.Category = "Dairies";
                            break;
                        case "Pasta":
                            id = 2;
                            ViewBag.Category = "Pasta";
                            break;
                        case "Veggies":
                            id = 3;
                            ViewBag.Category = "Veggies";
                            break;
                        case "Fruits":
                            id = 4;
                            ViewBag.Category = "Fruits";
                            break;
                        case "Alcohol Drinks":
                            id = 5;
                            ViewBag.Category = "Alcohol Drinks";
                            break;
                        case "Snacks":
                            id = 6;
                            ViewBag.Category = "Snacks";
                            break;
                    }

                    var listData = database.products.ToList().Where(x => x.categoryID == id).Where(x => x.vendorID == Convert.ToInt64(Session["vendorID"])).Select(x => new Product
                    {
                        productID = Convert.ToString(x.productID),
                        Info = x.productInfo,
                        Price = Convert.ToString(x.price),
                        AvailableQuantity = Convert.ToString(x.availableQTY),
                        sourceOfImage = x.sourceOfImage,
                    }).ToList();
                    return View(Convert.ToString(Session["whichStore"]), listData);
                }
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Cart");
            }
        }

        [HttpPost]
        public ActionResult Shopping(Product prod)
        {
            try
            {
                List<Product> products = (List<Product>)Session["cartitem"]; // Get the list from the session value

                //Check for over availability quantities and 
                // for duplicate quantities
                if (products.Count >= 1) //check only if there are more than 1 items in cart
                {
                    bool CartFLG = true;
                    foreach (var i in products)
                    {
                        //Check if a product is already in the cart
                        if (prod.productID == i.productID || prod.Info == i.Info)
                        {
                            CartFLG = false;
                            if ((Convert.ToInt32(i.Quantity) + Convert.ToInt32(prod.Quantity) <=
                                 Convert.ToInt32(i.AvailableQuantity)))
                            {
                                i.Quantity =
                                    Convert.ToString(Convert.ToInt32(i.Quantity) + Convert.ToInt32(prod.Quantity));
                                ViewBag.AddedString = "The item " + prod.Info + " has been added to the cart";
                                break;
                            }
                            else
                            {
                                ViewBag.MyString = "You exceeded the available quantity!";
                                ViewBag.AddedString = null;
                            }
                        }
                    }
                    if (CartFLG)
                    {
                        products.Add(prod); // add new product to cart
                        ViewBag.AddedString = "The item " + prod.Info + " has been added to the cart";
                    }
                }
                else
                {
                    products.Add(prod); // add new product to cart
                    ViewBag.AddedString = "The item " + prod.Info + " has been added to the cart";
                }


                Session["cartitem"] = products; // and add the new updated value back to the session value

                //Create a List<Product> from the product table in database
                var listData = GetListData();
                return View("Shop1", listData);
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Cart");
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
                var listData = database.products.ToList().Where(x => x.vendorID == Convert.ToInt64(Session["vendorID"])).Select(x => new Product
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
                Session["vendorID"] = 1;
                Session["whichStore"] = "Shop1";
                var listData = GetListData();
                return View(listData);
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Cart");
            }
        }
        public ActionResult Shop2()
        {
            try
            {
                Session["vendorID"] = 2;
                Session["whichStore"] = "Shop2";
                var listData = GetListData();
                return View(listData);
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Cart");
            }
        }
        public ActionResult Shop3()
        {
            try
            {
                Session["vendorID"] = 3;
                Session["whichStore"] = "Shop3";
                var listData = GetListData();
                return View(listData);
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Cart");
            }
        }
        public ActionResult Shop4()
        {
            try
            {
                Session["vendorID"] = 4;
                Session["whichStore"] = "Shop4";
                var listData = GetListData();
                return View(listData);
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Cart");
            }
        }
        public ActionResult Shop5()
        {
            try
            {
                Session["vendorID"] = 5;
                Session["whichStore"] = "Shop5";
                var listData = GetListData();
                return View(listData);
            }
            catch (Exception e)
            {
                ViewBag.MyString = "Something went wrong!\nPlease try again..";
                ErrorCatcher.ErrorCatch(e);
                return View("Cart");
            }
        }
    }
}