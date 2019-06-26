using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        //IEnumerable instead of List makes our code more loosely coupled.
        //because in the future, if we get memberships with another collection type
        //this code will still work, as long as it implements IEnumerbale.
        //But List<> would have worked too.
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}