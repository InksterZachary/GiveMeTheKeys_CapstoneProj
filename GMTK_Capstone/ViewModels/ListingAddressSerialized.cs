using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.ViewModels
{
    public class ListingAddressSerialized
    {
        public List<Listing> Listings {get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
