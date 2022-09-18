using ASPNET_MVC_Esercizio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNET_MVC_Esercizio.Controllers
{
    public class ProductController : Controller
    {
        private Model1 db = new Model1();
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.DropDown = db.Order_Details_Extended.Select(c => c.ProductName).Distinct().ToList();
            return View();
        }
        public PartialViewResult orderProduct()
        {
            List<Order_Details_Extended> data = new List<Order_Details_Extended>();
            if (!String.IsNullOrEmpty((string)Request["productName"]))
            {
                string name = (string)Request["productName"];
                data = db.Order_Details_Extended.Where(c => c.ProductName == name).ToList();
            }
            return PartialView("_ordinazioniProdotto", data);
        }
    }
}