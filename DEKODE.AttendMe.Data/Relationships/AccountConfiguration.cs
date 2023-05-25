using DEKODE.AttendMe.Data.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEKODE.AttendMe.Data.Model.Relationships
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
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
