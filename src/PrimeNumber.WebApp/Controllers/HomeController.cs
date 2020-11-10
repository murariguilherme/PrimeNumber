using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PrimeNumber.Business.Models;
using PrimeNumber.WebApp.Models;

namespace PrimeNumber.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public string Uri;
        public readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<PrimeNumberViewModel>> GetPrimeNumberByIndex(int index)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetConnectionString("PrimerNumber"));

                var content = new StringContent(index.ToString(), Encoding.UTF8);
                var responseTask = await client.PostAsync($"api/PrimeNumber?index={index}", content);                


                if (responseTask.IsSuccessStatusCode)
                {
                    var resultString = await responseTask.Content.ReadAsStringAsync();                    
                    var primeNumObj = JsonConvert.DeserializeObject<PrimeNumberViewModel>(resultString);
                    return View("Index", primeNumObj);
                }
            }

            return null;
        }
    }
}
