using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeriBilisimFinal.Data;
using VeriBilisimFinal.Models;

namespace VeriBilisimFinal.Controllers
{
    public class AdayController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdayController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Aday> adayList = _db.Adays;
            return View(adayList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aday per)
        {
            if (ModelState.IsValid)
            {
                _db.Adays.Add(per);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(per);

        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Adays.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Aday obj)
        {
            if (ModelState.IsValid)
            {
                _db.Adays.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Aday aday = await _db.Adays.FindAsync(id);
            _db.Remove(aday);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
