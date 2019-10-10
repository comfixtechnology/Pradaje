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
    [RoutePrefix("api/v1/stockcard")]
    public class StockCardController : ApiController
    { 

        IStockCardRepositorys stockcardrepository;
        public StockCardController (IStockCardRepositorys stockcardrepository)
        {
            this.stockcardrepository = stockcardrepository;
        }

        [HttpPost]
        [Route("createstockcard")]
        public HttpResponseMessage AddStockCard([FromBody] StockCardViewModel model)
        {
            try
            {
                var data = stockcardrepository.AddStockCard(model);
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
        [Route("getstockcard")]
        public HttpResponseMessage GetStockCard()
        {
            try
            {
                var data = stockcardrepository.GetAllStockCard();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("getstockcard/{id}")]
        public HttpResponseMessage GetStockCardById(int id)
        {
            try
            {
                var data = stockcardrepository.GetStockCardById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error {e.Message}" });
            }
        }


        [HttpPut]
        [Route("updatestockcard")]
        public HttpResponseMessage UpdateStockCard([FromBody] StockCardViewModel model)
        {
            try
            {
                var data = stockcardrepository.UpdateStockCard(model);
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
