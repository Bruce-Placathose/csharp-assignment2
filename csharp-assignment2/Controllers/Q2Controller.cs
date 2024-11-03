using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace csharp_assignment2.Controllers
{
    [ApiController]
    [Route("api/J1")]
    public class Q2Controller : ControllerBase
    {
         // Question from: https://cemc.uwaterloo.ca/sites/default/files/documents/2022/2022CCCJrProblemSet.html
      
        // <summary>
        // Output the number of cupcake leftover depending on the amount of regular and small boxes
        // </summary>
        // <return>
        // An integer that represent the number of cupcake leftover
        // </return>
        // <param name="Regular">the number of regular boxes</param>
        // <param name="Small">the number of small boxes</param>
        // <example>
        // POST at 'http://localhost:5136/api/J1/cupcakeParty' Regular=3&Small=2 -> 2
        // </example>
        // <example>
        // POST at 'http://localhost:5136/api/J1/cupcakeParty' Regular=2&Small=5 -> 3
        // </example>

        [HttpPost(template:"cupcakeParty")]
        [Consumes("application/x-www-form-urlencoded")]
        public int PostCupcakeLeftover([FromForm] int Regular, [FromForm] int Small)
        {
            int totalCupCake = (Regular * 8) + (Small * 3);
            int leftOver = totalCupCake - 28;

            if (leftOver >= 0)
            {
                return leftOver;
            } else
            {
                return 0;
            }
        }
    }
}