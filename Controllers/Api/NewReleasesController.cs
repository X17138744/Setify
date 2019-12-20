using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SetifyFinal.Dtos;

namespace SetifyFinal.Controllers.Api
{
    public class NewReleasesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult CreateNewReleases(NewReleaseDto newRelease)
        {
            throw new NotImplementedException();
        }
    }
}
