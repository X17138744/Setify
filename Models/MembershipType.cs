﻿using System.ComponentModel.DataAnnotations;

namespace SetifyFinal.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        
        //Refactoring of magic numbers or simple numbers example
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}