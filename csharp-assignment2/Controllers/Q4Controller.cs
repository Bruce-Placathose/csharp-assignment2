using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace csharp_assignment2.Controllers
{
    [ApiController]
    [Route("api/J2")]
    public class Q4Controller : ControllerBase
    {
        // <summary>
        // Output the name of the highest bidder
        // </summary>
        // <return>
        // A string and it's the name of the highest bidder
        // </return>
        // <param name="numberOfBidders">How many bidders are there</param>
        // <param name="bidders">the bidders' name and amount they bid</param>
        // <example>
        // GET at 'http://localhost:5136/api/J2/silentAuction?numberOfBidders=3&bidders=John/600/Walter/200/Molly/700' -> Molly
        // </example>
        // <example>
        // GET at 'http://localhost:5136/api/J2/silentAuction?numberOfBidders=3&bidders=John/700/Walter/200/Molly/700' -> John
        // </example>
        // <example>
        // GET at 'http://localhost:5136/api/J2/silentAuction?numberOfBidders=3&bidders=John/100/Walter/200/Molly/100' -> Walter
        // </example>

        [HttpGet(template:"silentAuction")]

        public string GetHigherBidder( [FromQuery] int numberOfBidders, [FromQuery] string bidders)
        {
            string [] biddersArray = bidders.Split("/");
            int highestNumber = 0;
            string highestBidder = "";

            for (int i = 1; i < biddersArray.Length; i+=2)
            {
                int currentNumber = int.Parse(biddersArray[i]);

                if(currentNumber > highestNumber)
                {
                    highestNumber = currentNumber;
                    highestBidder = biddersArray[i-1];
                }
            }

            return highestBidder;

            // Debug.WriteLine("My second error message.");
        }
    }
}