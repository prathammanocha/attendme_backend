using DEKODE.AttendMe.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEKODE.AttendMe.Api.Model.Relationships
{
    public class OrganisationConfiguration : IEntityTypeConfiguration<Organisation>
    {
        public void Configure(EntityTypeBuilder<Organisation> builder)
        {
            //builder
            //    .HasOne(a => a.Account)
            //    .WithMany(a => a.Organisations)
            //    .HasForeignKey(s => s.AccountId)
            //    .IsRequired();

            //builder
            //    .HasOne(a => a.AccSbscrptn)
            //    .WithMany(a => a.Organisations)
            //    .HasForeignKey(s => s.AccSbscrptnId)
            //    .IsRequired();

            builder.OwnsOne(
                p => p.Address,
                a =>
                {
                    a.Property(p => p.StreetNo).HasColumnName("StreetNo");
                    a.Property(p => p.StreetName).HasColumnName("StreetName");
                    a.Property(p => p.Suburb).HasColumnName("Suburb");
                    a.Property(p => p.State).HasColumnName("State");
                    a.Property(p => p.PostCode).HasColumnName("PostCode");
                    a.Property(p => p.Country).HasColumnName("Country");
                });
        }
    }
}