using DEKODE.AttendMe.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEKODE.AttendMe.Api.Model.Relationships
{
    public class RelativesConfiguration : IEntityTypeConfiguration<Relatives>
    {
        public void Configure(EntityTypeBuilder<Relatives> builder)
        {
            // Configure the relationships and mappings for the Relatives entity

            builder
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(r => r.StudentId)
                .IsRequired();

            // Add more configurations as needed
        }
    }
}
