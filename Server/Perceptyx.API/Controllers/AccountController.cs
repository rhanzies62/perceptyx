using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO = Perceptyx.Core.DTO;
using Perceptyx.Core.Interface;
using Perceptyx.Core.Repository;
using Perceptyx.API.Claims;
namespace Perceptyx.API.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IUserRepository userRepository;

        public AccountController()
        {
            userRepository = new UserRepository();
        }

        public HttpResponseMessage Login(DTO.UserCredential info)
        {
            try
            {
                var result = userRepository.Login(info);
                string data = Bouncer.Login(new UserPrincipalSerializeModel(result));
                return Request.CreateResponse<string>(data);
            }catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
