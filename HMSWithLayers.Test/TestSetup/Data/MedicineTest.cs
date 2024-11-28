using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;
public static class MedicineTest
{
    public static void AddMedicine(this HMSBaseDbContext context)
    {
        context.Medicines.AddRange(
        new Medicine
        {
            Id = 1,
            MedicineName = "Aspirin",
            MedicineDescription = "Pain reliever",
            MedicineDosage = 2
        },
        new Medicine
        {
            Id = 3,
            MedicineName = "Paracetamol",
            MedicineDescription = "Pain and fever reliever",
            MedicineDosage = 3
        }
        );
    }
}
