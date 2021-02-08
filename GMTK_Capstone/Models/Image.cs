using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public byte[] MainImage { get; set; }
        public byte[] ProfileImage { get; set; }

        [ForeignKey("Landlord")]
        public int LandlordId { get; set; }
        public Landlord Landlord { get; set; }

        [ForeignKey("Listing")]
        public int ListingId { get; set; }
        public Listing Listing { get; set; }
    }
}
