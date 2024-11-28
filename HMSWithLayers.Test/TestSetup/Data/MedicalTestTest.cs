using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class MedicalTestTest
{
    public static void AddMedicalTest(this HMSBaseDbContext context)
    {
        context.MedicalTests.AddRange(
            new MedicalTest { Id = 1,Name = "Blood Test", Description = "Checks blood components" },
            new MedicalTest { Id = 2, Name = "X-Ray", Description = "Radiographic imaging" },
            new MedicalTest { Id = 3, Name = "MRI Scan", Description = "Magnetic resonance imaging" }
        );
    }
}
