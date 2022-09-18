using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace ASPNET_MVC_Template.Controllers
{
    public class StatoController : Controller
    {
        // GET: Stato
        public ActionResult Partenza()
        {
            if (!String.IsNullOrEmpty((string)Request["txtSS"]))
            {
                Session["SS"] = Request["txtSS"];
            }

            if (!String.IsNullOrEmpty((string)Request["txtCH"]))
            {
                HttpContext.Cache.Insert("CC", (string)Request["txtCH"], null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration);
            }

                return View();
        }

        public ActionResult Arrivo()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Arrivo")]
        public ActionResult ArrivoPost()
        {

            ViewBag.Session = Session["SS"];
            ViewBag.Cache = HttpContext.Cache["CC"];

            return View();
        }
    }
}