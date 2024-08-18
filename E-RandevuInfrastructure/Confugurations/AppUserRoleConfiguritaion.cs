using E_RandevuDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_RandevuInfrastructure.Confugurations;

internal sealed class AppUserRoleConfiguritaion: IEntityTypeConfiguration<AppUserRole>
{
    public void Configure(EntityTypeBuilder<AppUserRole> builder)
    {
      
        builder.HasKey(p => new { p.UserId, p.RoleId });
    }

}
