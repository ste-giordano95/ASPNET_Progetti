using Microsoft.AspNetCore.Mvc;
using WebApplication1Prova.Data;

namespace WebApplication1Prova.Controllers
{
    public class ProductController : Controller
    {
        private NorthwindContext db;
        public ProductController(NorthwindContext _db) { db = _db; }
        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}
