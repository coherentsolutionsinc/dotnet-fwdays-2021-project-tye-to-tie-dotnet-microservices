using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application
{
    public class WeatherClient
     {
         private readonly JsonSerializerOptions options = new()
         {
             PropertyNameCaseInsensitive = true,
             PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
         };
 
         private readonly HttpClient client;
 
         public WeatherClient(HttpClient client)
         {
             this.client = client;
         }
 
         public async Task<WeatherForecast[]> GetWeatherAsync()
         {
             var responseMessage = await this.client.GetAsync("/weatherforecast");
             var stream = await responseMessage.Content.ReadAsStreamAsync();
             return await JsonSerializer.DeserializeAsync<WeatherForecast[]>(stream, options);
         }
     }
}
