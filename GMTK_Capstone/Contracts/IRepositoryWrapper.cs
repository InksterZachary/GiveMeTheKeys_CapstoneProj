using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Contracts
{
    public interface IRepositoryWrapper
    {
        IAddressRepository Address { get; }
        IApplicationDetailsRepository ApplicationDetails { get; }
        ILandlordRepository Landlord { get; }
        ILandlordsRenterRepository LandlordsRenter { get; }
        IListingRepository Listing { get; }
        IRenterRepository Renter { get; }
        IReviewRepository Review { get; }
        IWorkOrderRepository WorkOrder { get; }
        IImageRepository Image { get; }
        void Save();
    }
}
