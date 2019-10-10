using Pradadge.Contract.DataRepositoryInterface.Setup;
using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pradadge.Service.CoreApi.Controllers
{
    [RoutePrefix("api/v1/section")]
    public class SectionController : ApiController
    {
        ISectionRepository sectionrepository;
        public SectionController (ISectionRepository sectionrepository)
        {
            this.sectionrepository = sectionrepository;
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage CreateSection ([FromBody] SectionViewModel model)
        {
            try
            {
                var data = sectionrepository.AddSection(model);
                if(data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record has been created successfully" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "There was an error creating this message" });
            }

            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was an error creating this message {e.Message}" });
            }
        }

        [HttpGet]
        [Route("get")]
        public HttpResponseMessage GetSection()
        {
            try
            {
                var data = sectionrepository.GetSection().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public HttpResponseMessage GetSectionById(int id)
        {
            try
            {
                var data = sectionrepository.GetSectionById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error: {e.Message }" });
            }
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdateSection ([FromBody] SectionViewModel model)
        {
            try
            {
                var data = sectionrepository.AddSection(model);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record has been created successfully" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "There was an error creating this message" });
            }

            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was an error creating this message {e.Message}" });
            }
        }
        
    }
}
