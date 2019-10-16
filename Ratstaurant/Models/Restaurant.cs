using System.Collections.Generic;

namespace Ratstaurant.Models
{
    public class Restaurant
    {
        public int ID {get; set;}
        public string Name {get; set;}
        public string Address {get; set;}
        public int CuisineID {get; set;}
        public virtual Cuisine Cuisine {get; set;}
        public int Rat {get; set;}
        public int Price {get; set;}
    }
}