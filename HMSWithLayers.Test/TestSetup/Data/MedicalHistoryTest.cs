using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class MedicalHistoryTest
{
    public static void AddMedicalHistory(this HMSBaseDbContext context)
    {
        context.MedicalHistories.AddRange(
        new MedicalHistory 
        { 
            Id = 1,
            PatientId = "53ae72a7-589e-4f0b-81ed-4038169498",
            Details = "Visited hospital for routine check-up."
        },
        new MedicalHistory
        {
            Id = 2,
            PatientId = "53ae72a7-589e-4f0b-81ed-4038169498",
            Details = "Prescribed medication for flu symptoms."
        },
        new MedicalHistory
        {
            Id = 3,
            PatientId = "53ae72a7-589e-4f0b-81ed-4038169498",
            Details = "Underwent surgery for appendicitis."
        }
        );
    }
}
