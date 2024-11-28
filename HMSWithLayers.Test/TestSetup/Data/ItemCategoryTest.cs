using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class ItemCategoryTest
{
    public static void AddItemCategory(this HMSBaseDbContext context)
    {
        context.ItemCategories.AddRange(
        new ItemCategory { Id = 1, CategoryName = "First Aid Supplies" },
        new ItemCategory { Id = 2, CategoryName = "Medication" },
        new ItemCategory { Id = 3, CategoryName = "Medical Equipment" }
        );
    }
}
