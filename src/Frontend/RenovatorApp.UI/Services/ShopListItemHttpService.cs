using System.Net.Http.Json;

namespace RenovatorApp.UI.Services;

public class ShopListItemHttpService
{
    private static readonly string BASE_URL = "http://localhost:60881/";

    public async Task<List<GetShopListResponse>> Get()
    {
        try
        {
            HttpClient Client = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) };

            string url = BASE_URL + "ShoppingList";
            var response = await Client.GetFromJsonAsync<List<GetShopListResponse>>(url);
            return response;
           
        }
        catch (Exception exception)
        {
            Console.WriteLine(BASE_URL + "GetShopListResponse");
            Console.WriteLine(exception.Message);
            throw;
        }
    }
}
public record GetShopListResponse(string Name, string? Description, string? Url, double TotalMoneySpend, int BoughtTimes);
