using DEKODE.AttendMe.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEKODE.AttendMe.Api.Model.Relationships
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder
                .HasOne(o => o.Organisation)
                .WithMany(s => s.StaffMembers)
                .HasForeignKey(a => a.OrganisationId)
                .IsRequired();
        }
    }
}