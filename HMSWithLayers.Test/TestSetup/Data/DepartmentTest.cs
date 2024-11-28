using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class DepartmentTest
{
    public static void AddDepartment(this HMSBaseDbContext context)
    {
        context.Departments.AddRange(
            new Department
            {
                Id = 3,
                DepartmentName = "A" 
            },
            new Department
            {
                Id= 5,
                DepartmentName= "B"
            });
    }
}
