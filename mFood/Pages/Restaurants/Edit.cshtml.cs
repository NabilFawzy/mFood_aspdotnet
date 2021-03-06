﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        public IEnumerable<SelectListItem> Cuisines { get; set; }
        [BindProperty]
        public Restaurant restaurant { get; set; }

        public EditModel(IRestaurantData restaurantData,IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                restaurant = restaurantData.GetById(restaurantId.Value);
            }

            else
            {
                restaurant = new Restaurant { };
            }
            if (restaurant == null)
                return RedirectToPage("NotFound");

            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
               
            }
            if (restaurant.Id > 0)
            {
                restaurant = restaurantData.Update(restaurant);
            }
            else
            {
                restaurant = restaurantData.Add(restaurant);
            }
            TempData["Message"] = "Restaurant Saved";
            restaurantData.commit();
            return RedirectToPage("./Detail", new { restaurantId = restaurant.Id });



        }
    }
}