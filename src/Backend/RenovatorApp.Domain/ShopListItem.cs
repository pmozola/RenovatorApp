using System.Collections.ObjectModel;

namespace RenovatorApp.Domain;

public class ShopListItem : Entity
{
    private ShopListItem()
    {
    }

    public static ShopListItem Create(string name, string? description, string? url)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }
        
        return new ShopListItem { Name = name, Description = description, Url = url };
    }

    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    
    public string? Url { get; private set; }

    public List<BoughtInformation> BoughtInformations { get; init; } = new();

    public void AddBoughtInformation(BoughtInformation boughtInformation) => 
        BoughtInformations.Add(boughtInformation);
}

public class BoughtInformation : Entity
{
    private BoughtInformation()
    {
    }

    public static BoughtInformation Create(DateTimeOffset date, double totalPrice, double quantity, string? url = null)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(totalPrice);
        ArgumentOutOfRangeException.ThrowIfNegative(quantity);

        return new BoughtInformation { Date = date, Quantity = quantity, TotalPrice = totalPrice, Url = url };
    }
    

    public required DateTimeOffset Date { get; init; }
    public required double TotalPrice { get; init; }
    public required double Quantity { get; init; }
    public string? Url { get; init; }
}