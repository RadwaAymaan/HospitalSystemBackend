using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMSWithLayers.Domain.Entities;

namespace HMSWithLayers.Infrastructure.Configuration;
public class SpecializationConfigurations : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {
        builder.Property(T => T.SpecializationName)
            .HasColumnType("varchar")
            .HasMaxLength(100);
    }
}
