using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Admin.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : Controller
    {
        private DAL.Services.BaseService _baseService;

        public HomeController(DAL.Services.BaseService baseService)
        {
            _baseService = baseService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
