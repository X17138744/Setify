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

        public IEnumerable<ArtistDto> GetArtist()
        {
            return _context.Artists
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Artist, ArtistDto>);
        }

        public IHttpActionResult GetArtist(int id)
        {
            var artist = _context.Artists.SingleOrDefault(c => c.Id == id);

            if (artist == null)
                return NotFound();

            return Ok(Mapper.Map<Artist, ArtistDto>(artist));
        }

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