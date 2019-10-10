using Pradadge.Contract.DataRepositoryInterface.Setup;
using Pradadge.Data.DataRepository.Setup;
using Pradadge.Entities.Model;
using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pradadge.Service.CoreApi.Controllers
{
    [RoutePrefix("api/v1/branch")]
    public class BranchController : ApiController
    {
         
        IBranchRepository repo;
       public  BranchController(IBranchRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [Route("createbranch")]
        public HttpResponseMessage AddBranch([FromBody] BranchViewModel model)
        {

            try
            {
                var data = repo.AddBranch(model);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = model, message = "The Record has been Created Successfully" });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "there was an error in creating this message" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"there was an error creating this record {ex.Message}" });
            }
        }

        [HttpGet]
        [Route("getbranch")]
        public HttpResponseMessage GetBranch()
        {
            try
            {
                var data = repo.GetBranch();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        [Route("getbranch/{id}")]
        public HttpResponseMessage GetBranchById (int id)
        {
            try
            {
                var data = repo.GetBranchById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"error: {e.Message}" });
            }
        }

        [HttpPut]
        [Route("updatebranch")]
        public HttpResponseMessage UpdateBranch ([FromBody] BranchViewModel model)
        {
            try
            {
                var data = repo.UpdateBranch(model);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { sucess = true, result = model, message = "The Record updated successfully" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "There was an error in updating this record" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { seccess = false, message = $"There was an error in updation this record {e.Message}" });
            }
        }
    }
}
