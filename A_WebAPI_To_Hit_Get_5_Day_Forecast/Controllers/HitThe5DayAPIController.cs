using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using A_WebAPI_To_Hit_Get_5_Day_Forecast.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace A_WebAPI_To_Hit_Get_5_Day_Forecast.Controllers
{
    [Route("api/HitThe5DayAPI")]
    [ApiController]
    public class HitThe5DayAPIController : ControllerBase
    {
        public const string MyAPI = "https://localhost:44317";
        IHelper _helper;

        public HitThe5DayAPIController(IHelper helper)
        {
            _helper = helper;
        }

        [Route("{input}")]
        public async Task<ActionResult> Input(string input)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(MyAPI);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var isValidZip = _helper.IsValidZip(input);
                    var isValidCity = _helper.IsValidCity(input);

                    var response = new HttpResponseMessage();

                    if (isValidZip || isValidCity)
                        response = await client.GetAsync($"/api/weather/{input}");

                    response.EnsureSuccessStatusCode();

                    var weatherXML_Doc = await response.Content.ReadAsStringAsync();

                    return Ok(weatherXML_Doc);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }



    }
}