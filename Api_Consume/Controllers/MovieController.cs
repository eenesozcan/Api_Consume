using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Api_Consume.Models;
using Newtonsoft.Json;

namespace Api_Consume.Controllers
{
    public class MovieController : Controller
    {

        List<MovieListViewModel> movies = new List<MovieListViewModel>();
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "7b0d4abea1msh4dec3d00dd13811p1f84aejsnfeba52edf051" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                movies=JsonConvert.DeserializeObject<List<MovieListViewModel>>(body);
                return View(movies);
            }
        }
    }
}
