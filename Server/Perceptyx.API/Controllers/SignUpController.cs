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
    public class SignUpController : ApiController
    {
        private readonly IUserRepository userRepository;
        public SignUpController()
        {
            userRepository = new UserRepository();
        }

        [HttpPost]
        public HttpResponseMessage Post(DTO.UserInfo info)
        {
            try
            {
                var result = userRepository.Register(info);
                return Request.CreateResponse<bool>(result);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
