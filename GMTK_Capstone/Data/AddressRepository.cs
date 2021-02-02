using GMTK_Capstone.Contracts;
using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Data
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public Address GetAddress(int addressId) => FindByCondition(c => c.AddressId.Equals(addressId)).SingleOrDefault();
        public void CreateAddress(Address address) => Create(address);
        public void EditAddress(Address address) => Update(address);
        public void DeleteAddress(Address address) => Delete(address);
    }
}
