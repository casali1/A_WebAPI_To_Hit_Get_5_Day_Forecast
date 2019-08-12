using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace A_WebAPI_To_Hit_Get_5_Day_Forecast.Controllers
{
    [Route("api/HitThe5DayAPI")]
    [ApiController]
    public class HitThe5DayAPIController : ControllerBase
    {
        public const string MyAPI = "https://localhost:44317";

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

                    //var isValidZip = _helper.IsValidZip(input);
                    //var isValidCity = _helper.IsValidCity(input);

                    var response = new HttpResponseMessage();

                    //if (isValidZip)
                        response = await client.GetAsync($"/api/weather/{input}");

                    //if (isValidCity)
                    //    response = await client.GetAsync($"/data/2.5/forecast?q={input}&mode=xml&appid=f99e1e3ccd770a8a43db5680342edd6a&units=imperial&days=5");

                    response.EnsureSuccessStatusCode();

                    var weatherXML_Doc = await response.Content.ReadAsStringAsync();
                    //var list = _helper.RetrieveDataFromXML(weatherXML_Doc);
                    //var avgTempList = _helper.CalculateAvgTemps(list, input);

                    //return CreatedAtAction(nameof(input), avgTempList); <-------Use for POST.
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