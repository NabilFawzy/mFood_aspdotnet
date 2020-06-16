using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        [BindProperty (SupportsGet =true)]
        public string searchTerm { get; set; }
        public String message { get; set; }
        public String messageGlobal { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }
        public ListModel(IConfiguration config,
        IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
            this.searchTerm = "";
        }
        public void OnGet(/*string searchTerm*/)
        {
            message = "Hello , World";
            messageGlobal = config["globalMessage"];
            Restaurants = restaurantData.getRestaurantByName(searchTerm);
            //this.searchTerm = searchTerm;
        }
    }
}