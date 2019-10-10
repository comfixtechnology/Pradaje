using Pradadge.Common.Enum;
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
    [RoutePrefix("api/v1/purchaseorder")]
    public class PurchaseOrderController : ApiController
    {
      

        IPurchaseOrderRepositorys purchaseOrderrepository; IReferenceManagerRepository refNo;
        public PurchaseOrderController (IPurchaseOrderRepositorys purchaseOrderrepository, IReferenceManagerRepository refNo )
        {
            this.purchaseOrderrepository = purchaseOrderrepository;
            this.refNo = refNo;
        }

        [HttpPost]
        [Route("receive-order")]
        public HttpResponseMessage RecieveOrder([FromBody] OrderDetailViewModel model)
        {
            try
            {
                var data = purchaseOrderrepository.RecieveOrder(model);
                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record has been created successfully" });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "There was an error creating the record" });
                //}
                //else
                //{
                //    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Purchase Order Details are not provided" });
                //}
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was an error creating the record {e.Message}" });
            }
        }

        [HttpPost]
        [Route("receive-all-order")]
        public HttpResponseMessage ReceiveAllOrders([FromBody] List< OrderDetailViewModel> model)
        {
            try
            {
                 var output = purchaseOrderrepository.ReceiveAllOrders(model);
                if (output )
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record has been created successfully" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "There was an error creating the record" });
                //}
                //else
                //{
                //    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Purchase Order Details are not provided" });
                //}
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was an error creating the record {e.Message}" });
            }
        }

        [HttpPost]
        [Route("createpurchaseorder")]
        public HttpResponseMessage CreatePurchaseOrder([FromBody] PurchaseOrderViewModel model)
        {
            try
            {
                if (model.details.Sum(s => s.quantity) > 0)
                {
                    var data = purchaseOrderrepository.AddPurchaseOrder(model);
                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record has been created successfully" });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "There was an error creating the record" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Purchase Order Details are not provided" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was an error creating the record {e.Message}" });
            }
        }

        [HttpGet]
        [Route("getlastrecordorder")]
        public HttpResponseMessage GetPurchaseOrderRecordId()
        {
            try
            {
                var data = purchaseOrderrepository.GetPurchaseOrderRecordId();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message});
            }
        }

        [HttpGet]
        [Route("getreferenceno")]
        public HttpResponseMessage GetReferenceNo()
        {
            try
            {
                var data = refNo.GetReferenceNo((int) ReferenceTypesEnum.PurchaseOrder, 1);
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("getpurchaseordercode")]
        public HttpResponseMessage GetPurchaseOrderCode ()
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

        [HttpPost]
        [Route("deleteorderdetail")]
        public HttpResponseMessage DeleteOrderDetail(OrderDetailViewModel entity)
        {
            try
            {

                var result = purchaseOrderrepository.DeleteOrderDetail(entity);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = result, result = entity });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, result = entity });



            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was an error deleting this record {e.Message}" });
            }
        }

        [HttpGet]
        [Route("deleteorder")]
        public HttpResponseMessage DeletePurchaseOrder(int id)
        {
            try
            {
                purchaseOrderrepository.DeletePurchaseOrder(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = id });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was an error deleting this record {e.Message}" });
            }
        }

        [HttpPut]
        [Route("updatepurchaseorder")]
        public HttpResponseMessage UpdatePurchaseOrder([FromBody]  PurchaseOrderViewModel model)
        {
            try
            {
                var data = purchaseOrderrepository.UpdatePurchaseOrder(model);
                //if (data != null)
                //{
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record updated successfully" });
                //}
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "There was an error updating the record" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was an error updating the record {ex.Message}" });
            }
        }

        [HttpPut]
        [Route("updatepurchaseorderdetail")]
        public HttpResponseMessage UpdatePurchaseOrderDetail([FromBody]  OrderDetailViewModel model)
        {
            try
            {
                var data = purchaseOrderrepository.UpdatePurchaseOderDetail(model);
                //if (data != null)
                //{
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record updated successfully" });
                //}
                //return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "There was an error updating the record" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was an error updating the record {ex.Message}" });
            }
        }

    }
}
          