using AutoMapper;
using E_RandevuApplication.Features.Doctors.CreateDoctor;
using E_RandevuApplication.Features.Doctors.UpdateDoctor;
using E_RandevuDomain.Entities;
using E_RandevuDomain.Enums;

namespace E_RandevuApplication.Mapping;

public sealed class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<CreateDoctorCommand, Doctor>().ForMember(member => member.Department, options =>
        {
            options.MapFrom(map =>DepartmentEnum.FromValue(map.Department));
        });
        CreateMap<UpdateDoctorCommand, Doctor>().ForMember(member => member.Department, options =>
        {
            options.MapFrom(map => DepartmentEnum.FromValue(map.Department));
        });
    }
}
