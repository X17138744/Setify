using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetifyFinal.Dtos
{
    public class NewReleaseDto
    {
        public int CustomerId { get; set; }
        public List<int> ArtistIds { get; set; }
    }
}