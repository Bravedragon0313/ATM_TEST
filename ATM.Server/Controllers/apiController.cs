
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ATM.Server.Controllers
{
    /// <summary>
    /// ApiController
    /// </summary>
    public class ApiController : Controller
    {
        private DAL.Services.BaseService _baseService;

        public ApiController(DAL.Services.BaseService service)
        {
            _baseService = service;
        }

        [HttpGet]
        public async Task<string> InsertLog(string deviceId, string message)
        {
            var u = await _baseService.InsertLogAsync(deviceId, message);
            return u.Message;
        }
    }
}
