using Microsoft.AspNetCore.Mvc;
using Ratstaurant.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Ratstaurant.Controllers
{
    public class CuisinesController : Controller
    {
        private readonly RatstaurantContext _db;

        public CuisinesController(RatstaurantContext db)
        {
        _db = db;
        }

        public ActionResult Index()
        {
        List<Cuisine> model = _db.Cuisine.ToList();
        return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cuisine cuisine)
        {
            _db.Cuisine.Add(cuisine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Cuisine thisCuisine = _db.Cuisine.FirstOrDefault(cuisine => cuisine.ID == id);
            return View(thisCuisine);
        }
        public ActionResult Edit(int id)
        {
            var thisCuisine = _db.Cuisine.FirstOrDefault(cuisine => cuisine.ID == id);
            return View(thisCuisine);
        }

        [HttpPost]
        public ActionResult Edit(Cuisine cuisine)
        {
            _db.Entry(cuisine).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisCuisine = _db.Cuisine.FirstOrDefault(cuisine => cuisine.ID == id);
            return View(thisCuisine);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisCuisine = _db.Cuisine.FirstOrDefault(cuisine => cuisine.ID == id);
            _db.Cuisine.Remove(thisCuisine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}