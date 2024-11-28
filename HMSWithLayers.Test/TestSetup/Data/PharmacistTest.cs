using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class PharmacistTest
{
    public static void AddPharmacist(this HMSBaseDbContext context)
    {
        context.Pharmacists.AddRange(
        new Pharmacist
        {
            Id = "53ae72a7-589e-4f0b-81ed-403896568",
            Email = "hagershaaban20@gmail.com",
            FirstName = "hager",
            LastName = "shaaban",
            DateOfBirth = new DateOnly(2000, 12, 30),
            Gender = "Female",
            PhoneNumber = "01065695783",
            UserName = "hagershaaban7"
        },
         new Pharmacist
         {
             Id = "53ae72a7-589e-4f0b-81ed-40381265451",
             Email = "hagershaaban30@gmail.com",
             FirstName = "hager",
             LastName = "shaaban",
             DateOfBirth = new DateOnly(2000, 12, 30),
             Gender = "Female",
             PhoneNumber = "01065695783",
             UserName = "hagershaaban10"
         }
        );
    }
}
