using ASPNET_MVC_Core.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_MVC_Core.Controllers
{
    public class uspController : Controller
    {
        private NorthwindContext db;
        public uspController(NorthwindContext _db) { db = _db; }
        public  IActionResult Index()
        {
            return View(db.Procedures.TenMostExpensiveProductsAsync().Result.ToList());
        }
    }
}
