using HMSWithLayers.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Infrastructure.BaseContext;

public class HMSBaseDbContext : IdentityDbContext<ApplicationUser>
{
    public HMSBaseDbContext(DbContextOptions dbContext) : base(dbContext)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    //public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<Laboratorist> Laboratorists { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<ItemCategory> ItemCategories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemOrder> ItemOrders { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomNurse> RoomNurses { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Nurse> Nurses { get; set; }
    public DbSet<Pharmacist> Pharmacists { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<MedicalHistory> MedicalHistories { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }
    public DbSet<MedicalTestOrder> MedicalTestOrders { get; set; }
    public DbSet<MedicalTestResult> MedicalTestResults { get; set; }
    public DbSet<MedicalTest> MedicalTests { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
}
