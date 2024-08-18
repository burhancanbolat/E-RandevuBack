using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Auth.Login;

public sealed record LoginCommand(string UserNameorEmail, string Password):IRequest<Result<LoginCommandResponse>>;
