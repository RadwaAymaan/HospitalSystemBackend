using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;

public static  class AppointmentTest
{
    public static void AddAppointment(this HMSBaseDbContext context)
    {
        context.Appointments.AddRange(
        new Appointment
        {
            Id = 1,
            StartTime = TimeOnly.Parse("10:30:00"),
            EndTime = TimeOnly.Parse("12:30:00"),
            Date=DateOnly.Parse("3/11/2024"),
            PatientId = "53ae72a7-589e-4f0b-81ed-4038169498",
            DoctorId = "53ae72a7-589e-4f0b-81ed-40389f683027"
        },
        new Appointment
        {
            Id = 2,
            StartTime = TimeOnly.Parse("10:30:00"),
            EndTime = TimeOnly.Parse("12:30:00"),
            Date = DateOnly.Parse("3/11/2024"),
            PatientId = "53ae72a7-589e-4f0b-81ed-4038169498",
            DoctorId = "53ae72a7-589e-4f0b-81ed-40389f683027"
        }
        );
    }
}
