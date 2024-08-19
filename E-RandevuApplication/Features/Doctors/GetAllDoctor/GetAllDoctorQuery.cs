using E_RandevuDomain.Entities;
using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Doctors.GetAllDoctor;

public sealed record class GetAllDoctorQuery():IRequest<Result<List<Doctor>>>;
