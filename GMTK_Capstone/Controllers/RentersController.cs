using GMTK_Capstone.Contracts;
using GMTK_Capstone.Models;
using GMTK_Capstone.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Stripe;
using Stripe.Infrastructure;
using Stripe.Checkout;
using Stripe.BillingPortal;
namespace GMTK_Capstone.Controllers
{
    public class RentersController : Controller
    {
        private IRepositoryWrapper _repo;
        public RentersController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });
            var charge = charges.Create(new ChargeCreateOptions { 
                Amount = 50,
                Description = "Verification Payment",
                Currency ="usd",
                Customer = customer.ToString()
            });

            if(charge.Status == "succeeded")
            {
                string BalanceTransactionId = charge.BalanceTransactionId;
            }
            return View();
        }
        // GET: RentersController
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var renter = _repo.Renter.GetRenter(userId);
            if (renter == null)
            {
                return RedirectToAction("Create");
            }
            return View(renter);
        }

        // GET: RentersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RentersController/Create
        public ActionResult Create()
        {
            ViewData["states"] = new List<string> { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS",
                "KY", "LA", "ME", "MD", "MA", "MI","MN", "MS", "MO","MT", "NE", "NV","NH", "NJ", "NM","NY", "NC", "ND","OH", "OK", "OR","PA", "RI", "SC","SD",
                "TN", "TX","UT", "VT", "VA","WA", "WV", "WI","WY" };
            return View(new RenterAddressViewModel());
        }

        // POST: RentersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RenterAddressViewModel theVM)
        {
            Models.Address newAddress = new Models.Address();
            Renter newRenter = new Renter();
            ApplicationDetails newApplicationDetails = new ApplicationDetails();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            newRenter.IdentityUserId = userId;
            _repo.Renter.CreateRenter(newRenter);
            newRenter.IdentityUserId = userId;
            newRenter.FirstName = theVM.FirstName;
            newRenter.LastName = theVM.LastName;
            newRenter.Email = theVM.Email;
            newRenter.PhoneNumber = theVM.PhoneNumber;
            newRenter.Address = newAddress;
            newAddress.StreetAddress = theVM.StreetAddress;
            newAddress.City = theVM.City;
            newAddress.State = theVM.State;
            newAddress.Zipcode = int.Parse(theVM.Zipcode);
            newRenter.ApplicationDetails = newApplicationDetails;
            newRenter.ApplicationDetails.AnnualIncome = theVM.AnnualIncome;
            newRenter.ApplicationDetails.YearsAtCurrentJob = theVM.YearsAtCurrentJob;
            newRenter.ApplicationDetails.IsSmoke = theVM.IsSmoker;
            newRenter.ApplicationDetails.HasPets = theVM.HasPets;
            newRenter.ApplicationDetails.HasOpenUtilities = theVM.HasOpenUtilities;
            newRenter.ApplicationDetails.HasOpenCollectionsAccount = theVM.HasOpenCollectionsAccount;
            newRenter.ApplicationDetails.HasOnTimePaymentHistory = theVM.HasOnTimePaymentHistory;
            newRenter.ApplicationDetails.HasEviction = theVM.HasEviction;
            newRenter.ApplicationDetails.HasCriminalBackground = theVM.HasCriminalBackground;
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
        public ActionResult MarketListings()
        {
            if (this.User.Identity.Name == null)
            {
                return RedirectToAction("Error", "Home");
            }
            LandlordRenterViewModel theVm = new LandlordRenterViewModel();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Renter theRenter = _repo.Renter.GetRenter(userId);
            ApplicationDetails appDeets = _repo.ApplicationDetails.GetApplicationDetails(theRenter.RenterId);
            theRenter.ApplicationDetails = appDeets;
            theRenter.HasApplied = false;
            var theListings = _repo.Listing.FindAll().ToList();
            theVm.Listings = theListings;
            theVm.Renter = theRenter;
            foreach(var item in theListings.ToList())
            {
                var landlords = _repo.Landlord.FindAll();
                foreach(var landy in landlords)
                {
                    if(item.ListingId == landy.LandlordId)
                    {
                        item.Landlord = landy;
                    }
                }
                if(theRenter.ApplicationDetails.HasPets == true && item.HasPet == false)
                {
                    theListings.Remove(item);
                }
                if(theRenter.ApplicationDetails.IsSmoke == true && item.IsSmoker == false)
                {
                    theListings.Remove(item);
                }
                if (theRenter.HasApplied)
                {
                    theVm.AppliedRenters.Add(theRenter);
                }
            }
            return View(theVm);
        }
        public ActionResult HasApplied(int iD)
        {
            var theRenter = _repo.Renter.GetRenter(iD);
            return View(theRenter);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HasApplied(Renter renter)
        {
            renter.HasApplied = true;
            return View();
        }
        // GET: RentersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RentersController/Edit/5
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

        // GET: RentersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RentersController/Delete/5
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
    }
}
