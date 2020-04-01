using ATM.Admin.Utils;
using ATM.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ATM.Utils.HttpContext;
using Twilio.TwiML.Voice;

namespace ATM.Admin.Controllers
{
    /// <summary>
    /// Account controller
    /// </summary>
    public class AccountController : Controller
    {
        public UserManager _userManager;
        private DAL.Services.BaseService _baseService;

        public AccountController(UserManager u, DAL.Services.BaseService bs)
        {
            _userManager = u;
            _baseService = bs;
        }

        [HttpPost]
        public async Task<HttpContextUtils.CommonDataResponse> DoLogIn([FromBody]User u)
        {
            var response = new HttpContextUtils.CommonDataResponse { IsError = true };

            if (!string.IsNullOrEmpty(u.UserName) && !string.IsNullOrEmpty(u.Password))
            {
                var user = await _baseService.GetUserByUsernameAsync(u.UserName);

                if (user != null && user.Password == u.Password)
                {
                    _userManager.SignIn(HttpContext, user);

                    response.IsError = false;

                    return response;
                }
            }

            return response;
        }

        public IActionResult LogIn()
        {
            return View("LogIn");
        }

        public IActionResult LogOut()
        {
            _userManager.SignOut(HttpContext);

            return View("LogOut");
        }
    }
}
