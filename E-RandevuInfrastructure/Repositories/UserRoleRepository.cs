using E_RandevuDomain.Entities;
using E_RandevuDomain.Repositories;
using E_RandevuInfrastructure.Context;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace E_RandevuInfrastructure.Repositories;

internal sealed class UserRoleRepository : Repository<AppUserRole, ApplicationDbContext>, IUserRoleRepository
{
    public UserRoleRepository(ApplicationDbContext context) : base(context)
    {
    }
}
