using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignOut()
        {
            return View();
        }
    }
}
