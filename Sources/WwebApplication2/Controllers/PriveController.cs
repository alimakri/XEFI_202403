using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WwebApplication2.Controllers
{
    [Authorize]
    public class PriveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
