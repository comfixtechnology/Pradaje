using Pradadge.Contract.DataRepositoryInterface.Setup;
using Pradadge.ViewModel.Business;
using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pradadge.Service.CoreApi.Controllers
{
    [RoutePrefix("api/v1/damage")]
    public class DamageController : ApiController
    { 

        IDamagesRepositorys damagerepository;
        public DamageController (IDamagesRepositorys damagerepository)
        {
            this.damagerepository = damagerepository;
        }

        [HttpPost]
        [Route("createdamages")]
        public HttpResponseMessage AddDamages([FromBody]DamagesViewModel model)
        {
            try
            {
                var data = damagerepository.AddDamages(model);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record Created Successfully" });

                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "The was an error creating this record" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"there was an error creating this record {e.Message}" });
            }
        }

        [HttpGet]
        [Route("getalldamages")]
        public HttpResponseMessage GetAllDamages ()
        {
            try
            {
                var data = damagerepository.GetDamagesEncured();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { succes = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("getdamages/{id}")]
        public HttpResponseMessage GetDamagesById(int id)
        {
            try
            {
                var data = damagerepository.GetDamagesById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error {e.Message}" });
            }
        }


        [HttpPut]
        [Route("updatedamages")]
        public HttpResponseMessage UpdateDamages([FromBody] DamagesViewModel model)
        {
            try
            {
                var data = damagerepository.UpdateDamages(model);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, Result = model, Message = "The record Updated Successfully" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = " There was an Error updating the record" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was an Error updating the record { ex.Message }" });
            }
        }
    }
}
