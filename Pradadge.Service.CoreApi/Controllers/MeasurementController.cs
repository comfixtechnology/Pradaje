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
    [RoutePrefix("api/v1/measurement")]
    public class MeasurementController : ApiController
    {
        IMeasurementRepository repo;
        public MeasurementController (IMeasurementRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage AddMeasurement ([FromBody] MeasurementViewModel model)
        {
            try
            {
                var data = repo.AddMeasurement(model);
                if(data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "the record has successfully been created" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "there was an error creating this record" });
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"there was an error creating this record {e.Message}" });
            }
        }

        [HttpGet]
        [Route("get")]
        public HttpResponseMessage GetMeasurement()
        {
            try
            {
                var data = repo.GetMeasurement().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data});
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public HttpResponseMessage GetMeasurementById (int id)
        {
            try
            {
                var data = repo.GetMeasurementById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error: {e.Message}" });
            }
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdateMeasurement ([FromBody] MeasurementViewModel model)
        {
            try
            {
                var data = repo.UpdateMasurement(model);
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "the record has successfully been created" });             
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"there was an error creating this record {e.Message}" });
            }
        }
    }
}
