using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeNumber.Business.Interfaces;
using PrimeNumber.Business.Models;
using PrimeNumber.Business.ViewModel;

namespace PrimeNumber.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeNumberController : ControllerBase
    {
        private readonly IPrimeNumberService _service;

        public PrimeNumberController(IPrimeNumberService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<PrimeNumViewModel> GetNextPrimeByIndex([FromBody] int index)
        {                              
            var primeValue = await _service.Add(index);

            return primeValue;
        }
    }
}
