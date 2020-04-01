using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ATM.RequestLog.Services;

namespace ATM.Admin.Controllers
{
    /// <summary>
    /// Log controller
    /// </summary>
    public class Log : Controller
    {
        private DAL.Services.BaseService _baseService;
        private LogService _logservice;

        public Log(DAL.Services.BaseService baseService, LogService logservice)
        {
            _baseService = baseService;
            _logservice = logservice;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetLogs(int page)
        {
            var logsList = await _baseService.GetLogsPagedAsync(page);
            var deviceList = await _baseService.GetDevicesListAsync();

            ViewBag.LogsList = logsList;
            ViewBag.Page = page;
            ViewBag.DeviceList = deviceList;

            return View("GetLog");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetRequestLogs(int page)
        {
            var data = await _logservice.GetRequestLogPagedAsync(page);

            ViewBag.RequestLogsList = data;
            ViewBag.Page = page;

            return View("GetRequestLog");
        }
    }
}
