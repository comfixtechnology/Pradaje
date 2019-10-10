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
    [RoutePrefix("api/v1/vendor")]
    public class VendorController : ApiController
    {
        IVendorRepository repo;
        public VendorController(IVendorRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage AddCountry([FromBody] VendorViewModel model)
        {
            try
            {
                var data = repo.AddVendor(model);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record has suucessfully been created" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, result = model, message = "There was error creating this record" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, result = model, message = $"There was error creating this record {e.Message}" });
            }

        }

        [HttpGet]
        [Route("get")]
        public HttpResponseMessage GetCountry()
        {
            try
            {
                var data = repo.GetVendor().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public HttpResponseMessage GetCountryById(int id)
        {
            try
            {
                var data = repo.GetVendorById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error: {e.Message}" });
            }
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdateCounty([FromBody] VendorViewModel model)
        {
            try
            {
                var data = repo.UpdateVendor(model);
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record has successfully been updated" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, result = model, message = $"There was error updating this record {e.Message}" });
            }
        }
    }
}
