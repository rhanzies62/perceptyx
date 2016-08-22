using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO = Perceptyx.Core.DTO;

namespace Perceptyx.API.Claims
{
    public class UserPrincipalSerializeModel
    {
        public UserPrincipalSerializeModel(DTO.UserInfo info)
        {
            this.Id = info.Id;
            this.FirstName = info.FirstName;
            this.LastName = info.LastName;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}