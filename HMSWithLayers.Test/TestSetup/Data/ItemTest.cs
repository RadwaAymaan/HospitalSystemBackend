using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class ItemTest
{
    public static void AddItem(this HMSBaseDbContext context)
    {
        context.Items.AddRange(
        new Item
        {
            Id = 1,
            Name = "Medical Mask",
            Description = "Disposable medical face mask",
            Stock = 1000,
            Price = 50,
            CategoryId = 1
        },
        new Item
        {
            Id = 2,
            Name = "Antibiotic Ointment",
            Description = "Topical antibiotic for minor cuts and wounds",
            Stock = 500,
            Price = 20,
            CategoryId = 1
        },
        new Item
        {
            Id = 3,
            Name = "Digital Thermometer",
            Description = "Digital thermometer for measuring body temperature",
            Stock = 200,
            Price = 30,
            CategoryId = 2
        }
        );
    }
}
