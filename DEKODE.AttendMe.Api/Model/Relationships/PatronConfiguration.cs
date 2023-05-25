using DEKODE.AttendMe.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEKODE.AttendMe.Api.Model.Relationships
{
    public class PatronConfiguration : IEntityTypeConfiguration<Patron>
    {
        public void Configure(EntityTypeBuilder<Patron> builder)
        {
            //builder
            //    .HasOne(a => a.PatronType)
            //    .WithMany(a => a.Patrons)
            //    .HasForeignKey(s => s.PatronTypeId)
            //    .IsRequired();

            builder
                .HasOne(a => a.Organisation)
                .WithMany(a => a.Patrons)
                .HasForeignKey(s => s.OrganisationId)
                .IsRequired();
        }
    }
}