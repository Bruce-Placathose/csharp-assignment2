using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace csharp_assignment2.Controllers
{
    [ApiController]
    [Route("api/J1")]
    public class Q1Controller : ControllerBase
    {
        //// <summary>
        /// count and return the total amount of points
        /// </summary>
        /// <param name="Collisions">The amount of delivered package</param>
        /// <param name="Deliveries">The amount of obstacles</param>
        /// <returns>return a number</returns>
        /// <example>
        /// POST : localhost:xx/api/J1/Delivedroid
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// POST DATA: Collisions=2&Deliveries=5
        /// -> 730
        /// </example>
        /// <example>
        /// POST : localhost:xx/api/J1/Delivedroid
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// POST DATA: Collisions=100&Deliveries=5
        /// -> -750
        /// </example>


        
        [HttpPost(template:"Deliverdroid")]
        [Consumes("application/x-www-form-urlencoded")]
        public int PostFinalScore([FromForm] int Collisions, [FromForm] int Deliveries)
        {
            int DeliveryPoints = 50 * Deliveries;
            int CollisionPointRemover = 10 * Collisions;
            int counter = DeliveryPoints - CollisionPointRemover;

            if (Deliveries > Collisions)
            {
                counter += 500;
            }

            return counter;
        }
    }
}