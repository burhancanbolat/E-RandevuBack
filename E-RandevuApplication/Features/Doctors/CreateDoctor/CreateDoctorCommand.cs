using E_RandevuDomain.Enums;
using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Doctors.CreateDoctor;

public sealed record CreateDoctorCommand(

    string FirstName,
    string LastName,
    int Department):IRequest<Result<string>>;
