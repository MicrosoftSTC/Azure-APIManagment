using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace odpocetPrazdnin
{
    public static class Function1
    {
        [FunctionName("Prazdniny")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "prazdniny")] HttpRequest req,
            ILogger log)
        {
            // Zaznamená do konzole že se spustila funkce
            log.LogInformation("C# HTTP trigger function processed a request.");

            // Proměnné pro naše datumy které potřebujeme
            DateTime zacatekPrazdnin = DateTime.Parse("1/7/2022 00:00:00 AM");
            DateTime aktualniCas = DateTime.Now;

            // Vypočítá rozdíl a vrátí ho
            TimeSpan rozdil = zacatekPrazdnin - aktualniCas;
            string response = string.Format("Do začátku prázdnin zbývá {0} dní, {1} hodin, {2} minut, {3} sekund", rozdil.Days, rozdil.Hours, rozdil.Minutes, rozdil.Seconds);

            return new OkObjectResult(response);
        }
    }
}
