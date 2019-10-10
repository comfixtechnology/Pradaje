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
    [RoutePrefix("api/v1/product")]
    public class ProductController : ApiController
    {
        

        IProductsRepository productrepository;
        public ProductController (IProductsRepository productrepository)
        {
            this.productrepository = productrepository;
        }

        [HttpPost]
        [Route("getStockProductByproductId")]
        public HttpResponseMessage GetStockProductByproductId([FromBody] int productId)
        {
            try
            {
                var data = productrepository.ProductStockDetails(productId);
                if (data != null)
                {
                  return  Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data, message = "Success" });

                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Not found" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"there was an error creating this record {e.Message}" });
            }
        }

        [HttpPost]
        [Route("createproduct")]
        public HttpResponseMessage AddProduct([FromBody] ProductViewModel model)
        {
            try
            {
                var data = productrepository.AddProduct(model);
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
        [Route("search")]
        public IHttpActionResult ProductSearch( string search)
        {
                var data = productrepository.ProductSearch(search);
                return Ok(data); // Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data, message = "Success" });
        }       

        [HttpGet]
        [Route("getproduct")]
        public HttpResponseMessage GetProduct()
        {
            try
            {
                var data = productrepository.GetAllProducts();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("getproduct/{id}")]
        public HttpResponseMessage GetProductById(int id)
        {
            try
            {
                var data = productrepository.GetProductById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error {e.Message}" });
            }
        }

        [HttpGet]
        [Route("getproductbycategory/{id}")]
        public HttpResponseMessage GetProductByCategoryId(int categoryid)
        {
            try
            {
                var data = productrepository.GetProductByCategory(categoryid).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error {e.Message}" });
            }
        }

        [HttpGet]
        [Route("getproductbybrand/{id}")]
        public HttpResponseMessage GetProductByBrandId(int brandid)
        {
            try
            {
                var data = productrepository.GetProductByBrand(brandid).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error {e.Message}" });
            }
        }


        [HttpPut]
        [Route("updateproduct")]
        public HttpResponseMessage UpdateProduct([FromBody] ProductViewModel model)
        {
            try
            {
                var data = productrepository.UpdateProduct(model);
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

        [HttpPost]
        [Route("deleteorder")]
        public HttpResponseMessage DeleteOrder (ProductViewModel model)
        {
            try
            {
                var data = productrepository.DeleteOrder(model);
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = "The Order deleted successfully" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was error deleting the order {e.Message}" });
            }
        }
    }
}
