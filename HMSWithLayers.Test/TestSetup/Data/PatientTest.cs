using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class PatientTest
{
    public static void AddPatient(this HMSBaseDbContext context)
    {
        context.Patients.AddRange(
        new Patient
        {
            Id = "53ae72a7-589e-4f0b-81ed-4038169498",
            Email = "hagershaaban25230@gmail.com",
            FirstName = "hager",
            LastName = "shaaban",
            DateOfBirth = new DateOnly(2000, 12, 30),
            Gender = "Female",
            PhoneNumber = "01065695783",
            UserName = "hagershaaban71"
        },
         new Patient
         {
             Id = "53ae72a7-589e-4f0b-81ed-40389f66514",
             Email = "hagershaaban350@gmail.com",
             FirstName = "hager",
             LastName = "shaaban",
             DateOfBirth = new DateOnly(2000, 12, 30),
             Gender = "Female",
             PhoneNumber = "01065695783",
             UserName = "hagershaaban103"
         }
        );
    }
}
