using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.AspNetCore.Http;

namespace GMTK_Capstone.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [ForeignKey("Listing")]
        public int? ListingId { get; set; }
        public Listing Listing { get; set; }
        public string MainImage { get; set; }
        public string ProfileImage { get; set; }
    }
}
