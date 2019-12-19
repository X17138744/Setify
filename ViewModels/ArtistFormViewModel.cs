using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetifyFinal.Models
{
    public class ArtistFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Artist Artist { get; set; }
        public string Title
        {
            get
            {
                if (Artist != null && Artist.Id != 0)
                    return "Edit Artist";

                return "New Artist";
            }
        }
    }
}