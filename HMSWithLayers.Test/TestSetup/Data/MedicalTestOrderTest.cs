using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Domain.Enums;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class MedicalTestOrderTest
{
    public static void AddMedicalTestOrder(this HMSBaseDbContext context)
    {
        context.MedicalTestOrders.AddRange(
            new MedicalTestOrder
            {
                OrderStatus = Status.Pending,
                MedicalTestId = 1,
                PatientId = "53ae72a7-589e-4f0b-81ed-4038169498",
                DoctorId = "53ae72a7-589e-4f0b-81ed-40389f683027",
                LaboratoristId = "553ae72a7-589e-4f0b-81ed-40388754"
            },
            new MedicalTestOrder
            {
                OrderStatus = Status.Cancelled,
                MedicalTestId = 1,
                PatientId = "53ae72a7-589e-4f0b-81ed-4038169498",
                DoctorId = "53ae72a7-589e-4f0b-81ed-40389f683027",
                LaboratoristId = "553ae72a7-589e-4f0b-81ed-40388754"
            }
        );
    }
}
