using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Users.GetAllUsers;

public sealed record GetAllUsersQuery(): IRequest<Result<List<GetAllUsersQueryResponse>>>;
