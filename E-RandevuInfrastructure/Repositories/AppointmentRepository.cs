using E_RandevuDomain.Entities;
using E_RandevuDomain.Repositories;
using E_RandevuInfrastructure.Context;
using GenericRepository;

namespace E_RandevuInfrastructure.Repositories;

internal sealed class AppointmentRepository : Repository<Appointment, ApplicationDbContext>, IAppointmentRepository
{
    public AppointmentRepository(ApplicationDbContext context) : base(context)
    {

    }
}
