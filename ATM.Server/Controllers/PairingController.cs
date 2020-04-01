using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Server.Controllers
{
    /// <summary>
    /// Pairing controller
    /// </summary>
    public class Pairing : Controller
    {
        private DAL.Services.BaseService _baseService;

        public Pairing(DAL.Services.BaseService baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<string> Ca(string token)
        {
            //todo: do real logic here
            var u = await _baseService.Ca(token);
            return u.Token;

        }

        [HttpPost]
        public string pair()
        {
            //todo: do real logic here
            var data = _baseService.ReadData();
            return data;
        }
    }
}
