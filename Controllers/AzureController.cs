using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SetifyFinal.Models;

namespace SetifyFinal.Controllers
{
    public class AzureController : DbContext
    {
        public AzureController() : base("AzureController")
        {

        }

        public DbSet<Azure> AzureId { get; set; }
    }
}
