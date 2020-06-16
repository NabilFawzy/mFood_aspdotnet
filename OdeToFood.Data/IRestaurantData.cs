using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> getRestaurantByName(String Name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        int commit();

    }
    public class InMemoryRestaurantData : IRestaurantData
    {
       readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1,Name="pizza",Location="Egypt",Cuisine=CuisineType.Italian},
                new Restaurant{Id=2,Name="Chicken",Location="mexico",Cuisine=CuisineType.Mexican},
                 new Restaurant{Id=3,Name="meat",Location="india",Cuisine=CuisineType.Indian}
            };
        }
        public IEnumerable<Restaurant> getRestaurantByName(String Name=null)
        {
            return from r in restaurants
                   where String.IsNullOrEmpty(Name)||r.Name.ToLower().Contains( Name.ToLower())
                   orderby r.Name
                   select r;
        }
        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r=>r.Id==id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id  = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;

        }
        public int commit()
        {
            return 0;
        }
    }
}
