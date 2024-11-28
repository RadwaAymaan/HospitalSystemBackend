using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class InventoryTest
{
    public static void AddInventory(this HMSBaseDbContext context)
    {
        context.Inventories.AddRange(
        new Inventory
        {
            Id = 1,
            InventoryCapacity = 1,
            InventoryName = "inv2",
            InventoryLocation = "B"
        },
        new Inventory
        {
            Id = 2,
            InventoryCapacity = 10,
            InventoryName = "inv1",
            InventoryLocation = "C"

        }
        );
    }
}
