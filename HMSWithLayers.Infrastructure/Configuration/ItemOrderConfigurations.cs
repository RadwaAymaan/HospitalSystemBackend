using HMSWithLayers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Infrastructure.Configuration;


public class ItemOrderConfigurations:IEntityTypeConfiguration<ItemOrder>
{
    public void Configure(EntityTypeBuilder<ItemOrder> builder)
    {
        builder.Property(p => p.Quantity)
              .IsRequired();    

        builder.Property(p =>p.ItemId)
               .IsRequired();

    }
}
