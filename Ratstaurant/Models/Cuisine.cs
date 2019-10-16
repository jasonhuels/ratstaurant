using System.Collections.Generic;

namespace Ratstaurant.Models
{
    public class Cuisine
    {

        public int ID { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }

        public Cuisine()
        {
            this.Restaurants = new HashSet<Restaurant>();
        }
    }
}