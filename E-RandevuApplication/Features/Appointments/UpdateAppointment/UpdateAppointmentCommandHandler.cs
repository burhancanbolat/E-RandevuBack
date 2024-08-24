using E_RandevuDomain.Entities;
using E_RandevuDomain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Appointments.UpdateAppointment;

internal sealed class UpdateAppointmentCommandHandler(
    IAppointmentRepository appointmentRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateAppointmentCommand, Result<string>>
{
  
    public async Task<Result<string>> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        DateTime startDate = Convert.ToDateTime(request.StartDate);
        DateTime endDate = Convert.ToDateTime(request.EndDate);
     Appointment? appointment = 
            await appointmentRepository
            .GetByExpressionWithTrackingAsync(p=>p.Id==request.Id, cancellationToken);

        if (appointment is null)
        {
            return Result<string>.Failure("Appointment not found");
        }

       bool isAppointmentDateNotAvailable = await appointmentRepository
            .AnyAsync(p =>
            p.DoctorId == appointment.DoctorId &&
            ((p.StartDate < endDate && p.StartDate >= startDate)  || //Mevcut Randevunun bitişi,diğer randevunun başlangıcıyla çakışıyor
            (p.EndDate > startDate && p.EndDate <= endDate) ||  //Mevcut Randevunun başlangıcı,diğer randevunun bitişiyle çakışıyor
            (p.StartDate >= startDate && p.EndDate <= endDate) || //Mevcut Randevu, diğer randevunun içinde tamamen yer alıyor
            (p.StartDate <= startDate && p.EndDate >= endDate)), //Mevcut Randevu, diğer randevuyu tamamen kapsıyor 

            cancellationToken);

        if (isAppointmentDateNotAvailable) 
        {
        return Result<string>.Failure("Appointment date is not available");
        
        }

        appointment.StartDate = Convert.ToDateTime(request.StartDate);
        appointment.EndDate = Convert.ToDateTime(request.EndDate);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Appointment updated successfull";
    }
}

    

