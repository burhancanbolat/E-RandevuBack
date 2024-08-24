using AutoMapper;
using E_RandevuDomain.Entities;
using E_RandevuDomain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace E_RandevuApplication.Features.Users.UpdateUser;

internal sealed class UpdateUserCommandHandler(
    UserManager<AppUser> userManager,
    IUserRoleRepository userRoleRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateUserCommand, Result<string>>
{

    public async Task<Result<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByIdAsync(request.Id.ToString());
        if (user is null)
        {
            return Result<string>.Failure("User not found!");
        }

        if(user.Email!=request.Email)
        {
            if (await userManager.Users.AnyAsync(x => x.Email == request.Email))
            {

                return Result<string>.Failure("Email already exists");
            }
        }

       if(user.UserName!=request.UserName)
        {
            if (await userManager.Users.AnyAsync(x => x.UserName == request.UserName))
            {

                return Result<string>.Failure("UserName already exists");
            }
        }

      
        mapper.Map(request,user);

        IdentityResult result = await userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return Result<string>.Failure(result.Errors.Select(s => s.Description).ToList());
        }

        if (request.RoleIds.Any())
        {
            List<AppUserRole> userRoles = await userRoleRepository.Where(p=>p.UserId==user.Id).ToListAsync();
            userRoleRepository.DeleteRange(userRoles);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            userRoles = new();

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

        return "User update successfully";
    }
}