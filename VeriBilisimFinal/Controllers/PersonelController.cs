using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeriBilisimFinal.Data;
using VeriBilisimFinal.Models;

namespace VeriBilisimFinal.Controllers
{
    public class PersonelController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PersonelController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Personel> perList = _db.Personels;
            return View(perList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Personel per)
        {
            if (ModelState.IsValid)
            {
                _db.Personels.Add(per);
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
            var obj = _db.Personels.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Personel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Personels.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Personels.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Personels.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Personels.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
