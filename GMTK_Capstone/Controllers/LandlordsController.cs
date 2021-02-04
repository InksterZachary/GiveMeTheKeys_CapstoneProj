using GMTK_Capstone.ActionFilters;
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

namespace GMTK_Capstone.Controllers
{
    public class LandlordsController : Controller
    {
        private IRepositoryWrapper _repo;
        public LandlordsController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        // GET: LandlordsController
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var landlord = _repo.Landlord.GetLandlord(userId);
            if (landlord == null)
            {
                return RedirectToAction("Create");
            }
            return View(landlord);
        }

        // GET: LandlordsController/Details/5
        public ActionResult Details(int id)
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
            Address newAddress = new Address();
            Landlord newLandlord = new Landlord();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            newLandlord.IdentityUserId = userId;
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
    }
}
