using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Api_Consume.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Api_Consume.Controllers
{
    public class ExchangeController : Controller
    {

        //List<ExchangeViewModel> exchanges = new List<ExchangeViewModel>();

        public async Task <IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
                Headers =
    {
        { "X-RapidAPI-Key", "7b0d4abea1msh4dec3d00dd13811p1f84aejsnfeba52edf051" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var exchanges = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                return View(exchanges.exchange_rates.ToList());


            }
        }

 
    }
}
