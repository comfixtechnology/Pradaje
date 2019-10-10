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
    [RoutePrefix("api/v1/payment")]
    public class PaymentController : ApiController
    { 
        IPaymentRepository paymentrepository;
        public PaymentController (IPaymentRepository paymentrepository)
        {
            this.paymentrepository = paymentrepository;
        }

        [HttpPost]
        [Route("createpayment")]
        public HttpResponseMessage AddPayment([FromBody] PaymentViewModel model)
        {
            try
            {
                var data = paymentrepository.AddPayment(model);
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
        [Route("getpayment")]
        public HttpResponseMessage GetPayment()
        {
            try
            {
                var data = paymentrepository.GetAllPayments();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("getpayment/{id}")]
        public HttpResponseMessage GetPaymentById(int id)
        {
            try
            {
                var data = paymentrepository.GetPaymentById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error {e.Message}" });
            }
        }


        [HttpPut]
        [Route("updatepayment")]
        public HttpResponseMessage UpdatePayment([FromBody] PaymentViewModel model)
        {
            try
            {
                var data = paymentrepository.UPdatePaymentDetails(model);
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
