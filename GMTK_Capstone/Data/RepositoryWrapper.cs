using GMTK_Capstone.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _context;
        private IAddressRepository _address;
        private IApplicationDetailsRepository _applicationDetails;
        private ILandlordRepository _landlord;
        private ILandlordsRenterRepository _landlordsRenter;
        private IListingRepository _listing;
        private IRenterRepository _renter;
        private IReviewRepository _review;
        private IWorkOrderRepository _workOrder;
        public IAddressRepository Address
        {
            get
            {
                if(_address == null)
                {
                    _address = new AddressRepository(_context);
                }
                return _address;
            }
        }
        public IApplicationDetailsRepository ApplicationDetails
        {
            get
            {
                if(_applicationDetails == null)
                {
                    _applicationDetails = new ApplicationDetailsRepository(_context);
                }
                return _applicationDetails;
            }
        }
        public ILandlordRepository Landlord
        {
            get
            {
                if(_landlord == null)
                {
                    _landlord = new LandlordRepository(_context);
                }
                return _landlord;
            }
        }
        public ILandlordsRenterRepository LandlordsRenter
        {
            get
            {
                if(_landlordsRenter == null)
                {
                    _landlordsRenter = new LandlordsRenterRepository(_context);
                }
                return _landlordsRenter;
            }
        }
        public IListingRepository Listing
        {
            get
            {
                if(_listing == null)
                {
                    _listing = new ListingRepository(_context);
                }
                return _listing;
            }
        }
        public IRenterRepository Renter
        {
            get
            {
                if(_renter == null)
                {
                    _renter = new RenterRepository(_context);
                }
                return _renter;
            }
        }
        public IReviewRepository Review
        {
            get
            {
                if(_review == null)
                {
                    _review = new ReviewRepository(_context);
                }
                return _review;
            }
        }
        public IWorkOrderRepository WorkOrder
        {
            get
            {
                if(_workOrder == null)
                {
                    _workOrder = new WorkOrderRepository(_context);
                }
                return _workOrder;
            }
        }
        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
