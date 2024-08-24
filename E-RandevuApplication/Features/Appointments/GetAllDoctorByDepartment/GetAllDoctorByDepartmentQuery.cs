using E_RandevuDomain.Entities;
using MediatR;
using System.Reflection.Metadata.Ecma335;
using TS.Result;

namespace E_RandevuApplication.Features.Appointments.GetAllDoctorsByDepartment;

public sealed record GetAllDoctorByDepartmentQuery(
    int DepartmentValue):IRequest<Result<List<Doctor>>> ;
