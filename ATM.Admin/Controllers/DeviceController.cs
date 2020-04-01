using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ATM.Utils.HttpContext;

namespace ATM.Admin.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    public class Device : Controller
    {
        private DAL.Services.BaseService _baseService;

        public Device(DAL.Services.BaseService baseService)
        {
            _baseService = baseService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetDevice(int page)
        {
            try
            {
                var data = await _baseService.GetDevicesPagedAsync(page);

                ViewBag.DevicesList = data;
                ViewBag.area = page;

            }
            catch (Exception ex)
            {

            }

            return View("GetDevice");
        }

        [Authorize]
        [HttpGet]
        public async Task<HttpContextUtils.CommonDataResponse> PairDevice(string deviceId, bool isPaired)
        {
            var response = new HttpContextUtils.CommonDataResponse { IsError = true };

            var u = await _baseService.PairDeviceAsync(deviceId, isPaired);

            if (u != null)
            {
                response.IsError = false;
                response.Message = u.Name;
            }

            return response;
        }
    }
}
