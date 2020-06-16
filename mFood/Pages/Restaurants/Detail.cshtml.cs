using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public Restaurant restaurant { get; set; }
        private readonly IRestaurantData restaurantData;

        [TempData]
        public String Message { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;

        }
        public IActionResult OnGet(int restaurantId)
        {
            restaurant = restaurantData.GetById(restaurantId);
            if (restaurant == null)
                return RedirectToPage("./NotFound");
            return Page();
        }
    }
}