using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMSWithLayers.Domain.Entities;

namespace HMSWithLayers.Infrastructure.Configuration;

public class InventoryConfigurations : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.Property(p => p.InventoryName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.InventoryLocation)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(p => p.InventoryCapacity)
            .IsRequired();

    }
}
