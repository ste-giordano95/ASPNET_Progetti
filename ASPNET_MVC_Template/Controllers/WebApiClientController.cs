using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASPNET_MVC_Template.Controllers
{
    public class WebApiClientController : Controller
    {
        // GET: WebApiClient
        public async Task<ActionResult> ClientCS()
        {
          
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:5738/api/Products");
                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject(jsonData);
                    ViewBag.Prodotti = result;
                }
            }
            return View();
        }
        public ActionResult ClientJQuery()
        {
            return View();
        }
    }
}