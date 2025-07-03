using MediatR;
using RenovatorApp.Database;
using RenovatorApp.Domain;

namespace RenovatorApp.Application.Handlers.Commands.ShopList.NewItem;

public record AddNewShopListItemCommand(string Name, string Description, string Url)
    : IRequest<int>;

public class AddNewShopListItemCommandHandler(RenovatorDbContext dbContext)
    : IRequestHandler<AddNewShopListItemCommand, int>
{
    public async Task<int> Handle(
        AddNewShopListItemCommand request,
        CancellationToken cancellationToken)
    {
        var entity = ShopListItem.Create(request.Name, request.Description, request.Url);
        await dbContext.ShopListItems.AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}