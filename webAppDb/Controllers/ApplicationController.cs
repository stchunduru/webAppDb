using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAppDb.Data;
using webAppDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAppDb.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly AppDbContext _dbContext;
        public ApplicationController(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public IActionResult Index()
        {
            IEnumerable<Application> list = _dbContext.Application;
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Application obj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Application.Add(obj);
                _dbContext.SaveChanges();
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
            var obj = _dbContext.Application.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _dbContext.Application.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Application obj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Application obj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Remove(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
