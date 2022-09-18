using ASPNET_MVC_Core.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_MVC_Core.Controllers
{
    public class ProductController : Controller
    {
        private NorthwindContext db;
        public ProductController(NorthwindContext _db) { db = _db; }
        public async Task<IActionResult> Index(string name)
        {
            ViewBag.ElementDropDown = await db.Products.Select(x => x.ProductName).ToListAsync();


            List<Models.Product> result;
            if (!string.IsNullOrEmpty(name))
                result = await db.Products.Where(c => c.ProductName == name).ToListAsync();
            else 
                result = await db.Products.ToListAsync();

            return View(result);
        }
    }
}
