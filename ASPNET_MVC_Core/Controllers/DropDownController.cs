using ASPNET_MVC_Core.Models;
using ASPNET_MVC_Core.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNET_MVC_Core.Controllers
{
    public class DropDownController : Controller
    {
        private NorthwindContext db;
        public DropDownController(NorthwindContext context)
        {
            this.db = context;
        }

        public IActionResult Index()
        {
            List<int> rows = new List<int> { 2, 5, 10, 20 };
            ViewBag.ListaPaesi = db.Customers.Select(c => c.Country).Distinct();
            ViewBag.MaxRows = rows;
            return View();
        }


        [HttpPost]
        public PartialViewResult Index(string paese, int currentPageIndex = 1, int maxRows = 1)
        {
            
            List<Customer> items;
            double pageCount;

            if (!String.IsNullOrEmpty(paese) && paese != "Paese")
            {
                items = db.Customers.Where(c => c.Country == paese)
                    .Skip((currentPageIndex - 1) * maxRows)
                       .Take(maxRows).ToList();

                pageCount = (double)((decimal)db.Customers.Where(c => c.Country == paese).Count() / Convert.ToDecimal(maxRows));

            }
            else
            {
                items = db.Customers
                    .Skip((currentPageIndex - 1) * maxRows)
                       .Take(maxRows).ToList();

                pageCount = (double)((decimal)db.Customers.Count() / Convert.ToDecimal(maxRows));

            }

            ViewBag.pageCount = (int)Math.Ceiling(pageCount);
            ViewBag.CurrentPageIndex = currentPageIndex;

            return PartialView("_tabellaPartial", items);
        }
    }
}
