using HMSWithLayers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Infrastructure.Configuration;

public class TimeSlotConfigurations:IEntityTypeConfiguration<TimeSlot>
{
    public void Configure(EntityTypeBuilder<TimeSlot> builder)
    {

      builder.Property(p => p.StartTime)
        .IsRequired();

      builder.Property(p => p.EndTime)
        .IsRequired();


      builder.Property(p => p.Day)
        .IsRequired();

    }
}