using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptyx.Core.Interface
{
    public interface IUserRepository
    {
        DTO.UserInfo Login(DTO.UserCredential model);
        bool Register(DTO.UserInfo model);
    }
}
