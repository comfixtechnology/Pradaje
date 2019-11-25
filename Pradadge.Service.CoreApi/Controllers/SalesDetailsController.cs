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
    [RoutePrefix("api/v1/salesdetails")]
    public class SalesDetailsController : ApiController
    { 

        ISalesDetailRepository salesdetailsRepository; IReferenceManagerRepository refNo;
        public SalesDetailsController (ISalesDetailRepository salesdetailsRepository, IReferenceManagerRepository refNo)
        {
            this.salesdetailsRepository = salesdetailsRepository;
            this.refNo = refNo;
        }

        [HttpPost]
        [Route("saleproducts")]
        public HttpResponseMessage saleProducts([FromBody] List<SalesDetailsViewModel> model)
        {
            try
            {
                var data = salesdetailsRepository.SaleProduct(model);
                if (data)
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

        [HttpPost]
        [Route("createsalesdetails")]
        public HttpResponseMessage AddSalesDetails([FromBody] SalesDetailsViewModel model)
        {
            try
            {
                salesdetailsRepository.AddSalesDetails(model);
                 return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record Created Successfully" });

               
                //return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "The was an error creating this record" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"there was an error creating this record {e.Message}" });
            }
        }

        [HttpGet]
        [Route("getsalesdetails")]
        public HttpResponseMessage GetSalesDetails()
        {
            try
            {
                var data = salesdetailsRepository.GetAllSalesDetails();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("getsalesdetails/{id}")]
        public HttpResponseMessage GetSalesDetailsById(int id)
        {
            try
            {
                var data = salesdetailsRepository.GetSalesDetailsById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error {e.Message}" });
            }
        }


        [HttpPut]
        [Route("updatesalesdetails")]
        public HttpResponseMessage UpdateSalesDetails([FromBody] SalesDetailsViewModel model)
        {
            try
            {
                var data = salesdetailsRepository.UpdateSalesDetails(model);
                if (data)
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
