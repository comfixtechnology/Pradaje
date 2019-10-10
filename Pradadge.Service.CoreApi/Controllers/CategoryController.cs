
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
    [RoutePrefix("api/v1/category")]
    public class CategoryController : ApiController
    {
        ICategoryRepository repo;
        public CategoryController (ICategoryRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [Route("createcategory")]
        public HttpResponseMessage CreateCategory ([FromBody] CategoryViewModel model)
        {
            try
            {
                var data = repo.AddCategory(model);
                if(data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record has been created successfully " });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "There was an error creating the record" });
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was an error creating the record{e.Message}" });
            }
        }

        [HttpGet]
        [Route("getallcategory")]
        public HttpResponseMessage GetCategory()
        {
            try
            {
                var data = repo.GetCategory();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("getcategory/{id}")]
        public HttpResponseMessage GetCategoryById(int id)
        {
            try
            {
                var data = repo.GetCategoryById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception ee)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error: {ee.Message}" });
            }
        }

        [HttpPut]
        [Route("updatecategory")]
        public HttpResponseMessage UpdateCategory([FromBody] CategoryViewModel model)
        {
            try
            {
                var data = repo.UpdateCategory(model);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The record updated successfully" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "There was an error updating the record" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"There was an error updating the record {ex.Message}" });
            }
        }

    }
}

