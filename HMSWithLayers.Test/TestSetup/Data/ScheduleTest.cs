using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static class ScheduleTest
{
    public static void AddSchedule(this HMSBaseDbContext context)
    {
        context.Schedules.AddRange(
        new Schedule
        {
            Id = 1,
           TimeSlotId=1
        },
        new Schedule
        {
            Id = 2,
            TimeSlotId = 1
        }  
        );
    }
}
