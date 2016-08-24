using System;
using Perceptyx.Core.Model;

namespace Perceptyx.Core.DTO
{
    public class UserInfo
    {
        public UserInfo() { }
        public UserInfo(User userinfo)
        {
            this.Id = userinfo.Id;
            this.FirstName = userinfo.FirstName;
            this.LastName = userinfo.LastName;
            this.EmailAddress = userinfo.EmailAddress;
            this.IsAdmin = userinfo.IsAdmin;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}