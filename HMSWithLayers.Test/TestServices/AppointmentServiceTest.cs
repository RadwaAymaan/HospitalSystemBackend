using AutoMapper;
using HMSWithLayers.API.Mapping;
using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Application.Services;
using HMSWithLayers.Test.TestPriority;
using HMSWithLayers.Test.TestSetup;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HMSWithLayers.Test.TestServices;
[TestCaseOrderer(
ordererTypeName: "HMSWithLayers.Test.TestPriority.PriorityOrderer",
ordererAssemblyName: "HMSWithLayers.Test")]
public  class AppointmentServiceTest
{

    private static AppointmentService  _appointmentService;
    private string userEmail = "Mariamabdeeen@gmail.com";
    private AppointmentService CreateAppointmentService()
    {

        if (_appointmentService is null)
        {
            var dbContext = ContextGenerator.Generator();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();

            ILogger<AppointmentService> logger = new LoggerFactory().CreateLogger<AppointmentService>();

            IUserContextService userContext = new UserContextService();

            _appointmentService = new AppointmentService(dbContext, mapper, logger, userContext);
        }

        return _appointmentService;
    }
    private void CheckService()
    {
        if (_appointmentService is null)
            _appointmentService = CreateAppointmentService();
    }

    /// <summary>
    /// fuction to get all appointments as a test case 
    /// </summary>
    [Fact, TestPriority(1)]
    public async Task GetAllAppointment()
    {
        // Arrange
        CheckService();

        // Act
        var result = await _appointmentService.GetAllAppointmentAsync();

        // Assert
        Assert.True(result.IsSuccess);

    }
    /// <summary>
    /// fuction to add appointment as a test case. 
    /// </summary>
    /// <param name="date">appointment date</param>
    /// <param name="startTime">appointment start time</param>
    /// <param name="endTime">appointment end time</param>
    [Theory, TestPriority(0)]
    [InlineData("3/11/2024", "02:00:00", "03:00:00")]
    public async Task AddAppointment(string date, string startTime, string endTime)
    {
        // Arrange
        CheckService();
        var appointmentRequestDto =new AppointmentRequestDto { Date = DateOnly.Parse(date) , StartTime = TimeOnly.Parse(startTime), EndTime = TimeOnly.Parse(endTime) };
        // Act
        var result = await _appointmentService.AddAppointmentAsync(appointmentRequestDto);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);
    }
    /// <summary>
    /// fuction to get appointment by id as a test case 
    /// </summary>
    /// <param name="id">appointmentid </param>
    /// <returns>specific appointment</returns>
    [Theory, TestPriority(2)]
    [InlineData(1)]
    [InlineData(6)]
    public async Task GetByIdAppointment(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _appointmentService.GetAppointmentByIdAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
    /// <summary>
    /// fuction to update appointment as a test case 
    /// </summary>
    /// <param name="id">appointment id</param>
    /// <param name="date">appointment date</param>
    /// <param name="startTime">appointment start time</param>
    /// <param name="endTime">appointment end time</param>
    /// <param name="expectedResult">expected result</param>
    [Theory, TestPriority(3)]
    [InlineData(1, "3/18/2024", "5:30:00", "6:30:00", "53ae72a7-589e-4f0b-81ed-40389f683027", "53ae72a7-589e-4f0b-81ed-4038169498", true)]
    [InlineData(10, "3/11/2024", "5:30:00", "5:30:00", "53ae72a7-589e-4f0b-81ed-40389f683027", "53ae72a7-589e-4f0b-81ed-4038169498", false)]
    public async Task UpdateAppointment(int id, string date, string startTime, string endTime,string doctorId,string patientId, bool expectedResult)
    {
        //Arrange
        CheckService();
        var appointmentRequestDto = new AppointmentRequestDto { Date = DateOnly.Parse(date), StartTime = TimeOnly.Parse(startTime), EndTime = TimeOnly.Parse(endTime),DoctorId =doctorId,PatientId= patientId };
        // Act
        var result = await _appointmentService.UpdateAppointmentAsync (id, appointmentRequestDto);
        // Assert
        if (expectedResult)
        {
            Assert.True(result.IsSuccess); // Expecting successful update
        }
        else
        {
            Assert.False(result.IsSuccess); // Expecting unsuccessful update
        }
    }
    /// <summary>
    /// fuction to remove appointment as a test case that take appointment id
    /// </summary>
    /// <param name="id"> appointment id </param>
    /// <returns>appointment remove successfully</returns>
    [Theory, TestPriority(6)]
    [InlineData(2)]
    [InlineData(50)]
    public async Task RemoveAppointment(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _appointmentService.DeleteAppointmentAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
    /// <summary>
    /// fuction to get all appointments for specific doctor as a test case 
    /// </summary>
    [Theory, TestPriority(4)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f683027")]
    public async Task GetAllAppointmentForSpecificDoctor(string doctorId)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _appointmentService.GetAllAppointmentForSpecificDoctor(doctorId);

        // Assert
        Assert.True(result.IsSuccess);

    }
    /// <summary>
    /// fuction to get all appointments for specific patient as a test case 
    /// </summary>
    [Theory, TestPriority(5)]
    [InlineData("53ae72a7-589e-4f0b-81ed-4038169498")]
    public async Task GetAllAppointmentForSpecificPatient(string patientId)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _appointmentService.GetAllAppointmentForSpecificPatient(patientId);

        // Assert
        Assert.True(result.IsSuccess);

    }

}
