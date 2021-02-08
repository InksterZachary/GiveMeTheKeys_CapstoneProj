using GMTK_Capstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMTK_Capstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<ApplicationDetails> ApplicationsDetails { get; set; }
        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<LandlordsRenter> LandlordsRenters { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<Image> Images { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Landlord",
                NormalizedName = "LANDLORD"
            },
            new IdentityRole
            {
                Name = "Renter",
                NormalizedName = "RENTER"
            });
        }
    }
}
