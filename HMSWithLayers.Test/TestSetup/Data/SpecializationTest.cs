using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class SpecializationTest
{
    public static void AddSpecialization(this HMSBaseDbContext context)
    {
        context.Specializations.AddRange(
        new Specialization
        {
            Id=1,
            SpecializationName = "Gastroenterologists"
        },
        new Specialization
        {
            Id = 3,
            SpecializationName = "Dermatology"
        }
        );
    }
}
