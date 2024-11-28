using AutoMapper;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.API.Mapping;
using HMSWithLayers.Application.Services;
using HMSWithLayers.Test.TestPriority;
using HMSWithLayers.Test.TestSetup;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMSWithLayers.Application.Contracts;

namespace HMSWithLayers.Test.TestServices;
[TestCaseOrderer(
ordererTypeName: "HMSWithLayers.Test.TestPriority.PriorityOrderer",
ordererAssemblyName: "HMSWithLayers.Test")]
public class MedicalHistoryServicesTest
{
    private static MedicalHistoryService _medicalHistoryService;
    private string userEmail = "hagershaaban7@gmail.com";
    private MedicalHistoryService CreateMedicalHistoryService()
    {

        if (_medicalHistoryService is null)
        {
            var dbContext = ContextGenerator.Generator();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();
            ILogger<MedicalHistoryService> MedicalHistoryLogger = new LoggerFactory().CreateLogger<MedicalHistoryService>();

            IUserContextService userContext = new UserContextService();
            _medicalHistoryService = new MedicalHistoryService(dbContext, mapper, MedicalHistoryLogger, userContext);
        }

        return _medicalHistoryService;
    }

    private void CheckService()
    {
        if (_medicalHistoryService is null)
            _medicalHistoryService = CreateMedicalHistoryService();
    }

    /// <summary>
    /// fuction to add medical history as a test case . 
    /// </summary>
    /// <param name="details">medical history details</param>
    /// <param name="patientId">pateient id</param>
    [Theory, TestPriority(0)]
    [InlineData("Regular check-up with no issues reported.", "53ae72a7-589e-4f0b-81ed-4038169498")]
    [InlineData("Regular check-up with no issues reported.", "53ae72a7-589e-4f0b-81ed-403816949865468")]
    public async Task AddMedicalHistory(string details,string patientId)
    {
        // Arrange
        CheckService();
        var medicalHistoryRequestDto = new MedicalHistoryRequestDto { Details = details , PatientId = patientId };
        // Act
        var result = await _medicalHistoryService.AddMedicalHistoryAsync(medicalHistoryRequestDto);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// fuction to update medical history as a test case .
    /// </summary>
    /// <param name="details">medical history details</param>
    /// <param name="patientId">pateient id</param>
    /// <param name="id">MedicalHistory id</param>
    /// <param name="expectedResult">expected result</param>
    [Theory, TestPriority(3)]
    [InlineData(1,"Regular check-up with no issues reported.", "53ae72a7-589e-4f0b-81ed-4038169498",true)]
    [InlineData(20,"Regular check-up with no issues reported.", "53ae72a7-589e-4f0b-81ed-403816949865468",false)]
    public async Task UpdateMedicalHistoryAsync(int id, string details, string patientId, bool expectedResult)
    {
        //Arrange
        CheckService();
        var medicalHistoryRequestDto = new MedicalHistoryRequestDto { Details = details, PatientId = patientId };
        // Act
        var result = await _medicalHistoryService.UpdateMedicalHistory(id, medicalHistoryRequestDto);
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
    /// fuction to get all  medical history for specific patient as a test case 
    /// </summary>
    [Theory, TestPriority(1)]
    [InlineData("53ae72a7-589e-4f0b-81ed-4038169498")]
    [InlineData("53ae72a7-589e-4f0b-81ed-403816949865468")]
    public async Task GetMedicalHistoryByPatientId(string patientId)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _medicalHistoryService.GetMedicalHistoryByPatientId(patientId);

        // Assert
        Assert.True(result.IsSuccess);

    }


    /// <summary>
    /// fuction to get medical history by id as a test case that take medical history id
    /// </summary>
    /// <param name="id"> medical history id</param>
    [Theory, TestPriority(2)]
    [InlineData(1)]
    [InlineData(20)]
    public async Task GetByIdMedicalHistory(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _medicalHistoryService.GetMedicalHistoryeById(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
    /// <summary>
    /// fuction to remove medical history as a test case.
    /// </summary>
    /// <param name="id">medical history id</param>
    [Theory, TestPriority(4)]
    [InlineData(3)]
    [InlineData(30)]
    public async Task RemoveMedicalHistory(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _medicalHistoryService.DeleteMedicalHistory(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
}
