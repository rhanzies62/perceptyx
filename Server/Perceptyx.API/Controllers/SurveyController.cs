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
    [SecureAuthorize]
    public class SurveyController : BaseController
    {
        private readonly ISurveyRepository surveyRepository;
        public SurveyController()
        {
            this.surveyRepository = new SurveyRepository();
        }

        [HttpPost]
        public HttpResponseMessage Post(DTO.Survey survey)
        {
            try {
                survey.CreatedBy = this.User.FirstName;
                var result = this.surveyRepository.Add(survey);
                return Request.CreateResponse<bool>(true);
            }
            catch (Exception e){
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(DTO.Survey survey)
        {
            try
            {
                survey.CreatedBy = this.User.FirstName;
                var result = this.surveyRepository.Edit(survey);
                return Request.CreateResponse<bool>(true);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int surveyId)
        {
            try
            {
                var result = this.surveyRepository.Delete(surveyId);
                return Request.CreateResponse<bool>(result);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var result = this.surveyRepository.Retrieve();
                return Request.CreateResponse<List<DTO.Survey>>(result);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(int skip, int take)
        {
            try
            {
                var result = this.surveyRepository.Retrieve(skip,take);
                return Request.CreateResponse<List<DTO.Survey>>(result);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(string name, int skip, int take)
        {
            try
            {
                var result = this.surveyRepository.Retrieve(name,skip, take);
                return Request.CreateResponse<List<DTO.Survey>>(result);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var result = this.surveyRepository.Get(id);
                return Request.CreateResponse<DTO.Survey>(result);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(string name)
        {
            try
            {
                var result = this.surveyRepository.Get(name);
                return Request.CreateResponse<DTO.Survey>(result);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
