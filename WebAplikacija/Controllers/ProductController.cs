using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplikacija.Models;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace WebAplikacija.Controllers
{
    public class ProductController : Controller
    {

        DjoleEntities contextPObject = new DjoleEntities();
        //Adding product view
        public ActionResult AddProduct ()
        {

            var productM = new ProductModel();
            return View("AddProduct",productM); 
        }


        //Adding products 
        [HttpPost]
        public ActionResult AddProduct(ProductModel productM)
        {

          
            contextPObject.Products.Add(new Product()
            {
                Name = productM.Name,
                Description = productM.Description,
                Category = productM.Category,
                Manufacturer = productM.Manufacturer,
                Price = productM.Price,
                Suplier = productM.Suplier

            });
            contextPObject.SaveChanges();
            return View("AddProduct", productM);
        }
        //Showing products 
        public ActionResult DisplayProducts ()
        {
           
            var productsRecord = contextPObject.Products.ToList(); 
            return View("DisplayProducts",productsRecord);
        }

        //update products
        public ActionResult EditProducts(int productID)
        {

            var productsRec = (from item in contextPObject.Products
                               where item.ID == productID
                               select item).First();
            return View("EditProducts", productsRec);
        }


        [HttpPost]
        public ActionResult EditProducts(Product obj)
        {
            var productsRec = (from item in contextPObject.Products
                               where item.ID == obj.ID
                               select item).First();

            productsRec.Name = obj.Name;
            productsRec.Manufacturer = obj.Manufacturer;
            productsRec.Price = obj.Price;
            productsRec.Suplier = obj.Suplier;
            productsRec.Description = obj.Description;
            productsRec.Category = obj.Category;

            contextPObject.SaveChanges();

            var productsRecord = contextPObject.Products.ToList();
            return View("DisplayProducts", productsRecord);
        }

        //showing products from JSON file 
        public ActionResult ImportProduct()
        {
            

            return View("ImportProduct");
        }

        [HttpPost]
        public ActionResult Import(HttpPostedFileBase jsonFile)
        {
            if(!Path.GetFileName(jsonFile.FileName).EndsWith(".json"))
            {
                ViewBag.Error("Invalid type of file !");
            }
            else
            {
                jsonFile.SaveAs(Server.MapPath("~/JSONFiles/" + Path.GetFileName(jsonFile.FileName)));

                StreamReader streamReader = new StreamReader
                (Server.MapPath("~/JSONFiles/" + Path.GetFileName(jsonFile.FileName)));
                string data = streamReader.ReadToEnd();
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(data);
                products.ForEach(p =>
                {
                    Product product = new Product
                    {
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Suplier = p.Suplier,
                        Category = p.Category,
                        Manufacturer = p.Manufacturer

                    };
                    contextPObject.Products.Add(product);
                    contextPObject.SaveChanges();

                    
                });
                ViewBag.Success = "Success";

            }
            return View("ImportProduct");

        }

        public ActionResult ShowingProducts ()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"");
            var products = JsonConvert.DeserializeObject<Product>(json);
            return View("ShowingProducts",products);

        }


    }
}