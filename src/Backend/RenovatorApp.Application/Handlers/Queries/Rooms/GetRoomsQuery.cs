using MediatR;

namespace RenovatorApp.Application.Handlers.Queries.Rooms;

public record GetRoomsQuery : IRequest<List<GetRoomsQueryResponse>>;