using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using SetifyFinal.Dtos;
using SetifyFinal.Models;

namespace SetifyFinal.Controllers.Api
{
    public class ArtistsController : ApiController
    {
        private ApplicationDbContext _context;

        public ArtistsController()
        {
            _context = new ApplicationDbContext();
        }

        
        //Have got a artists query and applied a where clause to only get avail methods!
        public IEnumerable<ArtistDto> GetArtist(string query = null)
        {
            var artistsQuery = _context.Artists
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                artistsQuery = artistsQuery.Where(m => m.Name.Contains(query));

            return artistsQuery
                .ToList()
                .Select(Mapper.Map<Artist, ArtistDto>);
        }

        //Applies a "mapper" object instead is listing out every attribute. Then it gets applied to the vars in the "Artist DTO" class and away you go!
        public IHttpActionResult GetArtist(int id)
        {
            var artist = _context.Artists.SingleOrDefault(c => c.Id == id);

            if (artist == null)
                return NotFound();

            return Ok(Mapper.Map<Artist, ArtistDto>(artist));
        }

        //Create
        [HttpPost]
        public IHttpActionResult CreateArtist(ArtistDto artistDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var artist = Mapper.Map <ArtistDto, Artist>(artistDto);
            _context.Artists.Add(artist);
            _context.SaveChanges();

            artistDto.Id = artist.Id;
            return Created(new Uri(Request.RequestUri + "/" + artist.Id), artistDto);
        }

        //Update
        [HttpPut]
        public IHttpActionResult UpdateArtist(int id, ArtistDto artistDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var artistInDb = _context.Artists.SingleOrDefault(c => c.Id == id);

            if (artistInDb == null)
                return NotFound();

            Mapper.Map(artistDto, artistInDb);

            _context.SaveChanges();

            return Ok();
        }

        //Deletion of course
        [HttpDelete]
        public IHttpActionResult DeleteArtist(int id)
        {
            var artistInDb = _context.Artists.SingleOrDefault(c => c.Id == id);

            if (artistInDb == null)
                return NotFound();

            _context.Artists.Remove(artistInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}