using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string TheReview { get; set; }
        [ForeignKey("Landlord")]
        public int LandlordId { get; set; }
        public Landlord Landlord { get; set; }
        [ForeignKey("Renter")]
        public int RenterId { get; set; }
        public Renter Renter { get; set; }
    }
}
