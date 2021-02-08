using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.ViewModels
{
    public class ListingPhotosViewModel
    {
        public List<Listing> Listings { get; set; }
        public Landlord Landlord { get; set; }
    }
}
