using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using DTO = Perceptyx.Core.DTO;

namespace Perceptyx.API.Claims
{
    public class UserPrincipal : IUserPrincipal
    {
        public UserPrincipal()
        {

        }


        public string FirstName { get; set; }

        public int id { get; set; }

        public IIdentity Identity { get; private set; }

        public string LastName { get; set; }

        public bool IsInRole(string role)
        {
            return false;
        }
    }
}