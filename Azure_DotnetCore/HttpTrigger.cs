using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Function
{
    public static class HttpTrigger
    {
        public static readonly string DefaultResponse = "Add query parameters ?a=1&b=3 to use the calculator.";
        public static string responseCalculation(string decimalA, string decimalB) => $"{Convert.ToDecimal(decimalA) + Convert.ToDecimal(decimalB)}";
        public static string ValidateInput(string input)
        {
            if (input == null) return null;
            if (input.Length > 20) return null; //Check for decimal type overflow
            if (input.ToList().Aggregate(0, (acc, c) => char.IsDigit(c) ? acc + 1 : acc + 0) == 0) return null; //At least one digit
            if (input.ToList().TrueForAll(c => !char.IsDigit(c) && c != '.' && c != '-')) return null; // Only digits and "." or "-"
            if (input.ToList().Aggregate(0, (acc, x) => x == '.' ? acc + 1 : acc + 0) > 1) return null; //Only one "."
            if (input.ToList().Aggregate(0, (acc, x) => x == '.' ? acc + 1 : acc + 0) == 1 && input[0] == '.') return null; //dot is not first
            if (input.ToList().Aggregate(0, (acc, x) => x == '-' ? acc + 1 : acc + 0) > 1) return null; //Only one "-"
            if (input.ToList().Aggregate(0, (acc, x) => x == '-' ? acc + 1 : acc + 0) == 1 && input[0] != '-') return null; //"-" is first
            return input;
        }
        [FunctionName("HttpTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("------------------NEW REQUEST-----------------");
            log.LogInformation("C# HTTP trigger function processed a request.");

            string a = req.Query["a"];
            string b = req.Query["b"];

            //If any value is null, response is the default message with status code 400.
            //else the calculation is returned with status code 200.
            string response = ValidateInput(a) != null && ValidateInput(b) != null ? responseCalculation(a, b) : null;
            if (response != null) return new OkObjectResult(response);
            return new BadRequestObjectResult(DefaultResponse);
        }
    }
}
