using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Perceptyx.API.Claims
{
    public interface IUserPrincipal : IPrincipal
    {
        int id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
