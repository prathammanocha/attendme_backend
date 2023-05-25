using DEKODE.AttendMe.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEKODE.AttendMe.Api.Model.Relationships
{
    public class StaffLogConfiguration : IEntityTypeConfiguration<StaffLog>
    {
        public void Configure(EntityTypeBuilder<StaffLog> builder)
        {
            builder
                .HasOne(a => a.Staff)
                .WithMany(a => a.StaffLogs)
                .HasForeignKey(a => a.StaffId)
                .IsRequired(false);
        }
    }
}