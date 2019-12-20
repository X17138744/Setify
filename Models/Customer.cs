using System;
using System.ComponentModel.DataAnnotations;

namespace SetifyFinal.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }
        

        public byte MembershipTypeId { get; set; }

        //validation feature
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}