using Microsoft.AspNetCore.Mvc;

namespace GeorgianCollegeAD_Project.Controllers
{
    public class CheckListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Category(String Name)
        {
            if(Name == null)
            {
                return RedirectToAction("Index");
            }

            ViewData["Category"] = Name;
            return View();
        }
    }
}
