using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Models
{
    public class Renter
    {
        [Key]
        public int RenterId { get; set; }
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsVerified { get; set; }
        public bool HasApplied { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int TraitMatch { get; set; }
        //a renter will select a listing to apply for it and that this listingid will be set equal to the listingId
        public int ListingId { get; set; }
        public string ProfileImage { get; set; }
        public ApplicationDetails ApplicationDetails { get; set; }

    }
}
