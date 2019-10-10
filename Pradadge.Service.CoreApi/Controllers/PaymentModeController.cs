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
    [RoutePrefix("api/v1/paymentmode")]
    public class PaymentModeController : ApiController
    {
      

        IPaymentModesRepository paymentmoderepository;
        public PaymentModeController (IPaymentModesRepository paymentmoderepository)
        {
            this.paymentmoderepository = paymentmoderepository;
        }

        [HttpPost]
        [Route("createpaymentmode")]
        public HttpResponseMessage AddPaymentMode([FromBody] PaymentModeViewModel model)
        {
            try
            {
                var data = paymentmoderepository.AddPaymentMode(model);
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
        [Route("getpaymentmode")]
        public HttpResponseMessage GetPaymentMode()
        {
            try
            {
                var data = paymentmoderepository.GetAllPaymentModes();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("getpayment/{id}")]
        public HttpResponseMessage GetPaymentModeById(int id)
        {
            try
            {
                var data = paymentmoderepository.GetPaymentModeById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error {e.Message}" });
            }
        }


        [HttpPut]
        [Route("updatepaymentmode")]
        public HttpResponseMessage UpdatePaymentMode([FromBody] PaymentModeViewModel model)
        {
            try
            {
                var data = paymentmoderepository.UpdatePaymentModeDetails(model);
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
