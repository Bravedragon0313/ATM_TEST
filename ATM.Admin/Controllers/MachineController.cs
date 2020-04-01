using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ATM.Utils.HttpContext;

namespace ATM.Admin.Controllers
{

    /// <summary>
    /// Home controller
    /// </summary>
    public class MachineController : Controller
    {
        private DAL.Services.BaseService _baseService;

        public MachineController(DAL.Services.BaseService baseService)
        {
            _baseService = baseService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MachinesList(int page)
        {
            var data = await _baseService.GetMachinesPagedAsync(page);

            ViewBag.MachinesList = data;
            ViewBag.Page = page;

            return View("MachinesList");
        }
        [Authorize]
        public async Task<IActionResult> AddMachine()
        {
            return View("AddMachine");
        }
        [Authorize]
        [HttpGet]
        public async Task<HttpContextUtils.CommonDataResponse> CreateTotem(string name)
        {
            var response = new HttpContextUtils.CommonDataResponse();

            var u = await _baseService.CreatePairingTotemAsync(name);

            response.Message = u.Token;

            return response;
        }


    }
        
}
