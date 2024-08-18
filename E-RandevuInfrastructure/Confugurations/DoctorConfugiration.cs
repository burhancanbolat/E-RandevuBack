using E_RandevuDomain.Entities;
using E_RandevuDomain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_RandevuInfrastructure.Confugurations;

internal sealed class DoctorConfugiration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.Property(p => p.FirstName).HasColumnType("varchar(50)");
        builder.Property(p => p.LastName).HasColumnType("varchar(50)");
        //builder.HasIndex(p => p.FirstName).IsUnique();
        //builder.HasIndex(p => p.LastName).IsUnique();
        builder.Property(p=>p.Department).HasConversion(v=>v.Value , v=>DepartmentEnum.FromValue(v))
            .HasColumnName("Department");

    }
}
