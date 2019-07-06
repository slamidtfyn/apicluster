using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace site.Controllers
{
    public class ExecController : Controller
    {
        public void Index()
        {
            var c = new HttpClient();
            c.PostAsJsonAsync("http://localhost/5050/api/HttpTriggerCSharp", new { name = "Test" });
        }
    }

}