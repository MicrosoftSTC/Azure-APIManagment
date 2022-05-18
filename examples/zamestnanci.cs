using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace API_Tutorial
{
    public static class Function1
    {
        [FunctionName("Zamestnanci")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "zamestnanci")] HttpRequest req,
            ILogger log)
        {
            // Zaznamená do konzole že se spustila funkce
            log.LogInformation("C# HTTP trigger function processed a request.");

            // Vytvoří údaje o zaměstnancích
            dynamic zamestnanci = new object[]
            {
                new { jmenoZamestnance = "Jan", plat = 26300, pozice = "Brigádník" },
                new { jmenoZamestnance = "Petr", plat = 32500, pozice = "Majitel firmy" }
            };

            // Vrátí Status200OK a informace o zaměstnancích
            return new OkObjectResult(zamestnanci);
        }
    }
}
