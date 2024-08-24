using E_RandevuDomain.Entities;
using E_RandevuDomain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TS.Result;

namespace E_RandevuApplication.Features.Users.GetAllUsers;

internal sealed class GetAllUsersQueryHandler(
    UserManager<AppUser> userManager,
    IUserRoleRepository userRoleRepository,
    RoleManager<AppRole> roleManager) : IRequestHandler<GetAllUsersQuery, Result<List<GetAllUsersQueryResponse>>>
{
    public async Task<Result<List<GetAllUsersQueryResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        List<AppUser> users = await userManager.Users.OrderBy(p=>p.FirstName).ToListAsync(cancellationToken);

        List<GetAllUsersQueryResponse> response =
        users.Select(p => new GetAllUsersQueryResponse()
        {

            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Email = p.Email,
            FullName=p.FullName,
            UserName = p.UserName
            
        }).ToList();

        foreach (var item in response)
        {
            List<AppUserRole> userRoles = await userRoleRepository.Where(p => p.UserId == item.Id)
                .ToListAsync(cancellationToken);

            List<Guid> stringRoles = new();
            List<string?> stringRoleNames = new();

            foreach (var userRole in userRoles)
            {
                AppRole? role= await roleManager.Roles
                    .Where(p => p.Id == userRole.RoleId)
                    .FirstOrDefaultAsync(cancellationToken);

              if(role is not null)
                {
                    stringRoles.Add(role.Id);
                    stringRoleNames.Add(role.Name);
                }
            }
            

            item.RoleIds = stringRoles;
            item.RoleNames = stringRoleNames;
        }
        return response;

    }
}
