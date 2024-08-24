using E_RandevuDomain.Entities;
using E_RandevuDomain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace E_RandevuApplication.Features.Patients.GetAllPatient;

internal sealed class GetAlPatientQueryHandler(
    IPatientRepository patientRepository) : IRequestHandler<GetAllPatientQuery, Result<List<Patient>>>
{

    public async Task<Result<List<Patient>>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
    {
        List<Patient> patients = 
            await patientRepository
            .GetAll()
            .OrderBy(p => p.FirstName)
            .ToListAsync(cancellationToken);
        return patients;


    }
}