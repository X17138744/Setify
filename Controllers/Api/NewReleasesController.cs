using System;
using System.Linq;
using System.Web.Http;
using SetifyFinal.Dtos;
using SetifyFinal.Models;

namespace SetifyFinal.Controllers.Api
{
    public class NewReleasesController : ApiController
    {
        private ApplicationDbContext _context;

        public NewReleasesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewReleases(NewReleaseDto newReleases)
        {

            var customer = _context.Customers.Single(
                c => c.Id == newReleases.CustomerId);

            //This will translate to a SQL statement to the database
            var artists = _context.Artists.Where(
                m => newReleases.ArtistIds.Contains(m.Id)).ToList();

            foreach (var artist in artists)
            {

                //Edge Cases of availability of new Releases!
                if (artist.NumberAvailable == 0)
                    return BadRequest("Album not is not available! Sorry!");
                artist.NumberAvailable--;

                var release = new Releases
                {
                    Customer = customer,
                    Artist = artist,
                    DatePurchased = DateTime.Now
                };

                _context.Releases.Add(release);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}