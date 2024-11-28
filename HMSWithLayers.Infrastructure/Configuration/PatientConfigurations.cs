using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMSWithLayers.Domain.Entities;

namespace HMSWithLayers.Infrastructure.Configuration;

public class PatientConfigurations : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(P => P.FirstName)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

        builder.Property(P => P.LastName)
                .HasColumnType("varchar")
                .HasMaxLength(20);

        builder.Property(P => P.UserName)
                .HasColumnType("varchar")
                .HasMaxLength(40);

    }
}