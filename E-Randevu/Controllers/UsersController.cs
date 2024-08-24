using E_Randevu.Abstractions;
using E_RandevuApplication.Features.Doctors.CreateDoctor;
using E_RandevuApplication.Features.Doctors.DeleteDoctorById;
using E_RandevuApplication.Features.Doctors.GetAllDoctor;
using E_RandevuApplication.Features.Doctors.UpdateDoctor;
using E_RandevuApplication.Features.Users.CreateUser;
using E_RandevuApplication.Features.Users.DeleteUserById;
using E_RandevuApplication.Features.Users.GetAllRolesForUsers;
using E_RandevuApplication.Features.Users.GetAllUsers;
using E_RandevuApplication.Features.Users.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Randevu.Controllers;

public sealed class UsersController :ApiController 
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);

    }

    [HttpPost]
    public async Task<IActionResult> GetAllRoles(GetAllRolesForUsersQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);

    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);

    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);

    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);

    }

}
