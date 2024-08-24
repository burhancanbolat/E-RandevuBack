using E_RandevuDomain.Entities;
using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Doctors.GetAllDoctor;

public sealed record  GetAllDoctorQuery():IRequest<Result<List<Doctor>>>;
