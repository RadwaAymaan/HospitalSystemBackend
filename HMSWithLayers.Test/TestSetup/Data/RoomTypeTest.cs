using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class RoomTypeTest
{
    public static void AddRoomType(this HMSBaseDbContext context)
    {
        context.RoomTypes.AddRange(
        new RoomType
        {
            Id = 1,
            NumberOfPatient=1,
            Type = "Single"
        },
        new RoomType
        {
            Id = 2,
            NumberOfPatient = 2,
            Type = "Double"
        }
        );
    }
}
