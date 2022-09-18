using ASPNET_MVC_Template.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNET_MVC_Template.Controllers
{
    public class ClientiController : Controller
    {
        private NorthwindEntities northwinDb = new NorthwindEntities();
        // GET: Clienti
        public ActionResult Index()
        {
            
            //LINQ query expression
            var query = from c in northwinDb.Customers
                        select c;

            //LINQ Method expresssion
            //var query2 = northwinDb.Customers.Where(c => c.Country == "Germany").ToList();

            return View(query.ToList());
        }

        public ActionResult Tabella()
        {
          
            //LINQ query expression
            //var query = from c in northwinDb.Customers
            //            select c;

            //LINQ Method expresssion
            var query2 = northwinDb.Customers.Where(c => c.Country == "Germany").ToList();

            return View(query2.ToList());
        }

        public ActionResult ClientiPerPaese(string paese)
        {
           var paesi = northwinDb.Customers.Select(c => c.Country).ToList();
            ViewBag.paesi = paesi;

            List<Customers> query = northwinDb.Customers.ToList(); 

            if (!String.IsNullOrEmpty(paese))
            {
                ViewBag.Paese = paese;
                query = northwinDb.Customers
                    .Where(c => c.Country == paese)
                    .ToList();
            }
            return View(query);
        }

    }
}