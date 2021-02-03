﻿using GMTK_Capstone.Contracts;
using GMTK_Capstone.Models;
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
            repo = _repo;
        }
        // GET: LandlordsController
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Landlord landlord = _repo.Landlord.GetLandlord(userId);
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
            return View();
        }

        // POST: LandlordsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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