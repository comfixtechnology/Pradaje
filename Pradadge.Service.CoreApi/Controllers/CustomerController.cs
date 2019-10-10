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
    [RoutePrefix("api/v1/customers")]
    public class CustomerController : ApiController
    { 
        ICustomerRepository customerrepository;
        public CustomerController (ICustomerRepository customerrepository)
        {
            this.customerrepository = customerrepository;
        }

        [HttpPost]
        [Route("createcustomer")]
        public HttpResponseMessage AddCustomer([FromBody] CustomerViewModel model)
        {
            try
            {
                var data = customerrepository.AddCustomer(model);
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
        [Route("getallcustomers")]
        public HttpResponseMessage GetCustomer()
        {
            try
            {
                var data = customerrepository.GetCustomer();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }

        }

        [HttpGet]
        [Route("getcustomer/{id}")]
        public HttpResponseMessage GetCustomerById(int id)
        {
            try
            {
                var data = customerrepository.GetCustomerById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error {e.Message}" });
            }
        }


        [HttpPut]
        [Route("updatecustomer")]
        public HttpResponseMessage UpdateCustomer([FromBody] CustomerViewModel model)
        {
            try
            {
                var data = customerrepository.UpdateCustomerDetails(model);
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
