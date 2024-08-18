using E_RandevuDomain.Entities;
using E_RandevuDomain.Repositories;
using E_RandevuInfrastructure.Context;
using GenericRepository;

namespace E_RandevuInfrastructure.Repositories;

internal sealed class PatientRepository : Repository<Patient, ApplicationDbContext>, IPatientRepository
{
    public PatientRepository(ApplicationDbContext context) : base(context)
    {

    }
}