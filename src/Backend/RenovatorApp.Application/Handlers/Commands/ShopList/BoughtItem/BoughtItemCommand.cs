using MediatR;
using Microsoft.EntityFrameworkCore;
using RenovatorApp.Database;
using RenovatorApp.Domain;

namespace RenovatorApp.Application.Handlers.Commands.ShopList.BoughtItem;

public record BoughtItemCommand(
    int ShopListItemId, 
    DateTimeOffset Date,
    double TotalPrice, 
    double Quantity, 
    string? Url) : IRequest;

public class BoughtItemCommandHandler(RenovatorDbContext dbContext) : IRequestHandler<BoughtItemCommand>
{
    public async  Task Handle(BoughtItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.ShopListItems.FirstOrDefaultAsync(x => x.Id == request.ShopListItemId, cancellationToken);
        if (entity == null) 
            throw new NotFoundException($"{nameof(ShopListItem)} with id: {request.ShopListItemId} not found");
     
        entity.AddBoughtInformation(
            BoughtInformation.Create(request.Date, request.TotalPrice, request.Quantity, request.Url));
        
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
    
    