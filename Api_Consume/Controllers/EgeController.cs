using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Api_Consume.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api_Consume.Controllers
{
    public class EgeController : Controller
    {
        List<EgeThinkSpeak> EgeThink = new List<EgeThinkSpeak>();
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.thingspeak.com/channels/1992652/feeds.json?api_key=PF9N79KIKF3KJNBI"),
                Headers =
    {

    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                EgeThink = JsonConvert.DeserializeObject<List<EgeThinkSpeak>>(body);
                return View(EgeThink);
            }
        }
    }
}
