using AutoMapper;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.API.Mapping;
using HMSWithLayers.Application.Services;
using HMSWithLayers.Domain.Enums;
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
public class MedicalTestResultServiceTest
{
    private static MedicalTestResultService _medicalTestResultService;
    private string userEmail = "hagershaaban7@gmail.com";
    private MedicalTestResultService CreateMedicalTestResultService()
    {

        if (_medicalTestResultService is null)
        {
            var dbContext = ContextGenerator.Generator();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();
            ILogger<MedicalTestResultService> MedicalTestResultLogger = new LoggerFactory().CreateLogger<MedicalTestResultService>();

            IUserContextService userContext = new UserContextService();
            _medicalTestResultService = new MedicalTestResultService(dbContext, mapper, MedicalTestResultLogger, userContext);
        }

        return _medicalTestResultService;
    }

    private void CheckService()
    {
        if (_medicalTestResultService is null)
            _medicalTestResultService = CreateMedicalTestResultService();
    }

    /// <summary>
    /// fuction to add medical test order as a test case . 
    /// </summary>
    /// <param name="laboratoristId">laboratorist id</param>
    /// <param name="medicalTestOrderId">medical test order id</param>
    /// <param name="resultDescription">result description</param>
    [Theory, TestPriority(0)]
    [InlineData("Normal", "553ae72a7-589e-4f0b-81ed-40388754", 1)]
    public async Task AddMedicalTestResult(string resultDescription, string laboratoristId, int medicalTestOrderId)
    {
        // Arrange
        CheckService();
        var MedicalTestResultRequestDto = new MedicalTestResultRequestDto
        {
            MedicalTestOrderId = medicalTestOrderId,
            LaboratoristId = laboratoristId,
            ResultDescription = resultDescription
            
        };
        // Act
        var result = await _medicalTestResultService.AddMedicalTestResultAsync(MedicalTestResultRequestDto);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// fuction to update medical test result as a test case .
    /// </summary>
    /// <param name="id">medical test order id</param>
    /// <param name="laboratoristId">laboratorist id</param>
    /// <param name="medicalTestOrderId">medical test order id</param>
    /// <param name="resultDescription">result description</param>
    [Theory, TestPriority(3)]
    [InlineData(1,"Normal", "553ae72a7-589e-4f0b-81ed-40388754", 1,true)]
    [InlineData(20,"Normal", "553ae72a7-589e-4f0b-81ed-40388754", 1,false)]
    public async Task UpdateMedicalTestResultAsync(int id, string resultDescription, string laboratoristId, int medicalTestOrderId, bool expectedResult)
    {
        //Arrange
        CheckService();
        var MedicalTestResultRequestDto = new MedicalTestResultRequestDto
        {
            MedicalTestOrderId = medicalTestOrderId,
            LaboratoristId = laboratoristId,
            ResultDescription = resultDescription

        };
        // Act
        var result = await _medicalTestResultService.UpdateMedicalTestResultAsync(id, MedicalTestResultRequestDto);
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
    /// fuction to get all  medical test result for specific patient as a test case 
    /// </summary>
    [Theory, TestPriority(1)]
    [InlineData("53ae72a7-589e-4f0b-81ed-4038169498")]
    [InlineData("53ae72a7-589e-4f0b-81ed-403816949865468")]
    public async Task GetMedicalTestResultByPatientId(string patientId)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _medicalTestResultService.GetAllMedicalTestResultsByPatientIdAsync(patientId);

        // Assert
        Assert.True(result.IsSuccess);

    }


    /// <summary>
    /// fuction to get medical test result by id as a test case that take medical test result id
    /// </summary>
    /// <param name="id"> medical test order id</param>
    [Theory, TestPriority(2)]
    [InlineData(1)]
    [InlineData(20)]
    public async Task GetByIdMedicalTestResult(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _medicalTestResultService.GetMedicalTestResultByIdAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
    /// <summary>
    /// fuction to remove medical test result as a test case.
    /// </summary>
    /// <param name="id">medical test result id</param>
    [Theory, TestPriority(4)]
    [InlineData(3)]
    [InlineData(30)]
    public async Task RemoveMedicalTestResult(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _medicalTestResultService.DeleteMedicalTestResultAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
}
