using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class NurseTest
{
    public static void AddNurse(this HMSBaseDbContext context)
    {
        context.Nurses.AddRange(
        new Nurse
        {
            Id = "53ae72a7-589e-4f0b-81ed-40389f6854986",
            Email = "passant20@gmail.com",
            FirstName = "passant",
            LastName = "mohamed",
            DateOfBirth = new DateOnly(2000, 12, 30),
            Gender = "Female",
            PhoneNumber = "01124961181",
            UserName = "passantmohamed7"
                 
            
        },
         new Nurse
         {
             Id = "53ae72a7-589e-4f0b-81ed-40389f683027562",
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
