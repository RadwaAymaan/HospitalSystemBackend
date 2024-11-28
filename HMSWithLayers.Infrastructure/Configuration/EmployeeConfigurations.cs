using HMSWithLayers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Infrastructure.Configuration;

public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
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
