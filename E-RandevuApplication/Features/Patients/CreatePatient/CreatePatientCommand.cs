using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Patients.CreatePatient;

public sealed record CreatePatientCommand(
    string FirstName,
    string LastName,
    string IdentityNumber,
    string City,
    string Town,
    string FullAddress):IRequest<Result<string>>;
