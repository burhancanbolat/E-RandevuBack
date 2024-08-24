using AutoMapper;
using E_RandevuDomain.Entities;
using E_RandevuDomain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Patients.CreatePatient;

internal class CreatePatientCommandHandler(IPatientRepository patientRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreatePatientCommand, Result<string>>
{

    public async Task<Result<string>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        if(patientRepository.Any(p=>p.IdentityNumber==request.IdentityNumber))
        {
            return Result<string>.Failure("This identity number already use");
        }
            

        Patient patient = mapper.Map<Patient>(request);
        await patientRepository.AddAsync(patient, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Patient created successfull"; ;
    }
}