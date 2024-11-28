using AutoMapper;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Application.Services;
using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Test.TestPriority;
using HMSWithLayers.Test.TestSetup;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMSWithLayers.API.Mapping;

namespace HMSWithLayers.Test.TestServices;
[TestCaseOrderer(
ordererTypeName: "HMSWithLayers.Test.TestPriority.PriorityOrderer",
ordererAssemblyName: "HMSWithLayers.Test")]
public class PatientServiceTest
{
    private static PatientService _patientService;

    private PatientService CreatePatientService()
    {

        if (_patientService is null)
        {
            var dbContext = ContextGenerator.Generator();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();
            ILogger<PatientService> PatientLogger = new LoggerFactory().CreateLogger<PatientService>();
            _patientService = new PatientService(dbContext, PatientLogger, mapper );
        }

        return _patientService;
    }

    private void CheckService()
    {
        if (_patientService is null)
            _patientService = CreatePatientService();
    }
    /// <summary>
    /// fuction to update Patient as a test case .
    /// </summary>
    /// <param name="PatientEmail">Patient email</param>
    /// <param name="PatientFirstName">Patient first name</param>
    /// <param name="PatientLastName">Patient last name</param> 
    /// <param name="PatientPhoneNumber">Patient phone number</param>
    /// <param name="Gender">Patient gender</param>
    /// <param name="id">Patient id</param>
    /// <param name="Password">Patient password</param>
    /// <param name="SpecializationId">specialization id</param>
    /// <param name="UserName">Patient user name</param>
    /// <param name="expectedResult">expected result</param>
    [Theory, TestPriority(3)]
    [InlineData("53ae72a7-589e-4f0b-81ed-4038169498", "nejosif605@hisotyr.com", "Hager", "shaaban", "01065695783", "nejosif605", "0167519Kh!", "Female",  true)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f683027-6514984", "nejosif605@hisotyr.com", "Hager", "shaaban", "01065695783", "nejosif605", "0167519Kh!", "Female", false)]
    public async Task UpdatePatientAsync(string id, string PatientEmail, string PatientFirstName, string PatientLastName, string PatientPhoneNumber, string UserName, string Password, string Gender,  bool expectedResult)
    {
        //Arrange
        CheckService();
        var PatientRequestDto = new PatientRequestDto
        {
            PatientEmail = PatientEmail,
            PatientFirstName = PatientFirstName,
            PatientLastName = PatientLastName,
            PatientPhoneNumber = PatientPhoneNumber,
            UserName = UserName,
            Password = Password,
        };
        // Act
        var result = await _patientService.UpdatePatientAsync(id, PatientRequestDto);
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
    /// fuction to get all  Patient as a test case 
    /// </summary>
    [Fact, TestPriority(1)]
    public async Task GetAllPatient()
    {
        // Arrange
        CheckService();

        // Act
        var result = await _patientService.GetAllPatientsAsync();

        // Assert
        Assert.True(result.IsSuccess);

    }
    /// <summary>
    /// fuction to get Patient by id as a test case that take Patient id
    /// </summary>
    /// <param name="id"> Patient id</param>
    [Theory, TestPriority(2)]
    [InlineData("53ae72a7-589e-4f0b-81ed-4038169498")]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f68302765165")]
    public async Task GetByIdPatient_ReturnResult(string id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _patientService.GetPatientByIdAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
    /// <summary>
    /// fuction to remove Patient as a test case that take Patient id
    /// </summary>
    /// <param name="id">Patient id</param>
    [Theory, TestPriority(4)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f6830658")]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f6830658-51694k")]
    public async Task RemovePatient_ReturnResult(string id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _patientService.DeletePatientAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
}
