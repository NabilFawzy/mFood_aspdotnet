using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public class OdeToFoodDBContext: DbContext
    {
       public OdeToFoodDBContext(DbContextOptions<OdeToFoodDBContext>Options)
            :base(Options)
        {

        }
        public DbSet<Restaurant> Restaurants { set; get; }
    }
}
