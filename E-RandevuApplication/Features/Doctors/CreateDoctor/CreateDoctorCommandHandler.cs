using AutoMapper;
using E_RandevuDomain.Entities;
using E_RandevuDomain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Doctors.CreateDoctor;

internal sealed class CreateDoctorCommandHandler (
    IDoctorRepository doctorRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper): IRequestHandler<CreateDoctorCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
       Doctor doctor =mapper.Map<Doctor>(request);
        await doctorRepository.AddAsync(doctor,cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Doctor created successfully";
    }
}
