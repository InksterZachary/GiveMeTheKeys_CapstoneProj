using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Models
{
    public class ApplicationDetails
    {
        [Key]
        public int ApplicationDetailsId { get; set; }
        public bool HasPets { get; set; }
        public bool IsSmoke { get; set; }
        public bool HasCriminalBackground { get; set; }
        public bool HasEviction { get; set; }
        public bool HasOpenUtilities { get; set; }
        public bool HasOnTimePaymentHistory { get; set; }
        public bool HasOpenCollectionsAccount { get; set; }
        public int YearsAtCurrentJob { get; set; }
        public int AnnualIncome { get; set; }
    }
}
