using E_Randevu.Abstractions;
using E_RandevuApplication.Features.Patients.CreatePatient;
using E_RandevuApplication.Features.Patients.DeletePatientById;
using E_RandevuApplication.Features.Patients.GetAllPatient;
using E_RandevuApplication.Features.Patients.UptadePatient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Randevu.Controllers;

public sealed class PatientsController:ApiController
{
    public PatientsController(IMediator mediator):base(mediator)
    {
        
    }
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllPatientQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);

    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);

    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeletePatientByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);

    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);

    }
}
