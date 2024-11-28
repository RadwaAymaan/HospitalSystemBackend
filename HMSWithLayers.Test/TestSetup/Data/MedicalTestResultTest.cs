using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Domain.Enums;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class MedicalTestResultTest
{
    public static void AddMedicalTestResult(this HMSBaseDbContext context)
    {
        context.MedicalTestResults.AddRange(
            new MedicalTestResult
            {
                ResultDescription = "Test result description",
                Id = 1,
                LaboratoristId = "553ae72a7-589e-4f0b-81ed-40388754",
                MedicalTestOrderId = 1,
                ResultDate = DateTime.Now,
                
            },
            new MedicalTestResult
            {
                ResultDescription = "High cholesterol levels",
                Id = 2,
                LaboratoristId = "553ae72a7-589e-4f0b-81ed-40388754",
                MedicalTestOrderId = 1,
                ResultDate = DateTime.Now.AddDays(-14),

            }
        );
    }
}
