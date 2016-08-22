using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Security;

namespace Perceptyx.API.Claims
{
    public class Bouncer
    {
        public static string Login(UserPrincipalSerializeModel info, bool rememberMe = false)
        {
            string userData = JsonConvert.SerializeObject(info);
            return Bouncer.UpdateCookie(userData, rememberMe);
        }

        public static void Logout()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Cookies.Add(
                new HttpCookie(FormsAuthentication.FormsCookieName)
                {
                    Value = "",
                    Expires = DateTime.UtcNow.AddDays(-2)
                });
        }

        private static string UpdateCookie(string ticket, bool rememberMe = false)
        {
            var cookieTicket = new FormsAuthenticationTicket(1, "data", DateTime.UtcNow, DateTime.UtcNow.Add(FormsAuthentication.Timeout), rememberMe, ticket);
            var token = FormsAuthentication.Encrypt(cookieTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, token)
            {
                Expires = DateTime.UtcNow.Add(FormsAuthentication.Timeout),
                HttpOnly = true
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
            return token;
        }
    }
}