﻿using AutoMapper;
using E_RandevuDomain.Entities;
using E_RandevuDomain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Doctors.UpdateDoctor;

internal sealed class UpdateDoctorCommandHandler(
    IDoctorRepository doctorRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateDoctorCommand, Result<string>>
{
   
    public async Task<Result<string>> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
       Doctor? doctor = await doctorRepository.GetByExpressionWithTrackingAsync(p=>p.Id == request.Id, cancellationToken);
        if (doctor is null)
        {
            return Result<string>.Failure("Doctor not found");
        }
        mapper.Map(request, doctor);
        doctorRepository.Update(doctor);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Doctor updated successfully";
    }
}
