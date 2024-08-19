using E_RandevuDomain.Entities;
using E_RandevuDomain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace E_RandevuApplication.Features.Doctors.DeleteDoctorById;

internal sealed class DeleteDoctorByIdCommandHandler (
    IDoctorRepository doctorRepository,
    IUnitOfWork unitOfWork): IRequestHandler<DeleteDoctorByIdCommand, Result<string>>
{
    public  async Task<Result<string>> Handle(DeleteDoctorByIdCommand request, CancellationToken cancellationToken)
    {
        Doctor? doctor = await doctorRepository.GetByExpressionAsync(p=>p.Id == request.Id,cancellationToken);
        if (doctor is null)
        {
            return Result<string>.Failure("Doctor not found");
        }
        doctorRepository.Delete(doctor);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Doctor delete is successfully";
    }
}   
