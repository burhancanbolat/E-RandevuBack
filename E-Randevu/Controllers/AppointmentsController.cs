using E_Randevu.Abstractions;
using E_RandevuApplication.Features.Appointments.CreateAppointment;
using E_RandevuApplication.Features.Appointments.DeleteAppointmentById;
using E_RandevuApplication.Features.Appointments.GetAllAppointments;
using E_RandevuApplication.Features.Appointments.GetAllDoctorsByDepartment;
using E_RandevuApplication.Features.Appointments.GetPatientByIdentityNumber;
using E_RandevuApplication.Features.Appointments.UpdateAppointment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Randevu.Controllers;

public sealed class AppointmentsController:ApiController
{
    public AppointmentsController(IMediator mediator):base(mediator)
    {       
    }

    [HttpPost]
    public async Task<IActionResult> GetAllDoctorByDepartment(GetAllDoctorByDepartmentQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }


    [HttpPost]
    public async Task<IActionResult> GetAllByDoctorId(GetAllAppointmentsByDoctorIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetPatientByIdentityNumber(GetPatientByIdentityNumberQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteAppointmentByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
