using ASPNET_MVC_Template.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNET_MVC_Template.Controllers
{
    public class FiltraController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();
        // GET: Filtra
        public ActionResult ElencoPaesi()
        {
            return View(db.Customers.Select(c => c.Country).Distinct().ToList());
        }
        public PartialViewResult ElencoClienti(string paesi)
        {
            List<Customers> result = db.Customers.ToList();
            if (!String.IsNullOrEmpty(paesi))
                result = db.Customers.Where(c => c.Country == paesi).ToList();
            return PartialView("_tabellaClienti",result);
        }
    }
}