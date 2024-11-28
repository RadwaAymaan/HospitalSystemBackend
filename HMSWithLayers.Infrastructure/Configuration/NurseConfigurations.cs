using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMSWithLayers.Domain.Entities;

namespace HMSWithLayers.Infrastructure.Configuration;

public class NurseConfigurations : IEntityTypeConfiguration<Nurse>
{
    public void Configure(EntityTypeBuilder<Nurse> builder)
    {
        builder.Property(L => L.Email)
                 .HasColumnType("varchar")
                 .IsRequired();

        builder.Property(L => L.FirstName)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

        builder.Property(L => L.LastName)
                .HasColumnType("varchar")
                .HasMaxLength(30);
    }
}
