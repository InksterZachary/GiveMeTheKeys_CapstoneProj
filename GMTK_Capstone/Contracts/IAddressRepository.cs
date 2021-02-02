using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Contracts
{
    public interface IAddressRepository : IRepositoryBase<Address>
    {
        Address GetAddress(int addressId);
        void CreateAddress(Address address);
        void EditAddress(Address address);
        void DeleteAddress(Address address);
    }
}
