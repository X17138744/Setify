using System.Collections.Generic;

namespace SetifyFinal.Models
{
    public class CustomerFormViewModel
    {

        //All i need is way to iterate over the membership types and IEnumerable does this
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}