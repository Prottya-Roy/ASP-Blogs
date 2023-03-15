using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
