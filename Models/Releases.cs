using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetifyFinal.Models
{
    public class Releases
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required] 
        public Artist Artist { get; set; }

        public DateTime DatePurchased { get; set; }

        public DateTime? DateReleased { get; set; }
    }
}