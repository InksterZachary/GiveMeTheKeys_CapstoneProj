using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Contracts
{
    public interface IListingRepository : IRepositoryBase<Listing>
    {
        Listing GetListing(int listingId);
        void CreateListing(Listing listing);
        void EditListing(Listing listing);
        void DeleteListing(Listing listing);
    }
}
