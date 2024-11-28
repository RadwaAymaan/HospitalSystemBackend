using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class TimeSlotTest
{
    public static void AddTimeSlot(this HMSBaseDbContext context)
    {
        context.TimeSlots.AddRange(
        new TimeSlot
        {
            Id = 1,
            Day = "MonDay",
            StartTime = new TimeOnly(02, 30,10),
            EndTime = new TimeOnly(03, 30,12),
        },
        new TimeSlot
        {
            Id = 3,
            Day = "SunDay",
            StartTime = new TimeOnly(02, 30,20),
            EndTime = new TimeOnly(03, 30,30),
        }
        );
    }
}
