﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_Ung_Vien.Areas.Identity.Data;
using QL_Ung_Vien.Models;

namespace QL_Ung_Vien.Controllers
{
    public class HRController : Controller
    {
        ApplicationDbContext db;
        public HRController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.HRs.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HR hr)
        {
            for (int i = 1; i <= db.HRs.Count() + 1; i++)
            {
                if (db.HRs.Find(i) == null)
                {
                    hr.hRID = i;
                    break;
                }
            }

            db.HRs.Add(hr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var hr = db.HRs.Find(id);
            return View(hr);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HR hr)
        {
            var h = db.HRs.Find(hr.hRID);

            h.firstName = hr.firstName;
            h.lastName = hr.lastName;
            h.email = hr.email;
            h.phoneNumber = hr.phoneNumber;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            return View(db.HRs.Find(id));
        }

        public IActionResult Delete(int id)
        {
            var hr = db.HRs.Find(id);
            db.HRs.Remove(hr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
