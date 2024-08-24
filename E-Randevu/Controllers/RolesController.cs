using E_Randevu.Abstractions;
using E_RandevuApplication.Features.Roles.RoleSync;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Randevu.Controllers;

public sealed class RolesController:ApiController
{
    public RolesController(IMediator mediator) : base(mediator)
    {
        
    }

    [HttpPost]
    public async Task<IActionResult> Sync(RoleSyncCommand request,CancellationToken cancellationToken)
    {
        var response= await _mediator.Send(request,cancellationToken);

        return StatusCode(response.StatusCode, response);
    }

}
