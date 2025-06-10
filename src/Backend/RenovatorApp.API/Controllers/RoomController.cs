using MediatR;
using Microsoft.AspNetCore.Mvc;
using RenovatorApp.Application.Handlers.Commands.Rooms.Add;
using RenovatorApp.Application.Handlers.Queries.Rooms;

namespace RenovatorApp.API.Controllers;

//[Authorize]
[ApiController]
[Route("[controller]")]
public class RoomController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public Task<List<GetRoomsQueryResponse>> Get() =>
        mediator.Send(new GetRoomsQuery());

    [HttpPost]
    public Task<int> Post(AddRoomCommand request) =>
        mediator.Send(request);
}