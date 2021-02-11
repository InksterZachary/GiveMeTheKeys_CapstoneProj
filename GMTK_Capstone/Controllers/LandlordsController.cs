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
        private readonly IRepositoryWrapper _repo;
        private readonly IWebHostEnvironment webHostEnvironment;
        public LandlordsController(IRepositoryWrapper repo, IWebHostEnvironment hostEnvironment)
        {
            _repo = repo;
            webHostEnvironment = hostEnvironment;
        }
        public ActionResult Index()
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
            var allListingNames = new List<string>();
            List<int> prices = new List<int>();
            foreach(var item in allListings)
            {
                //prices.Add(allListings.Count(x => x.PricePoint == item.PricePoint));
                allListingNames.Add(item.ListingName);
                prices.Add(item.PricePoint);
            }
            var rep = prices;
            ViewBag.AGES = allListingNames;
            ViewBag.REP = prices.ToList();

            return View(landlord);
        }
        //get
        public ActionResult CreateWorkOrder(int iD)
        {
            var theListing = _repo.Listing.GetListing(iD);
            ListingWorkOrderViewModel theVm = new ListingWorkOrderViewModel();
            theVm.Listing = theListing;
            theVm.ListingId = theListing.ListingId;
            theVm.Listing.WorkOrders = theListing.WorkOrders;
            return View(theVm);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWorkOrder(ListingWorkOrderViewModel theVM) //somewhere the List<WorkOrder is becoming null. Workorder still tied to listing though
        {
            WorkOrder wo = new WorkOrder();
            theVM.Listing = _repo.Listing.GetListing(theVM.ListingId);
            _repo.WorkOrder.CreateWorkOrder(wo);
            wo.Name = theVM.Name;
            wo.Description = theVM.Description;
            wo.IsCompleted = theVM.IsCompleted;
            wo.ListingId = theVM.ListingId;
            _repo.Save();
            return RedirectToAction("MyProperties");
        }
        public ActionResult ViewRenterApplicants(int iD)
        {
            if (this.User.Identity.Name == null)
            {
                return RedirectToAction("Error", "Home");
            }
            LandlordRenterViewModel myApplicants = new LandlordRenterViewModel();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Landlord theLandlord = _repo.Landlord.GetLandlord(userId);
            Listing thisListing = _repo.Listing.GetListing(iD);
            List<Renter> allListingApplicants = _repo.Renter.GetAllRenters(thisListing.ListingId).ToList();
            foreach(var renter in allListingApplicants)
            {
                myApplicants.AppliedRenters.Add(renter);
                if(renter.IsVerified == false && thisListing.HasVerification == true)
                {
                    myApplicants.AppliedRenters.Remove(renter);
                }
                if(renter.ApplicationDetails.AnnualIncome/12 >= thisListing.PricePoint * 2)
                {
                    renter.TraitMatch++;
                }
                if (renter.ApplicationDetails.HasPets == thisListing.HasPet)
                {
                    renter.TraitMatch++;
                }
                if (renter.ApplicationDetails.IsSmoke == thisListing.IsSmoker)
                {
                    renter.TraitMatch++;
                }
                if (renter.ApplicationDetails.YearsAtCurrentJob >= 1)
                {
                    renter.TraitMatch++;
                }
                if (renter.ApplicationDetails.HasOpenCollectionsAccount == false && thisListing.GoodCreditRequired == true)
                {
                    renter.TraitMatch++;
                }
                if (renter.ApplicationDetails.HasOpenUtilities == false && thisListing.GoodCreditRequired)
                {
                    renter.TraitMatch++;
                }
                if (renter.ApplicationDetails.HasOnTimePaymentHistory)
                {
                    renter.TraitMatch++;
                }
                if (renter.ApplicationDetails.HasEviction == false && thisListing.GoodCreditRequired == true)
                {
                    renter.TraitMatch++;
                }
                myApplicants.AppliedRenters.OrderByDescending(x => x.TraitMatch);
            }
            myApplicants.ListingId = iD;
            myApplicants.Listing = thisListing;
            myApplicants.ListingName = thisListing.ListingName;
            myApplicants.HomeType = thisListing.HomeType;
            myApplicants.PricePoint = thisListing.PricePoint;
            myApplicants.DealActive = thisListing.DealActive;
            myApplicants.IsSmoker = thisListing.IsSmoker;
            myApplicants.HasPet = thisListing.HasPet;
            myApplicants.AvailabilityDate = thisListing.AvailabilityDate;
            myApplicants.LengthOfTerm = thisListing.LengthOfTerm;
            myApplicants.UtilitiesIncluded = thisListing.UtilitiesIncluded;
            myApplicants.GoodCreditRequired = thisListing.GoodCreditRequired;
            myApplicants.Amenities = thisListing.Amenities;
            myApplicants.IsRented = thisListing.IsRented;
            myApplicants.Beds = thisListing.Beds;
            myApplicants.Baths = thisListing.Baths;
            myApplicants.SqareFootage = thisListing.SqareFootage;
            myApplicants.HasVerification = thisListing.HasVerification;
            myApplicants.SerializedAddress = thisListing.SerializedAddress;
            myApplicants.ListingMainPhoto = thisListing.ListingMainPhoto;
            myApplicants.ProfileImage = thisListing.ProfileImage;
            return View(myApplicants);
        }
        public ActionResult MarketingTips()
        {
            return View();
        }
        public ActionResult MyProperties()
        {
            if(this.User.Identity.Name == null)
            {
                return RedirectToAction("Error","Home");
            }
            ListingAddressViewModel myListings = new ListingAddressViewModel();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Landlord theLandlord = _repo.Landlord.GetLandlord(userId);
            myListings.Listings = _repo.Listing.GetAllListings(theLandlord.LandlordId).ToList();
            myListings.Landlord = theLandlord;
            foreach(var item in myListings.Listings)
            {
                item.WorkOrders = _repo.WorkOrder.GetAllWorkOrders(item.ListingId).ToList();
            }
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
            string uniqueFileName = UploadedFile(theVM);
            Image newImage = new Image();
            Address newAddress = new Address();
            Landlord newLandlord = new Landlord();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            newLandlord.IdentityUserId = userId;
            _repo.Image.CreateImage(newImage);
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
            newImage.ProfileImage = uniqueFileName;
            newLandlord.ProfileImage = uniqueFileName;
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
            ViewData["states"] = new List<string> { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS",
                "KY", "LA", "ME", "MD", "MA", "MI","MN", "MS", "MO","MT", "NE", "NV","NH", "NJ", "NM","NY", "NC", "ND","OH", "OK", "OR","PA", "RI", "SC","SD",
                "TN", "TX","UT", "VT", "VA","WA", "WV", "WI","WY" };
            return View(new ListingAddressViewModel());
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateListing(ListingAddressViewModel theListing)
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
            newListing.Landlord = landlord;
            newListing.ListingName = theListing.ListingName;
            listingAddress.StreetAddress = theListing.StreetAddress;
            listingAddress.City = theListing.City;
            listingAddress.State = theListing.State;
            listingAddress.Zipcode = int.Parse(theListing.Zipcode);
            newListing.Address = listingAddress;
            newListing.SerializedAddress = AddressToJSON(listingAddress);
            newListing.HomeType = theListing.HomeType;
            newListing.PricePoint = theListing.PricePoint;
            newListing.AvailabilityDate = theListing.AvailabilityDate;
            newListing.LengthOfTerm = theListing.LengthOfTerm;
            newListing.Beds = theListing.NumberOfBeds;
            newListing.Baths= theListing.NumberOfBaths;
            newListing.SqareFootage = theListing.SquareFeet;
            newListing.Amenities = theListing.Amenities;
            newListing.DealActive = theListing.DealActive;
            newListing.IsSmoker = theListing.IsSmoker;
            newListing.HasPet = theListing.HasPet;
            newListing.UtilitiesIncluded = theListing.UtilitiesIncluded;
            newListing.GoodCreditRequired = theListing.GoodCreditRequired;
            newListing.IsRented = theListing.IsRented;
            newListing.WorkOrders = new List<WorkOrder>();
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
        private string UploadedFile(LandlordAddressViewModel model)
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
        private string UploadedFileElsewhere(Listing model) //come back to this (Probably a problem in the view) not allowing me to click on the upload file form
        {
            string uniqueFileName = null;
            var stream = new MemoryStream(model.ProfileImage);
            IFormFile file = new FormFile(stream, 0, stream.Length, "file", "profileImage");
            if (stream != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(fileStream);
            }
            return uniqueFileName;
        }
        // GET: LandlordsController/Edit/5
        public ActionResult Edit(int iD)
        {
            Listing thisListing = _repo.Listing.GetListing(iD);
            return View(thisListing);
        }

        // POST: LandlordsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Listing theListing) //EYES COME TO THIS LINE
        {
            try
            {
                //string uniqueFileName = UploadedFile(theListing);
                var randVar = theListing.ListingMainPhoto; //theListing.ListingMainPhoto is showing in the db but doesnt pass through here?
                _repo.Listing.Update(theListing);
                theListing.ListingMainPhoto = randVar;
                _repo.Save();
                return RedirectToAction(nameof(MyProperties));
            }
            catch (Exception e)
            {
                return View(e);
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
