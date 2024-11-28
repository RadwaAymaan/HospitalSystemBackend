using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMSWithLayers.Domain.Entities;

namespace HMSWithLayers.Infrastructure.Configuration;

public class MedicalTestResultConfigurations : IEntityTypeConfiguration<MedicalTestResult>
{
    public void Configure(EntityTypeBuilder<MedicalTestResult> builder)
    {
        builder.Property(p => p.ResultDescription)
            .IsRequired()
            .HasMaxLength(250);
    }
}
