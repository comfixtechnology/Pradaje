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
    [RoutePrefix("api/v1/staff")]
    public class StaffController : ApiController
    { 
       
        IStaffRepositorys staffrepository;
        public StaffController (IStaffRepositorys staffrepository)
        {
            this.staffrepository = staffrepository;
        }

        [HttpPost]
        [Route("createstaff")]
        public HttpResponseMessage AddStatff([FromBody] StaffViewModel model)
        {
            try
            {
                var data = staffrepository.AddStaff(model);
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
        [Route("getallstaff")]
        public HttpResponseMessage GetStaff()
        {
            try
            {
                var data = staffrepository.GetAllStaff();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("getstaff/{id}")]
        public HttpResponseMessage GetStaffById(int id)
        {
            try
            {
                var data = staffrepository.GetStaffById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error {e.Message}" });
            }
        }


        [HttpPut]
        [Route("updatestaff")]
        public HttpResponseMessage UpdateStaff([FromBody] StaffViewModel model)
        {
            try
            {
                var data = staffrepository.UpdateStaff(model);
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
