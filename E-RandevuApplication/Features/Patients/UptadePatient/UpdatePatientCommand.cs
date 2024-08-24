using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Patients.UptadePatient;

public sealed record  UpdatePatientCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string IdentityNumber,
    string City,
    string Town,
    string FullAddress):IRequest<Result<string>>;
