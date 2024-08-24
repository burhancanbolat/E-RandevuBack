using E_RandevuDomain.Entities;

namespace E_RandevuApplication.Features.Appointments.GetAllAppointments;

public sealed record GetAllAppointmentsByDoctorIdQueryResponse(
    Guid Id,
    DateTime StartDate,
    DateTime EndDate,
    string Title,
    Patient Patient);
