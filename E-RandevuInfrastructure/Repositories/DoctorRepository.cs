using E_RandevuDomain.Entities;
using E_RandevuDomain.Repositories;
using E_RandevuInfrastructure.Context;
using GenericRepository;

namespace E_RandevuInfrastructure.Repositories;

internal sealed class DoctorRepository : Repository<Doctor, ApplicationDbContext>, IDoctorRepository
{
    public DoctorRepository(ApplicationDbContext context) : base(context)
    {

    }
}
