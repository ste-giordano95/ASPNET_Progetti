using ASPNET_MVC_Core.Models;
using ASPNET_MVC_Core.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_MVC_Core.Controllers
{
    public class JoinController : Controller
    {
        private NorthwindContext db;
        public JoinController(NorthwindContext _db) { db = _db; }
        public async Task<IActionResult> Index(int currentPageIndex = 1)
        {
            int maxRows = 10;
            IQueryable<Join> query = (from c in db.Customers
                         join o in db.Orders
                         on c.CustomerId equals o.CustomerId
                         select new Join
                         {
                             OrderId = o.OrderId,
                             OrderDate = o.OrderDate,
                             CustomerId = o.CustomerId,
                             CompanyName = c.CompanyName,
                             City = c.City,
                             Country = c.Country
                         })
                       .Skip((currentPageIndex - 1) * maxRows)
                       .Take(maxRows);

            double pageCount = (double)((decimal)db.Orders.Count() / Convert.ToDecimal(maxRows));
            ViewBag.pageCount = (int)Math.Ceiling(pageCount);
            ViewBag.CurrentPageIndex = currentPageIndex;

            return View(null,await query.ToListAsync());
        }
    }
}
