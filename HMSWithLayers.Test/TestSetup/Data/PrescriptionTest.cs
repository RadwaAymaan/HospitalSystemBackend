using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup.Data;
public static class PrescriptionTest
{
    public static void AddPrescription(this HMSBaseDbContext context)
    {
        context.Prescriptions.AddRange(
        new Prescription
        {
            Id = 1,
            Name = "Pain reliever",
            DoctorId = "c5ba1d3c-b27b-43ed-a183-b2404b6cf9ba",
            PatientId = "c5ba1d3c-b27b-43ed-a183-b2404b6c8lms",
            Description = "Pain and fever reliever",
            Date = DateTime.Now
        },
        new Prescription
        {
            Id = 2,
            Name = "Pain reliever",
            DoctorId = "c5ba1d3c-b27b-43ed-a183-b2404b6cf9ba",
            PatientId = "c5ba1d3c-b27b-43ed-a183-b2404b6c8lms",
            Description = "Complete the full course",
        }

        );
    }
}
