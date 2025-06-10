using MediatR;

namespace RenovatorApp.Application.Handlers.Commands.Rooms.Add;

public record AddRoomCommand(string Name, string Description, int? Elevation) : IRequest<int>;