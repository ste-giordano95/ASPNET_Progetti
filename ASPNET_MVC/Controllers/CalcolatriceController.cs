using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace ASPNET_MVC.Controllers
{
    public class CalcolatriceController : Controller
    {
        // GET: Calcolatrice
        public ActionResult Index()
        {
            int n1 = Request["txt7"].AsInt();
            int n2 = Request["txt8"].AsInt();
 
            ViewBag.Risultato = n1 + n2;
            return View();
        }
    }
}