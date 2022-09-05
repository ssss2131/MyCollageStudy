using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiService.Polly;

//using ApiService.Models;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        // private readonly ClientPolicy _clientPolicy;
        private readonly IHttpClientFactory _httpClientFactory;
        public RequestController(/*ClientPolicy clientPolicy,*/IHttpClientFactory clientFactory)
        {
            // _clientPolicy = clientPolicy;           
            _httpClientFactory = clientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> GetARequest()
        {
            // var client = new HttpClient();
            var client = _httpClientFactory.CreateClient("Test");
            var response = await client.GetAsync("https://localhost:7187/Api/Response?id=50");
            // var response  = await _clientPolicy.ImmediateHttpRetry.ExecuteAsync(
            //     async ()=>{
            //       return   await client.GetAsync("https://localhost:7187/Api/Response?id=20");
            //     }
            // );
            //  var response  = await _clientPolicy.LinearHttpRetry.ExecuteAsync(
            //     async ()=>{
            //       return   await client.GetAsync("https://localhost:7187/Api/Response?id=20");
            //     }
            // );
            // var response  = await _clientPolicy.ExponentialHttpRetry.ExecuteAsync(
            //     async ()=>{
            //         return   await client.GetAsync("https://localhost:7187/Api/Response?id=20");
            //     }
            // );
            if(response.IsSuccessStatusCode)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError);

        }

      
    }
}
