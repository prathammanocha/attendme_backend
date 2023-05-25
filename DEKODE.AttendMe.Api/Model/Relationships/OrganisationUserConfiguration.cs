using DEKODE.AttendMe.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEKODE.AttendMe.Api.Model.Relationships
{
    public class OrganisationUserConfiguration : IEntityTypeConfiguration<OrganisationUser>
    {
        public void Configure(EntityTypeBuilder<OrganisationUser> builder)
        {
            builder
                .HasOne(o => o.Organisation)
                .WithMany(u => u.Users)
                .HasForeignKey(o => o.OrganisationId)
                .IsRequired();
        }
    }
}