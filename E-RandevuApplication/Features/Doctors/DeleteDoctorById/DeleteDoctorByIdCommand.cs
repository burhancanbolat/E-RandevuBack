using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Doctors.DeleteDoctorById;

public sealed record DeleteDoctorByIdCommand(
 Guid Id   ):IRequest<Result<string>>;
