using DEKODE.AttendMe.Data.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DEKODE.AttendMe.Data.Model.Relationships
{
    public class AppDeviceConfiguration : IEntityTypeConfiguration<AppDevice>
    {
        public void Configure(EntityTypeBuilder<AppDevice> builder)
        {
            builder
                .HasOne(d => d.Organisation)
                .WithMany(o => o.Devices)
                .HasForeignKey(d => d.OrganisationId)
                .IsRequired();
        }
    }
}
