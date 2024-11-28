using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class LaboratoriestTest
{
    public static void AddLaboratoriest(this HMSBaseDbContext context)
    {
        context.Laboratorists.AddRange(
        new Laboratorist
        {
            Id = "553ae72a7-589e-4f0b-81ed-40388754",
            Email = "passant20@gmail.com",
            FirstName = "passant",
            LastName = "mohamed",
            DateOfBirth = new DateOnly(2000, 12, 30),
            Gender = "Female",
            PhoneNumber = "01124961181",
            UserName = "passantmohamed7"


        },
         new Laboratorist
         {
             Id = "53ae72a7-589e-4f0b-81ed-40389558",
             Email = "passantmohamed30@gmail.com",
             FirstName = "passant",
             LastName = "mohamed",
             DateOfBirth = new DateOnly(2000, 12, 30),
             Gender = "Female",
             PhoneNumber = "01124961181",
             UserName = "passantmohamed10"
         }
        );
    }
}
