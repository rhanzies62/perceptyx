using Perceptyx.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Perceptyx.Core.DTO;

namespace Perceptyx.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Model.PerceptyxContext perceptyxContext;
        public UserRepository()
        {
            perceptyxContext = new Model.PerceptyxContext();
        }

        public UserInfo Login(UserCredential model)
        {
            var userinfo = perceptyxContext.Users.Where(i => i.EmailAddress.Equals(model.EmailAddress)).FirstOrDefault();
            if(userinfo != null)
            {
                var hash = new HashBrown();
                var password = string.Concat(model.Password, userinfo.Salt);
                if(password == userinfo.Password) { return new UserInfo(userinfo); }
                else { throw new Exception("Email/Password didn't match"); }
            }
            throw new Exception("User not found");
        }

        public bool Register(UserInfo model)
        {
            var userEntity = new Model.User();
            userEntity.FirstName = model.FirstName;
            userEntity.LastName = model.LastName;
            userEntity.Salt = Guid.NewGuid().ToString("N");
            userEntity.EmailAddress = model.EmailAddress;
            userEntity.IsAdmin = model.IsAdmin;

            var password = string.Concat(model.Password, userEntity.Salt);

            userEntity.CreatedDate = DateTime.UtcNow;
            userEntity.CreatedBy = string.Concat(model.FirstName, model.LastName);

            perceptyxContext.Users.Add(userEntity);
            perceptyxContext.SaveChanges();
            return true;
        }
    }
}
