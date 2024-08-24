using E_RandevuDomain.Entities;
using E_RandevuDomain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace E_RandevuApplication.Features.Appointments.GetAllAppointments;

internal sealed class GetAllAppointmentsByDoctorIdQueryHandler(
    IAppointmentRepository appointmentRepository) : IRequestHandler<GetAllAppointmentsByDoctorIdQuery, 
    Result<List<GetAllAppointmentsByDoctorIdQueryResponse>>>
{
  
    public async Task<Result<List<GetAllAppointmentsByDoctorIdQueryResponse>>> Handle(GetAllAppointmentsByDoctorIdQuery request, CancellationToken cancellationToken)
    {
        List<Appointment> appointments = await appointmentRepository
            .Where(p => p.DoctorId == request.DoctorId)
            .Include(p => p.Patient)
            .ToListAsync(cancellationToken);

        List<GetAllAppointmentsByDoctorIdQueryResponse> response =
            appointments.Select(p => 
            new GetAllAppointmentsByDoctorIdQueryResponse(
                p.Id,
                p.StartDate,
                p.EndDate,
            p.Patient!.FullName,
            p.Patient))
            .ToList();
        return response;
    }
}