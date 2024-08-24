using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Roles.RoleSync;

public sealed record RoleSyncCommand():IRequest<Result<string>>;

