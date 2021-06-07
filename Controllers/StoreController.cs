using emarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace emarket.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult View1()
        {
            return View();
        }
        public ActionResult Shop1()
        {
            using(emarketEntities database = new emarketEntities())
            {
                //Create a List<Product> from the product table in database
                var listdata = database.products.ToList().Select(x => new Product
                {
                    productID = Convert.ToString(x.productID),
                    Info = x.productInfo,
                    Price = Convert.ToString(x.price),
                    AvailableQuantity = Convert.ToString(x.availableQTY),
                    sourceOfImage = x.sourceOfImage
                    }).ToList();
            return View(listdata);
            }
        }

        public ActionResult Shopping(Product product)
        {
            ViewBag.AddedString = "The item " + product.Info + " is added to the cart";
            using (emarketEntities database = new emarketEntities())
            {

                //ADD ITEM TO CART - STILL IN PROGRESS
                //database.cart_item.Add(product);


                //Create a List<Product> from the product table in database
                var listdata = database.products.ToList().Select(x => new Product
                {
                    productID = Convert.ToString(x.productID),
                    Info = x.productInfo,
                    Price = Convert.ToString(x.price),
                    AvailableQuantity = Convert.ToString(x.availableQTY),
                    sourceOfImage = x.sourceOfImage
                }).ToList();
                return View("Shop1",listdata);
            }
            
        }

        //public ActionResult Shopping(Product product)
        //{
        //    ViewBag.Message = "The item is added to the cart";
        //    using(emarketEntities database = new emarketEntities())
        //    {
        //        database.cart_item.Add(product);
        //    }
        //}
        public ActionResult Shop2()
        {
            using (emarketEntities database = new emarketEntities())
            {
                var listdata = database.products.ToList().Select(x => new Product
                {
                    Info = x.productInfo,
                    Price = Convert.ToString(x.price),
                    AvailableQuantity = Convert.ToString(x.availableQTY),
                    sourceOfImage = x.sourceOfImage
                }).ToList();
                return View(listdata);
            }
        }
        public ActionResult Shop3()
        {
            using (emarketEntities database = new emarketEntities())
            {
                var listdata = database.products.ToList().Select(x => new Product
                {
                    Info = x.productInfo,
                    Price = Convert.ToString(x.price),
                    AvailableQuantity = Convert.ToString(x.availableQTY),
                    sourceOfImage = x.sourceOfImage
                }).ToList();
                return View(listdata);
            }
        }
        public ActionResult Shop4()
        {
            using (emarketEntities database = new emarketEntities())
            {
                var listdata = database.products.ToList().Select(x => new Product
                {
                    Info = x.productInfo,
                    Price = Convert.ToString(x.price),
                    AvailableQuantity = Convert.ToString(x.availableQTY),
                    sourceOfImage = x.sourceOfImage
                }).ToList();
                return View(listdata);
            }
        }
        public ActionResult Shop5()
        {
            using (emarketEntities database = new emarketEntities())
            {
                var listdata = database.products.ToList().Select(x => new Product
                {
                    Info = x.productInfo,
                    Price = Convert.ToString(x.price),
                    AvailableQuantity = Convert.ToString(x.availableQTY),
                    sourceOfImage = x.sourceOfImage
                }).ToList();
                return View(listdata);
            }
        }
    }
}