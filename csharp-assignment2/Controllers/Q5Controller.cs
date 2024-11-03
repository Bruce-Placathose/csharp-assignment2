using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;

namespace csharp_assignment2.Controllers
{
    [ApiController]
    [Route("api/J3")]
    public class Q5Controller : ControllerBase
    {
         // <summary>
        // Output an array or list of secret instruction
        // </summary>
        // <return>
        // A list with all the correct instruction and numbers
        // </return>
        // <param name="secretCode">A string with 5 figure numbers seperated by a forward slash</param>
        // <example>
        // GET 'http://localhost:5136/api/J3/secretInstructions?secretCode=12392/92310/02312' -> ["left 392","left 310","right 312"]
        // </example>
        // <example>
        // GET 'http://localhost:5136/api/J3/secretInstructions?secretCode=12392/00000/02312' -> ["left 392","left 000","right 312"]
        // </example>


        [HttpGet(template:"secretInstructions")]

        public List<string> GetThisThing([FromQuery] string secretCode)
        {
            string [] secretCodeArray = secretCode.Split("/");
            
            // string [] message = [];
            List<string> message = new List<string>();

            // Loop through secretCodeArray
            for(int i = 0; i < secretCodeArray.Length; i++)
            {
                if(secretCodeArray[i] != "99999")
                {
                    string firstTwoChar = secretCodeArray[i].Substring(0,2);
                    string lastThreeChar = secretCodeArray[i].Substring(2,3);

                    int firstNumber = int.Parse(firstTwoChar[0].ToString());
                    int secondNumber = int.Parse(firstTwoChar[1].ToString());
                    int sum = firstNumber + secondNumber;
                    // Console.WriteLine(firstTwoChar);

                    // Console.WriteLine(firstNumber + secondNumber);

                    if (sum % 2 == 0 && sum != 0)
                    {
                        // right
                        message.Add("right " + lastThreeChar);
                    } 
                    else if (sum % 2 != 0)
                    {
                        // return same as previous
                        message.Add("left " + lastThreeChar);
                        
                    } 
                    else if (sum == 0)
                    {
                        string prevMessage = message[^1].Substring(0, 5);
                        message.Add(prevMessage + " " + lastThreeChar);
                    }
                }
                
            }

            return message;
        }
    }
}