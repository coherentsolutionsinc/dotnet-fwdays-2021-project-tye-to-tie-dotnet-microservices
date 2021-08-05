using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application
{
    public class WeatherWithCityClient
     {
         private readonly JsonSerializerOptions options = new()
         {
             PropertyNameCaseInsensitive = true,
             PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
         };
 
         private readonly HttpClient client;
 
         public WeatherWithCityClient(HttpClient client)
         {
             this.client = client;
         }
 
         public async Task<WeatherForecastWithCity[]> GetWeatherAsync()
         {
             var responseMessage = await this.client.GetAsync("/weatherforecast");
             var stream = await responseMessage.Content.ReadAsStreamAsync();
             return await JsonSerializer.DeserializeAsync<WeatherForecastWithCity[]>(stream, options);
         }
     }
}
