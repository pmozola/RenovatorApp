using MediatR;
using Microsoft.EntityFrameworkCore;
using RenovatorApp.Database;

namespace RenovatorApp.Application.Handlers.Queries.ShopList;

public class GetShopListQuery : IRequest<GetShopListResponse[]>;

public record GetShopListResponse(string Name, string? Description, string? Url, double TotalMoneySpend, int BoughtTimes);

public class GetShopListQueryHandler(RenovatorDbContext dbContext)
    : IRequestHandler<GetShopListQuery, GetShopListResponse[]>
{
    public Task<GetShopListResponse[]> Handle(GetShopListQuery request, CancellationToken cancellationToken)
    {
        return dbContext.ShopListItems
            .Select(shopListItem =>
                new GetShopListResponse(
                    shopListItem.Name,
                    shopListItem.Description,
                    shopListItem.Url,
                    shopListItem.BoughtInformations.Sum(boughtInformation => boughtInformation.TotalPrice),
                    shopListItem.BoughtInformations.Count))
            .ToArrayAsync(cancellationToken);
    }
}