using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Perceptyx.API.Claims;
using System.Web;

namespace Perceptyx.API.Controllers
{
    public class BaseController : ApiController
    {
        protected virtual new UserPrincipal User
        {
            get { return HttpContext.Current.User as UserPrincipal; }
        }
    }
}
