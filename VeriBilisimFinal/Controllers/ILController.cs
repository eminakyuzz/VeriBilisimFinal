using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeriBilisimFinal.Data;
using VeriBilisimFinal.Models;

namespace VeriBilisimFinal.Controllers
{
    public class ILController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ILController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<IL> ilList = _db.ILs;
            return View(ilList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IL il)
        {
            if (ModelState.IsValid)
            {
                _db.ILs.Add(il);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(il);

        }


        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ILs.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(IL obj)
        {
            if (ModelState.IsValid)
            {
                _db.ILs.Update(obj);
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
            var obj = _db.ILs.Find(id);
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
            var obj = _db.ILs.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.ILs.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
