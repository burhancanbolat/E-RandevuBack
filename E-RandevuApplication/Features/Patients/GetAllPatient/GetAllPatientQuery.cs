using E_RandevuDomain.Entities;
using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Patients.GetAllPatient;

public sealed record GetAllPatientQuery(): IRequest<Result<List<Patient>>>;
