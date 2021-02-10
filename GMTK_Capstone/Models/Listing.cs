using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Models
{
    public class Listing
    {
        [Key]
        public int ListingId { get; set; }
        public Landlord Landlord { get; set; }
        public Address Address { get; set; }
        public List<WorkOrder> WorkOrders {get;set; }
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
        public List<Listing> Listings { get; set; }
        public byte[] ProfileImage { get; set; }
    }
}
