using Pradadge.Common.Enum;
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
    [RoutePrefix("api/v1/vendorpayment")]
    public class VendorPaymentController : ApiController
    {
            IVendorPaymentRepository repo; IPurchaseOrderRepositorys purchaseOrderrepository; IReferenceManagerRepository refNo;
            public VendorPaymentController (IVendorPaymentRepository repo, IPurchaseOrderRepositorys puchOrder, IReferenceManagerRepository refNo)
            {
                this.repo = repo;
                this.purchaseOrderrepository = purchaseOrderrepository;
                this.refNo = refNo;
            }

            [HttpPost]
            [Route("create")]
            public HttpResponseMessage AddVendorPayment([FromBody] VendorPaymentViewModel model)
            {
                try
                {
                    var data = repo.AddVendorPayment(model);
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
        [Route("getreferenceno")]
        public HttpResponseMessage GetReferenceNo()
        {
            try
            {
                var data = refNo.GetReferenceNo((int)ReferenceTypesEnum.PurchaseOrder, 1);
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("getpurchaseordercode")]
        public HttpResponseMessage GetPurchaseOrderCode()
        {
            try
            {
                var data = purchaseOrderrepository.GetOrderCode();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("getpurchaseorder")]
        public HttpResponseMessage GetPurchaseOrder()
        {
            try
            {
                var data = purchaseOrderrepository.GetAllPurchaseOrder();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("getpurchaseorder/{id}")]
        public HttpResponseMessage GetPurchaseOrderById(int id)
        {
            try
            {
                var data = purchaseOrderrepository.GetPurchaseOrderById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, Message = $"Error: {ex.Message}" });
            }
        }

        [HttpGet]
            [Route("get")]
            public HttpResponseMessage GetVendorPayment()
            {
                try
                {
                    var data = repo.GetVendorPayment().ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, result = data });
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
                }
            }

            [HttpGet]
            [Route("get/{id}")]
            public HttpResponseMessage GetVendorPaymentById(int id)
            {
                try
                {
                    var data = repo.GetVendorPaymentById(id).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error: {e.Message}" });
                }
            }

            [HttpPut]
            [Route("update")]
            public HttpResponseMessage UpdateVendorPayment([FromBody] VendorPaymentViewModel model)
            {
                try
                {
                    var data = repo.UpdateVendorPayment(model);
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record has successfully been updated" });
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, result = model, message = $"There was error updating this record {e.Message}" });
                }
            }

        }
    }

