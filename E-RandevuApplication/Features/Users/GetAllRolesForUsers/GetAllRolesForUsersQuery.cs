using E_RandevuDomain.Entities;
using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Users.GetAllRolesForUsers;

public sealed record GetAllRolesForUsersQuery():IRequest<Result<List<AppRole>>>;
