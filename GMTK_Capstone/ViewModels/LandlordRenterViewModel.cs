using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.ViewModels
{
    public class LandlordRenterViewModel
    {
        //List of 
        public List<Renter> AppliedRenters { get; set; }
        public Renter MyRenter { get; set; }
        //Listing for all this data upon click asp-route-id="@item.ListingId"
        //in this view asp-hidden blah blah blah
        public int ListingId { get; set; }
        public Listing Listing { get; set; }
        //Renter contact info
        //public int RenterPhoneNumber { get; set; }
        //public string RenterEmail { get; set; }
        //Listing Details Below
        public string ListingName { get; set; }
        public string HomeType { get; set; }
        public int PricePoint { get; set; }
        public bool DealActive { get; set; }
        public bool IsSmoker { get; set; }
        public bool HasPet { get; set; }
        public int AvailabilityDate { get; set; }
        public int? LengthOfTerm { get; set; }
        public bool UtilitiesIncluded { get; set; }
        public bool GoodCreditRequired { get; set; }
        public string Amenities { get; set; }
        public bool IsRented { get; set; }
        public int Beds { get; set; }
        public int Baths { get; set; }
        public int SqareFootage { get; set; }
        public bool HasVerification { get; set; }
        public string SerializedAddress { get; set; }
        public string ListingMainPhoto { get; set; }
        public byte[] ProfileImage { get; set; }
        ////AppDetails Below
        //public bool HasPets { get; set; }
        //public bool IsSmoke { get; set; }
        //public bool HasCriminalBackground { get; set; }
        //public bool HasEviction { get; set; }
        //public bool HasOpenUtilities { get; set; }
        //public bool HasOnTimePaymentHistory { get; set; }
        //public bool HasOpenCollectionsAccount { get; set; }
        //public int YearsAtCurrentJob { get; set; }
        //public int AnnualIncome { get; set; }
        //public bool HasApplied { get; set; }
    }
}
