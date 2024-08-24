using AutoMapper;
using E_RandevuDomain.Entities;
using E_RandevuDomain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace E_RandevuApplication.Features.Users.CreateUser;

internal sealed class CreateUserCommandHandler(
    UserManager<AppUser> userManager,
    IUserRoleRepository userRoleRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
       if(await userManager.Users.AnyAsync(x=>x.Email==request.Email))
        {

            return Result<string>.Failure("Email already exists");
        }

        if (await userManager.Users.AnyAsync(x => x.UserName == request.UserName))
        {

            return Result<string>.Failure("UserName already exists");
        }
        AppUser user =mapper.Map<AppUser>(request);
        IdentityResult result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return Result<string>.Failure(result.Errors.Select(s=>s.Description).ToList());
        }

        if (request.RoleIds.Any())
        {
            List<AppUserRole> userRoles = new();
            foreach (var roleId in request.RoleIds)
            {
                AppUserRole userRole = new()
                {
                    UserId = user.Id,
                    RoleId = roleId
                };
                userRoles.Add(userRole);
            }
            await userRoleRepository.AddRangeAsync(userRoles, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        return"User created successfully";
    }
}
