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
    [RoutePrefix("api/v1/company")]
    public class CompanyController : ApiController
    {
        

        ICompanysRepository companyrepository;
        public CompanyController (ICompanysRepository companyrepository)
        {
           
            this.companyrepository = companyrepository;
        }

        [HttpPost]
        [Route("createcompany")]
        public HttpResponseMessage AddCompany([FromBody] CompanyViewModel model)
        {
            try
            {
                // CompanyRepository br = new CompanyRepository(new PradadgeContext() );
                var data = companyrepository.AddCompany(model);
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
        [Route("getallcompany")]
        public HttpResponseMessage GetCompany ()
        {
            try
            {
                var data = companyrepository.GetCompanyDetails();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = e.Message });
            }
        }
        [HttpGet]
        [Route("getcompany")]
        public HttpResponseMessage GetCompanyId()
        {
            try
            {
                var data = companyrepository.GetCompanyById(1).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error {e.Message}" });
            }
        }


        [HttpGet]
        [Route("getcompany/{id}")]
        public HttpResponseMessage GetCompanyId(int id)
        {
            try
            {
                var data = companyrepository.GetCompanyById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = $"Error {e.Message}" });
            }
        }


        [HttpPut]
        [Route("updatecompany")]
        public HttpResponseMessage UpdateCompany([FromBody] CompanyViewModel model)
        {
            try
            {
                var data = companyrepository.UpdateCompanyDetails(model);
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
