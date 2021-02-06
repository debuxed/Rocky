using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        // Created the private instance of ApplicationDbContext
        public readonly ApplicationDbContext _db;

        // Using Dependency Injection to injest the data to private _db object
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            // Retrieve all the categories from DB
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        // GET: Create category
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid)
            {
                // We can use the _db object to pass the object
                _db.Category.Add(obj);

                // The database changes are reflected once we save the changes
                _db.SaveChanges();

                // Instead of returing to view, we can return to the display
                // The "Index" action is present in the same controller
                // So we need not specify the controller name.
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        // GET: Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Find the category with specified id.
            // Note: Find just accepts primary key as the parameter.
            var obj = _db.Category.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Edit Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                // We can use the _db object to pass the object
                _db.Category.Update(obj);

                // The database changes are reflected once we save the changes
                _db.SaveChanges();

                // Instead of returing to view, we can return to the display
                // The "Index" action is present in the same controller
                // So we need not specify the controller name.
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        // GET: Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Find the category with specified id.
            // Note: Find just accepts primary key as the parameter.
            var obj = _db.Category.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Delete Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            // Find the category with specified id.
            // Note: Find just accepts primary key as the parameter.
            var obj = _db.Category.Find(id);
            
            if(id == null)
            {
                return NotFound();
            }
            // We can use the _db object to pass the object
            _db.Category.Remove(obj);

            // The database changes are reflected once we save the changes
            _db.SaveChanges();

            // Instead of returing to view, we can return to the display
            // The "Index" action is present in the same controller
            // So we need not specify the controller name.
            return RedirectToAction("Index");

        }
    }
}