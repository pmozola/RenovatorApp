using System.Net.Http.Json;

namespace RenovatorApp.UI.Services;

public class TestHttpService
{
   
    
    private static readonly string BASE_URL = "http://localhost:5213/"; 
 
    public async Task<List<WeatherForecast>> Get()
    {
        try
        {
            HttpClient Client = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) };

            string url = BASE_URL + "WeatherForecast";
            var response = await Client.GetFromJsonAsync<List<WeatherForecast>>(url);
            return response;
           
        }
        catch (Exception exception)
        {
            Console.WriteLine(BASE_URL + "WeatherForecast");
           Console.WriteLine(exception.Message);
           throw;
        }
    }
}