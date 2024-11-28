using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class EmployeeTest
{
    public static void AddEmployee(this HMSBaseDbContext context)
    {
        context.Employees.AddRange(
        new Employee
        {
            Id = "78ty72a7-589e-4f0b-81ed-40389f683616",
            Email = "mariamabdeen299@gmail.com",
            FirstName = "mariam",
            LastName = "abdeen",
            DateOfBirth = new DateOnly(2001, 9, 29),
            Gender = "Female",
            PhoneNumber = "01021432813",
            UserName = "mariamabdeen",
            DepartmentId = 5

        },
         new Employee
         {
             Id = "45yi72a7-589e-4f0b-81ed-40389f683027",
             Email = "mariamabdeen299@gmail.com",
             FirstName = "mariam",
             LastName = "abdeen",
             DateOfBirth = new DateOnly(2001, 9, 29),
             Gender = "Female",
             PhoneNumber = "01021432813",
             UserName = "mariamabdeen",
             DepartmentId = 3
         }
        );
    }
}