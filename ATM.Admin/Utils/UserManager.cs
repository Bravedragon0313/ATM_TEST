using ATM.BL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ATM.Admin.Utils
{
    /// <summary>
    /// UserManager
    /// </summary>
    public class UserManager
    {
        string _connectionString;

        public UserManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async void SignIn(HttpContext httpContext, User user, bool isPersistent = false)
        {
            ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(user), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        public async void SignOut(HttpContext httpContext)
        {
            try
            {
                await httpContext.SignOutAsync();
            }
            catch (Exception ex)
            {

            }
        }

        private IEnumerable<Claim> GetTestUserClaims()
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, "TestUser"));
            claims.Add(new Claim(ClaimTypes.Name, "user1"));
            claims.Add(new Claim(ClaimTypes.Email, "a@b.c"));
            claims.AddRange(this.GetTestUserRoleClaims());

            return claims;
        }

        private IEnumerable<Claim> GetUserClaims(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserName));
            claims.Add(new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.PrimarySid, user.Id.ToString()));

            return claims;
        }

        private IEnumerable<Claim> GetTestUserRoleClaims()
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, "asdf"));
            claims.Add(new Claim(ClaimTypes.Role, "admin"));

            return claims;
        }
    }
}
