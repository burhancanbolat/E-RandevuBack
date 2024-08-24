using E_RandevuDomain.Entities;
using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Appointments.GetPatientByIdentityNumber;

public sealed record GetPatientByIdentityNumberQuery(
    string IdentityNumber):IRequest<Result<Patient>>;

