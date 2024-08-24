using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Appointments.GetAllAppointments;

public sealed record GetAllAppointmentsByDoctorIdQuery(
    Guid DoctorId):IRequest<Result<List<GetAllAppointmentsByDoctorIdQueryResponse>>>;
