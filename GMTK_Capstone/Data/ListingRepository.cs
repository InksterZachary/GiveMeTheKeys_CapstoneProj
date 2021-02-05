using GMTK_Capstone.Contracts;
using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Data
{
    public class ListingRepository : RepositoryBase<Listing>, IListingRepository
    {
        public ListingRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public Listing GetListing(int listingId) => FindByCondition(c => c.ListingId.Equals(listingId)).SingleOrDefault();
        public Listing GetListing(string listingId) => FindByCondition(c => c.ListingId.Equals(listingId)).SingleOrDefault();
        public IQueryable<Listing> GetAllListings(int landlordId) => FindByCondition(c => c.LandlordId.Equals(landlordId));
        public void CreateListing(Listing listing) => Create(listing);
        public void EditListing(Listing listing) => Update(listing);
        public void DeleteListing(Listing listing) => Delete(listing);
    }
}
