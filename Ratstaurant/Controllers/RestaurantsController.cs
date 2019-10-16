using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ratstaurant.Models;

namespace Ratstaurant.Controllers
{
    public class RestaurantsController : Controller
    {
       private readonly RatstaurantContext _db;

        public RestaurantsController(RatstaurantContext db)
        {
            _db = db;
        }

        public ActionResult Index(string orderVar)
        {
            List<Restaurant> model = _db.Restaurants.Include(restaurants => restaurants.Cuisine).ToList();
           
            ViewBag.NameSortParm = String.IsNullOrEmpty(orderVar) ? "name_desc" : "";
            ViewBag.PriceSortParm = orderVar == "Price" ? "price_desc" : "Price";
            ViewBag.RatSortParm = orderVar == "Rat" ? "rat_desc" : "Rat";
            
            switch (orderVar)
            {
                case "name_desc":
                    model = model.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Price":
                    model = model.OrderBy(s => s.Price).ToList();
                    break;
                case "price_desc":
                    model = model.OrderByDescending(s => s.Price).ToList();
                    break;
                case "Rat":
                    model = model.OrderBy(s => s.Rat).ToList();
                    break;
                case "rat_desc":
                    model = model.OrderByDescending(s => s.Rat).ToList();
                    break;
                default:
                    model = model.OrderBy(s => s.Name).ToList();
                    break;
            }
            return View(model.ToList());

        }

        public ActionResult Create()
        {
            ViewBag.CuisineID = new SelectList(_db.Cuisine, "ID", "Type");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.ID == id);
            return View(thisRestaurant);
        }

        public ActionResult Edit(int id)
        {
            var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.ID == id);
            ViewBag.CuisineId = new SelectList(_db.Cuisine, "ID", "Type");
            return View(thisRestaurant);
        }

        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            _db.Entry(restaurant).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.ID == id);
            return View(thisRestaurant);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.ID == id);
            _db.Restaurants.Remove(thisRestaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}