using GMTK_Capstone.ActionFilters;
using GMTK_Capstone.Contracts;
using GMTK_Capstone.Models;
using GMTK_Capstone.ViewModels;
using GMTK_Capstone.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace GMTK_Capstone.Controllers
{
    public class LandlordsController : Controller
    {
        private IRepositoryWrapper _repo;
        private readonly IWebHostEnvironment webHostEnvironment;
        public LandlordsController(IRepositoryWrapper repo, IWebHostEnvironment hostEnvironment)
        {
            _repo = repo;
            webHostEnvironment = hostEnvironment;
        }
        public ActionResult Index(ListingAddressSerialized theVM)
        {
            //ApiKey.apiKey; - REMEMBER TO ADD TO GITIGNORE FILE
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var landlord = _repo.Landlord.GetLandlord(userId);
            if (landlord == null)
            {
                return RedirectToAction("Create");
            }
            if (_repo.Listing.GetAllListings(landlord.LandlordId).Count() == 0)
            {
                return RedirectToAction("CreateListing");
            }
            var allListings = _repo.Listing.GetAllListings(landlord.LandlordId).Include("Address").ToList();
            var allAddresses = _repo.Address.GetAllAddress(landlord.LandlordId).ToList();
            theVM.Addresses = allAddresses;
            theVM.Listings = allListings;
            theVM.FirstName = landlord.FirstName;
            theVM.LastName = landlord.LastName;
            theVM.CompanyName = landlord.CompanyName;
            return View(theVM);
        }
        //GET
        public ActionResult MyProperties()
        {
            ListingAddressViewModel myListings = new ListingAddressViewModel();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Landlord theLandlord = _repo.Landlord.GetLandlord(userId);
            myListings.Listings = _repo.Listing.GetAllListings(theLandlord.LandlordId).ToList();
            return View(myListings); 
        }
        // GET: LandlordsController/Details/5
        public ActionResult Details() 
        {
            return View();
        }

        // GET: LandlordsController/Create
        public ActionResult Create()
        {
            ViewData["states"] = new List<string> { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS",
                "KY", "LA", "ME", "MD", "MA", "MI","MN", "MS", "MO","MT", "NE", "NV","NH", "NJ", "NM","NY", "NC", "ND","OH", "OK", "OR","PA", "RI", "SC","SD",
                "TN", "TX","UT", "VT", "VA","WA", "WV", "WI","WY" };
            return View(new LandlordAddressViewModel());
        }

        // POST: LandlordsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LandlordAddressViewModel theVM) 
        {
            //Image newImage = new Image();
            Address newAddress = new Address();
            Landlord newLandlord = new Landlord();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            newLandlord.IdentityUserId = userId;
            //_repo.Image.CreateImage(newImage);
            _repo.Landlord.CreateLandlord(newLandlord);
            newLandlord.IdentityUserId = userId;
            newLandlord.FirstName = theVM.FirstName;
            newLandlord.LastName = theVM.LastName;
            newLandlord.CompanyName = theVM.CompanyName;
            newLandlord.Email = theVM.Email;
            newLandlord.PhoneNumber = theVM.PhoneNumber;
            newLandlord.Address = newAddress;
            newAddress.StreetAddress = theVM.StreetAddress;
            newAddress.City = theVM.City;
            newAddress.State = theVM.State;
            newAddress.Zipcode = int.Parse(theVM.ZipCode);
            //newImage.ProfileImage = theVM.ProfileImage;
            _repo.Save();
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //GET
        public ActionResult CreateListing()
        {
            ViewData["homeTypes"] = new List<string> { "House", "Apartment", "Townhome" };
            return View(new ListingAddressViewModel());
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateListing(ListingAddressViewModel theListing)//, IFormFile Image)
        {
            string uniqueFileName = UploadedFile(theListing);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Landlord landlord = _repo.Landlord.GetLandlord(userId);
            Listing newListing = new Listing();
            Address listingAddress = new Address();
            Image thisImage = new Image();
            _repo.Image.Create(thisImage);
            _repo.Listing.CreateListing(newListing);

            thisImage.Listing = newListing;
            thisImage.ListingId = newListing.ListingId;
            thisImage.MainImage = uniqueFileName;
            newListing.ListingMainPhoto = uniqueFileName;
            newListing.LandlordId = landlord.LandlordId;
            newListing.ListingName = theListing.ListingName;
            newListing.Address = listingAddress;
            newListing.Address.StreetAddress = theListing.StreetAddress;
            newListing.Address.City = theListing.City;
            newListing.Address.State = theListing.State;
            newListing.Address.Zipcode = int.Parse(theListing.Zipcode);
            newListing.SerializedAddress = AddressToJSON(listingAddress);
            newListing.HomeType = theListing.HomeType;
            newListing.PricePoint = theListing.PricePoint;
            newListing.AvailabilityDate = theListing.AvailabilityDate;
            newListing.LengthOfTerm = theListing.LengthOfTerm;
            newListing.Amenities = theListing.Amenities;
            newListing.DealActive = theListing.DealActive;
            newListing.IsSmoker = theListing.IsSmoker;
            newListing.HasPet = theListing.HasPet;
            newListing.UtilitiesIncluded = theListing.UtilitiesIncluded;
            newListing.GoodCreditRequired = theListing.GoodCreditRequired;
            newListing.IsRented = theListing.IsRented;
            _repo.Save();
            try
            {
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e);
            }
        }
        private string UploadedFile(ListingAddressViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                model.ProfileImage.CopyTo(fileStream);
            }
            return uniqueFileName;
        }
        // GET: LandlordsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LandlordsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LandlordsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LandlordsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public string AddressToJSON(Address address)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(address);
            return JSONString;
        }
    }
}
