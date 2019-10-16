using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ratstaurant.Models;

namespace Ratstaurant.Controllers
{
    public class HomeController : Controller
    {

        private readonly RatstaurantContext _db;

        public HomeController(RatstaurantContext db)
        {
            _db = db;
        }

       [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost("/")]
        public ActionResult DoesThisMatter(string search)
        {
            List<Restaurant> model = _db.Restaurants.Include(restaurants => restaurants.Cuisine).ToList();
            Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.Name == search);
            return View("Search", thisRestaurant);
        }
    }
}
