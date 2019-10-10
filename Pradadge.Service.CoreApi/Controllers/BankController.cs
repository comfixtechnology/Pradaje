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
    [RoutePrefix("api/v1/bank")]
    public class BankController : ApiController
    {
        IBankRepository repo;
        public BankController(IBankRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [Route("createbank")]
        public HttpResponseMessage AddBank ([FromBody] BanksViewModel model)
        {
            try
            {
                var data = repo.AddBank(model);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record has been creted successfuly" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "There was error creating record" });
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was error creating record{e.Message}" });
            }
            
        }

        [HttpGet]
        [Route("getallbanks")]
        public HttpResponseMessage GetAllBanks([FromBody] BanksViewModel model)
        {
            try
            {
                var data = repo.GetAllBanks();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        [Route("getbank/{id}")]
        public HttpResponseMessage GetBank(int id)
        {
            try
            {
                var data = repo.GetBank(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }

        [HttpPut]
        [Route("updatebank")]
        public HttpResponseMessage Update ([FromBody] BanksViewModel model)
        {
            try
            {
                var data = repo.UpdateBank(model);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record has been creted successfuly" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "There was error creating record" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was error creating record{e.Message}" });
            }

        }
    }
}
