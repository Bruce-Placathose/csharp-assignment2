using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace csharp_assignment2.Controllers
{
    [ApiController]
    [Route("api/J2")]
    public class Q3Controller : ControllerBase
    {
        
        [HttpGet(template:"ChilliPeppers/{Ingredients}")]
        // [Consumes("application/x-www-form-urlencoded")]
        public int GetTotalScolville([FromQuery] string Ingredients)
        {
            Dictionary<string, int> chilliChart = new Dictionary<string, int>
            {
                {"Poblano", 1500},
                {"Mirasol", 6000},
                {"Serrano", 15500},
                {"Cayenne", 40000},
                {"Thai", 75000},
                {"Habanero", 125000}

            };

            int totalScolvilleUnit = 0;

            string[] pepperArray = Ingredients.Split(',');

            foreach (var pepper in pepperArray)
            {
                if (chilliChart.ContainsKey(pepper.Trim()))
                {
                    totalScolvilleUnit += chilliChart[pepper.Trim()];
                }
            }
            return totalScolvilleUnit;
        }
    }
}