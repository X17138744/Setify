using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SetifyFinal.Models;

namespace SetifyFinal.ViewModels
{
    public class ArtistFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 10)]
        [Required]
        public byte? NumberInStock { get; set; }


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Album" : "New Album";
            }
        }

        public ArtistFormViewModel()
        {
            Id = 0;
        }

        public ArtistFormViewModel(Artist artist)
        {
            Id = artist.Id;
            Name = artist.Name;
            ReleaseDate = artist.ReleaseDate;
            NumberInStock = artist.NumberInStock;
            GenreId = artist.GenreId;
        }
    }
}