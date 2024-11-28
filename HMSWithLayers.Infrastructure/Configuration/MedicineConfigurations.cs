using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMSWithLayers.Domain.Entities;

namespace HMSWithLayers.Infrastructure.Configuration;

public class MedicineConfigurations : IEntityTypeConfiguration<Medicine>
{
    public void Configure(EntityTypeBuilder<Medicine> builder)
    {
        builder.Property(T => T.MedicineDescription)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(T => T.MedicineDosage)
            .HasDefaultValue(1)
            .IsRequired();

        builder.Property(T => T.MedicineName)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();
    }
}