using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.ViewModels
{
    public class RenterAddressViewModel
    {
        public string FirstName {get;set;}
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsVerified { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        public bool HasPets { get; set; }
        public bool IsSmoker { get; set; }
        public bool HasCriminalBackground { get; set; }
        public bool HasEviction { get; set; }
        public bool HasOpenUtilities { get; set; }
        public bool HasOnTimePaymentHistory { get; set; }
        public bool HasOpenCollectionsAccount { get; set; }
        public int YearsAtCurrentJob { get; set; }
        public int AnnualIncome { get; set; }
    }
}
