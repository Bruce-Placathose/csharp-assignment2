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