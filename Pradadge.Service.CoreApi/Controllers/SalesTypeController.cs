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
    [RoutePrefix("api/v1/salestype")]
    public class SalesTypeController : ApiController
    {
        ISalesTypesRepository salestyperepository;
            public SalesTypeController(ISalesTypesRepository salestyperepository)
            {
                this.salestyperepository = salestyperepository;
            }

        [HttpPost]
        [Route("createsalestype")]
        public HttpResponseMessage CreateSalesType([FromBody] SalesTypeViewModel model)
        {
            try
            {
                var data = salestyperepository.AddSalesType(model);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record has been updated Successfully" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, result = model, message = "There was an error updating this record" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $" There was an error creating this record{e.Message}" });
            }
        }

        [HttpGet]
        [Route("getallsalestype")]
        public HttpResponseMessage GetSalesType()
        {
            try
            {
                var data = salestyperepository.GetAllSalesTypes();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("getSalesType/{id}")]
        public HttpResponseMessage GetSalesType(int id)
        {
            try
            {
                var data = salestyperepository.GetSalesTypesById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpPut]
        [Route("updatesalestype")]
        public HttpResponseMessage UpdateSalesType([FromBody] SalesTypeViewModel model)
        {
            try
            {
                var data = salestyperepository.UpdateSalesType(model);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record has been updated Successfully" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, result = model, message = "There was an error updating this record" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $" There was an error updating this record{e.Message}" });
            }
        }
    }
}
