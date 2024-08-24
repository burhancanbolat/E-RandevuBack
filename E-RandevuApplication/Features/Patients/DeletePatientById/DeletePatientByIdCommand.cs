using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Patients.DeletePatientById;

public sealed record DeletePatientByIdCommand(Guid Id): IRequest<Result<string>>;
