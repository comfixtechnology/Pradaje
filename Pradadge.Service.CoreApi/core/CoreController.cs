using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Jwt.Filters;

namespace DS.MerchantWebApi.core
{
    [JwtAuthentication]
    public class CoreController : ApiController
    {
    }
}
