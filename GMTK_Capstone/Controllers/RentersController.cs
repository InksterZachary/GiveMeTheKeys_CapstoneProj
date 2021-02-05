﻿using GMTK_Capstone.Contracts;
using GMTK_Capstone.Models;
using GMTK_Capstone.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GMTK_Capstone.Controllers
{
    public class RentersController : Controller
    {
        private IRepositoryWrapper _repo;
        public RentersController(IRepositoryWrapper repo)
        {
            _repo = repo;
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
            Address newAddress = new Address();
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