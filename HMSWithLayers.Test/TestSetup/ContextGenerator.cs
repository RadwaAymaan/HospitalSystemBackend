using HMSWithLayers.Infrastructure.BaseContext;
using HMSWithLayers.Test.TestSetup.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestSetup;

public class ContextGenerator
{
    private static HMSBaseDbContext Context;
    public static HMSBaseDbContext Generator()
    {
        if (Context == null)
        {
            var options = new DbContextOptionsBuilder<HMSBaseDbContext>()
           .UseInMemoryDatabase(databaseName: "HospitalManagementSystem")
           .Options;
            Context = new HMSBaseDbContext(options);
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
            Context.AddMedicine();
            Context.AddPrescription();
            Context.AddDoctor();
            Context.AddNurse();
            Context.AddSpecialization();
            Context.AddItemCategory();
            Context.AddDepartment();
            Context.AddItem();
            Context.AddLaboratoriest();
            Context.AddInventory();
            Context.AddMedicalTest();
            Context.AddMedicalTestOrder();
            Context.AddMedicalTestResult();
            Context.AddMedicalHistory();
            Context.AddPatient();
            Context.AddEmployee();
            Context.AddPharmacist();
            Context.AddSchedule();
            Context.AddTimeSlot();
            Context.AddOrder();
            Context.AddAppointment();
            Context.AddRoom();
            Context.AddRoomType();
            Context.SaveChanges();
        }

        return Context;
    }
}
