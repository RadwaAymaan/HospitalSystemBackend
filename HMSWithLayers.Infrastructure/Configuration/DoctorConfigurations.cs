using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMSWithLayers.Domain.Entities;

namespace HMSWithLayers.Infrastructure.Configuration;

public class DoctorConfigurations : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.Property(T => T.FirstName)
            .HasColumnType("varchar")
            .HasMaxLength(30);
        builder.Property(T => T.LastName)
            .HasColumnType("varchar")
            .HasMaxLength(30);
        builder.Property(T => T.Gender)
            .HasColumnType("varchar")
            .HasMaxLength(20);
    }

}