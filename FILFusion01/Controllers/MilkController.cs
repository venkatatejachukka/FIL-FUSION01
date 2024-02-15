using Microsoft.AspNetCore.Mvc;

namespace FILFusion01.Controllers
{
    public class MilkController : Controller
    {
        public IActionResult TotalQtyAndPrice()
        {
            return View();
        }
    }
}
