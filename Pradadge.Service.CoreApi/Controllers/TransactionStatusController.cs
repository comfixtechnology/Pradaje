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
    [RoutePrefix("api/v1/transactionstatus")]
    public class TransactionStatusController : ApiController
    {
       
        ITransactionStatusRepositorys transactionstatusrepository;
        public TransactionStatusController (ITransactionStatusRepositorys transactionstatusrepository)
        {
            this.transactionstatusrepository = transactionstatusrepository;
        }

        [HttpPost]
        [Route("createtransactionstatus")]
        public HttpResponseMessage AddTransactionStatus([FromBody] TransactionStatusViewModel model)
        {
            try
            {
                var data = transactionstatusrepository.AddTransactionStatus(model);
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
        [Route("gettransactionstatus")]
        public HttpResponseMessage GetTransactionStatus()
        {
            try
            {
                var data = transactionstatusrepository.GetAllTransactionStatus();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("gettransactionstatus/{Id}")]
        public HttpResponseMessage GetTransactionStatusId(int id)
        {
            try
            {
                var data = transactionstatusrepository.GetTransactionStatusById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error {e.Message}" });
            }
        }


        [HttpPut]
        [Route("updatetransactionstatus")]
        public HttpResponseMessage UpdateTransactionStatus([FromBody] TransactionStatusViewModel model)
        {
            try
            {
                var data = transactionstatusrepository.UpdateTransaction(model);
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
