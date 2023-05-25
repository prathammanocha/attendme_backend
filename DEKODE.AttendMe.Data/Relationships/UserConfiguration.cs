using DEKODE.AttendMe.Data.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEKODE.AttendMe.Data.Model.Relationships
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(u => u.Organisation)
                .WithMany(o => o.Users)
                .HasForeignKey(u => u.OrganisationId)
                .IsRequired();
        }
    }
}
