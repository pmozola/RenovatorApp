using MediatR;
using Microsoft.AspNetCore.Mvc;
using RenovatorApp.Application.Handlers.Commands.ShopList.BoughtItem;
using RenovatorApp.Application.Handlers.Commands.ShopList.NewItem;
using RenovatorApp.Application.Handlers.Queries.ShopList;

namespace RenovatorApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ShoppingListController(ISender sender) : ControllerBase
{
    [HttpPost]
    public Task<int> Post(AddNewShopListItemCommand request) =>
        sender.Send(request);
    
    [HttpPost("bought")]
    public Task Post(BoughtItemCommand request) =>
        sender.Send(request);
    
    [HttpGet]
    public Task<GetShopListResponse[]> Get() =>
        sender.Send(new GetShopListQuery());
}