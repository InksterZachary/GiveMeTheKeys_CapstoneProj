﻿using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Contracts
{
    public interface IRenterRepository : IRepositoryBase<Renter>
    {
        Renter GetRenter(int renterId);
        Renter GetRenter(string renterId);
        IQueryable<Renter> GetAllRenters(int listingId);
        void CreateRenter(Renter renter);
        void EditRenter(Renter renter);
        void DeleteRenter(Renter renter);
    }
}
