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
    [RoutePrefix("api/v1/brand")]
    public class BrandController : ApiController
    {
     
        IBrandRepository brandrepository;
        public BrandController (IBrandRepository brandrepository)
        {
            this.brandrepository = brandrepository;
        }

        [HttpPost]
        [Route("createbrand")]
        public HttpResponseMessage CreateBrand ([FromBody] BrandViewModel model)
        {
            try
            {
                var data = brandrepository.AddBrand(model);
                if(data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record has been created successfully" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "There was an error creating the record" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was an error creating the record" });
            }
        }

        [HttpGet]
        [Route("getbrand")]
        public HttpResponseMessage GetBrand ()
        {
            try
            {
                var data = brandrepository.GetBrand().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("getbrand/{id}")]
        public HttpResponseMessage GetBrandById (int id)
        {
            try
            {
                var data = brandrepository.GetBrandById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, Message = $"Error: {ex.Message}" });
            }
        }

        [HttpPut]
        [Route("updatebrand")]
        public HttpResponseMessage UpdateBrand([FromBody] BrandViewModel model)
        {
            try
            {
                var data = brandrepository.UpdateBrand(model);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record updated successfully" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "There was an error updating the record" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was an error updating the record{ex.Message}" });
            }
        }
    }
}
