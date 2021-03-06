﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SetifyFinal.Models;
using SetifyFinal.ViewModels;

namespace SetifyFinal.Controllers
{
    public class ArtistController : Controller
    {
        private ApplicationDbContext _context;

        public ArtistController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageArtists))
                return View("List");

            return View("ReadOnlyList");
        }

        //Handles authorization seperately on a different class to avoid Magic Numbers
        [Authorize(Roles = RoleName.CanManageArtists)]
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new ArtistFormViewModel()
            {
                Genres = genres
            };

            return View("ArtistForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var artist = _context.Artists.SingleOrDefault(c => c.Id == id);

            if (artist == null)
                return HttpNotFound();

            var viewModel = new ArtistFormViewModel(artist)
            {
                Genres = _context.Genres.ToList()
            };

            return View("ArtistForm", viewModel);
        }


        public ActionResult Details(int id)
        {
            var artist = _context.Artists.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (artist == null)
                return HttpNotFound();

            return View(artist);

        }


        // GET: Artists/Random
        public ActionResult Random()
        {
            var artist = new Artist() { Name = "Radiohead" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomArtistViewModel()
            {
                Artist = artist,
                Customers = customers
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Artist artist)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ArtistFormViewModel(artist)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("ArtistForm", viewModel);
            }

            if (artist.Id == 0)
            {
                artist.DateAdded = DateTime.Now;
                _context.Artists.Add(artist);
            }
            else
            {
                var artistInDb = _context.Artists.Single(m => m.Id == artist.Id);
                artistInDb.Name = artist.Name;
                artistInDb.GenreId = artist.GenreId;
                artistInDb.NumberInStock = artist.NumberInStock;
                artistInDb.ReleaseDate = artist.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Artist");
        }
    }
}