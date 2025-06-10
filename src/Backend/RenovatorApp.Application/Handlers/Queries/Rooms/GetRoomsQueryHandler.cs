using MediatR;
using Microsoft.EntityFrameworkCore;
using RenovatorApp.Database;

namespace RenovatorApp.Application.Handlers.Queries.Rooms;

public class GetRoomsQueryHandler(RenovatorDbContext context) : IRequestHandler<GetRoomsQuery, List<GetRoomsQueryResponse>>
{
    public Task<List<GetRoomsQueryResponse>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
    {
        return context
            .Rooms
            .Select(room => 
                new GetRoomsQueryResponse(
                    room.Id,
                    room.Name,
                    room.Description))
            .ToListAsync(cancellationToken);
    }
}