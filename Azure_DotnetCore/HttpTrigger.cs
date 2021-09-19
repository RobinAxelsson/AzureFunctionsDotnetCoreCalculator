using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;

namespace Function
{
    public static class HttpTrigger
    {
        public static readonly string DefaultResponse = "Add queryparameters ?a=1&b=3 to use the calculator.";
        public static string responseCalculation(string decimalA, string decimalB) => $"{Convert.ToDecimal(decimalA) + Convert.ToDecimal(decimalB)}";
        public static string ValidateInput(string input)
        {
            if (input.ToList().Aggregate(0, (acc, c) => char.IsDigit(c) ? acc + 1 : acc + 0) == 0) return null; //At least one digit
            if (input.ToList().TrueForAll(c => !char.IsDigit(c) && c != '.' && c != '-')) return null; // Only digits and "." or "-"
            if (input.ToList().Aggregate(0, (acc, x) => x == '.' ? acc + 1 : acc + 0) > 1) return null; //Only one "."
            if (input.ToList().Aggregate(0, (acc, x) => x == '-' ? acc + 1 : acc + 0) > 1) return null; //Only one "-"
            if (input.ToList().Aggregate(0, (acc, x) => x == '-' ? acc + 1 : acc + 0) == 1 && input[0] != '-') return null; //Only one "-"
            return input;
        }
        [FunctionName("HttpTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string a = req.Query["a"];
            string b = req.Query["b"];
            //If sum is null response is default message, else the calculation is returned
            string responseMessage = ValidateInput(a) != null && ValidateInput(b) != null ? responseCalculation(a, b) : DefaultResponse;
            return new OkObjectResult(responseMessage);
        }
    }
}
