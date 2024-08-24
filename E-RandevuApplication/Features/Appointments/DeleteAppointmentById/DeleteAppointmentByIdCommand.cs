using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Appointments.DeleteAppointmentById;

public sealed record DeleteAppointmentByIdCommand(
    Guid Id):IRequest<Result<string>>;
