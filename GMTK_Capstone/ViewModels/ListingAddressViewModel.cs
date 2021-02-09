using GMTK_Capstone.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.ViewModels
{
    public class ListingAddressViewModel
    {
        public string ListingName { get; set; }
        public string StreetAddress { get; set; }
        public Landlord Landlord { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string HomeType { get; set; }
        public int PricePoint { get; set; }
        public int AvailabilityDate { get; set; }
        public int? LengthOfTerm { get; set; }
        public string Amenities { get; set; }
        public int NumberOfBeds { get; set; }
        public int NumberOfBaths { get; set; }
        public int SquareFeet { get; set; }
        public bool DealActive { get; set; }
        public bool IsSmoker { get; set; }
        public bool HasPet { get; set; }
        public bool UtilitiesIncluded { get; set; }
        public bool GoodCreditRequired { get; set; }
        public bool IsRented { get; set; }
        public IEnumerable<Listing> Listings { get; set; }
        public Image Image { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
