﻿using GMTK_Capstone.Contracts;
using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Data
{
    public class LandlordRepository : RepositoryBase<Landlord>, ILandlordRepository 
    {
        public LandlordRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public Landlord GetLandlord(int landlordId) => FindByCondition(c => c.LandlordId.Equals(landlordId)).SingleOrDefault();
        public Landlord GetLandlord(string landlordId) => FindByCondition(c => c.IdentityUserId.Equals(landlordId)).SingleOrDefault();
        public void CreateLandlord(Landlord landlord) => Create(landlord);
        public void EditLandlord(Landlord landlord) => Update(landlord);
        public void DeleteLandlord(Landlord landlord) => Delete(landlord);
    }
}
