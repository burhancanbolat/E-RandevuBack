using E_Randevu.Abstractions;
using E_RandevuApplication.Features.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Randevu.Controllers;

[AllowAnonymous]
public sealed class AuthController :ApiController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        var response=await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
