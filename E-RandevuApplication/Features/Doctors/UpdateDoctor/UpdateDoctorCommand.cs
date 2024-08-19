using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Doctors.UpdateDoctor;

public sealed record UpdateDoctorCommand(
    Guid Id,
    string FirstName,
    string LastName,
    int Department):IRequest<Result<string>>;
