using MediatR;
using RenovatorApp.Database;
using RenovatorApp.Domain;

namespace RenovatorApp.Application.Handlers.Commands.Rooms.Add;

public class AddRoomCommandHandler(RenovatorDbContext context) : IRequestHandler<AddRoomCommand, int>
{
    public async Task<int> Handle(AddRoomCommand request, CancellationToken cancellationToken)
    {
        var newRoom = Room.Create(request.Name, request.Description, request.Elevation);
        
        await context.Rooms.AddAsync(newRoom, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newRoom.Id;
    }
}