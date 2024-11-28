using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class RoomTest
{
    public static void AddRoom(this HMSBaseDbContext context)
    {
        context.Rooms.AddRange(
        new Room
        {
            Id = 1,
            Availability = true,
            RoomTypeId = 1,
            RoomNumber = 1,
        },
        new Room
        {
            Id = 2,
            Availability = true,
            RoomTypeId = 2,
            RoomNumber = 10,
        }
        );
    }
}
