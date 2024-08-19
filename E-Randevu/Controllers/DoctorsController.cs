using E_Randevu.Abstractions;
using E_RandevuApplication.Features.Doctors.CreateDoctor;
using E_RandevuApplication.Features.Doctors.DeleteDoctorById;
using E_RandevuApplication.Features.Doctors.GetAllDoctor;
using E_RandevuApplication.Features.Doctors.UpdateDoctor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Randevu.Controllers;

public sealed class DoctorsController : ApiController
{
    public DoctorsController(IMediator mediator) : base(mediator)
    {
    }

    
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllDoctorQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);

    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);

    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteDoctorByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);

    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);

    }
}
