﻿// <auto-generated />
using System;
using GMTK_Capstone.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GMTK_Capstone.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GMTK_Capstone.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Zipcode")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("GMTK_Capstone.Models.ApplicationDetails", b =>
                {
                    b.Property<int>("ApplicationDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnnualIncome")
                        .HasColumnType("int");

                    b.Property<bool>("HasCriminalBackground")
                        .HasColumnType("bit");

                    b.Property<bool>("HasEviction")
                        .HasColumnType("bit");

                    b.Property<bool>("HasOnTimePaymentHistory")
                        .HasColumnType("bit");

                    b.Property<bool>("HasOpenCollectionsAccount")
                        .HasColumnType("bit");

                    b.Property<bool>("HasOpenUtilities")
                        .HasColumnType("bit");

                    b.Property<bool>("HasPets")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSmoke")
                        .HasColumnType("bit");

                    b.Property<int>("YearsAtCurrentJob")
                        .HasColumnType("int");

                    b.HasKey("ApplicationDetailsId");

                    b.ToTable("ApplicationsDetails");
                });

            modelBuilder.Entity("GMTK_Capstone.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ListingId")
                        .HasColumnType("int");

                    b.Property<string>("MainImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageId");

                    b.HasIndex("ListingId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("GMTK_Capstone.Models.Landlord", b =>
                {
                    b.Property<int>("LandlordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LandlordId");

                    b.HasIndex("AddressId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Landlords");
                });

            modelBuilder.Entity("GMTK_Capstone.Models.LandlordsRenter", b =>
                {
                    b.Property<int>("LandlordsRenterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LandlordId")
                        .HasColumnType("int");

                    b.Property<int>("RenterId")
                        .HasColumnType("int");

                    b.HasKey("LandlordsRenterId");

                    b.HasIndex("LandlordId");

                    b.HasIndex("RenterId");

                    b.ToTable("LandlordsRenters");
                });

            modelBuilder.Entity("GMTK_Capstone.Models.Listing", b =>
                {
                    b.Property<int>("ListingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Amenities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AvailabilityDate")
                        .HasColumnType("int");

                    b.Property<int>("Baths")
                        .HasColumnType("int");

                    b.Property<int>("Beds")
                        .HasColumnType("int");

                    b.Property<bool>("DealActive")
                        .HasColumnType("bit");

                    b.Property<bool>("GoodCreditRequired")
                        .HasColumnType("bit");

                    b.Property<bool>("HasPet")
                        .HasColumnType("bit");

                    b.Property<string>("HomeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRented")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSmoker")
                        .HasColumnType("bit");

                    b.Property<int?>("LandlordId")
                        .HasColumnType("int");

                    b.Property<int?>("LengthOfTerm")
                        .HasColumnType("int");

                    b.Property<int?>("ListingId1")
                        .HasColumnType("int");

                    b.Property<string>("ListingMainPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ListingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PricePoint")
                        .HasColumnType("int");

                    b.Property<string>("SerializedAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SqareFootage")
                        .HasColumnType("int");

                    b.Property<bool>("UtilitiesIncluded")
                        .HasColumnType("bit");

                    b.HasKey("ListingId");

                    b.HasIndex("AddressId");

                    b.HasIndex("LandlordId");

                    b.HasIndex("ListingId1");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("GMTK_Capstone.Models.Renter", b =>
                {
                    b.Property<int>("RenterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("ApplicationDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RenterId");

                    b.HasIndex("AddressId");

                    b.HasIndex("ApplicationDetailsId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Renters");
                });

            modelBuilder.Entity("GMTK_Capstone.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LandlordId")
                        .HasColumnType("int");

                    b.Property<int>("RenterId")
                        .HasColumnType("int");

                    b.Property<string>("TheReview")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewId");

                    b.HasIndex("LandlordId");

                    b.HasIndex("RenterId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("GMTK_Capstone.Models.WorkOrder", b =>
                {
                    b.Property<int>("WorkOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("ListingId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkOrderId");

                    b.HasIndex("ListingId");

                    b.ToTable("WorkOrders");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "1b5d6d78-407b-45bf-b707-e2a021a228b5",
                            ConcurrencyStamp = "4be0182c-2b0e-4671-bb00-6e350ad3742d",
                            Name = "Landlord",
                            NormalizedName = "LANDLORD"
                        },
                        new
                        {
                            Id = "dda579b0-84d7-4401-973b-4f8fc3b44995",
                            ConcurrencyStamp = "82eb89e1-1eac-4b8b-8710-8554b0cb4028",
                            Name = "Renter",
                            NormalizedName = "RENTER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GMTK_Capstone.Models.Image", b =>
                {
                    b.HasOne("GMTK_Capstone.Models.Listing", "Listing")
                        .WithMany()
                        .HasForeignKey("ListingId");
                });

            modelBuilder.Entity("GMTK_Capstone.Models.Landlord", b =>
                {
                    b.HasOne("GMTK_Capstone.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("GMTK_Capstone.Models.LandlordsRenter", b =>
                {
                    b.HasOne("GMTK_Capstone.Models.Landlord", "Landlord")
                        .WithMany()
                        .HasForeignKey("LandlordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GMTK_Capstone.Models.Renter", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GMTK_Capstone.Models.Listing", b =>
                {
                    b.HasOne("GMTK_Capstone.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("GMTK_Capstone.Models.Landlord", "Landlord")
                        .WithMany()
                        .HasForeignKey("LandlordId");

                    b.HasOne("GMTK_Capstone.Models.Listing", null)
                        .WithMany("Listings")
                        .HasForeignKey("ListingId1");
                });

            modelBuilder.Entity("GMTK_Capstone.Models.Renter", b =>
                {
                    b.HasOne("GMTK_Capstone.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GMTK_Capstone.Models.ApplicationDetails", "ApplicationDetails")
                        .WithMany()
                        .HasForeignKey("ApplicationDetailsId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("GMTK_Capstone.Models.Review", b =>
                {
                    b.HasOne("GMTK_Capstone.Models.Landlord", "Landlord")
                        .WithMany()
                        .HasForeignKey("LandlordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GMTK_Capstone.Models.Renter", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GMTK_Capstone.Models.WorkOrder", b =>
                {
                    b.HasOne("GMTK_Capstone.Models.Listing", "Listing")
                        .WithMany()
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
