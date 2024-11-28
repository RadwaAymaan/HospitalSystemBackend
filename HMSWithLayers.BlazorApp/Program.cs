using HMSWithLayers.API.ExtensionMethods;
using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.Services;
using HMSWithLayers.BlazorApp.Components;
using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHMSServices(builder.Configuration);

builder.Services.AddScoped(typeof(IPatientService), typeof(PatientService));
builder.Services.AddScoped(typeof(IRoomTypeService), typeof(RoomTypeService));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
       .AddEntityFrameworkStores<HMSBaseDbContext>();

builder.Services.AddDbContext<HMSBaseDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionForSql"),
            b => b.MigrationsAssembly("HMSWithLayers.Infrastructure.Sql")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
