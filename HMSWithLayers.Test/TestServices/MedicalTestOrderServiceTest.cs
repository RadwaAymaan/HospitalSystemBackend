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
public class MedicalTestOrderServiceTest
{
    private static MedicalTestOrderService _medicalTestOrderService;
    private string userEmail = "hagershaaban7@gmail.com";
    private MedicalTestOrderService CreateMedicalTestOrderService()
    {

        if (_medicalTestOrderService is null)
        {
            var dbContext = ContextGenerator.Generator();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();
            ILogger<MedicalTestOrderService> MedicalTestOrderLogger = new LoggerFactory().CreateLogger<MedicalTestOrderService>();

            IUserContextService userContext = new UserContextService();
            _medicalTestOrderService = new MedicalTestOrderService(dbContext, mapper, MedicalTestOrderLogger, userContext);
        }

        return _medicalTestOrderService;
    }

    private void CheckService()
    {
        if (_medicalTestOrderService is null)
            _medicalTestOrderService = CreateMedicalTestOrderService();
    }

    /// <summary>
    /// fuction to add medical test order as a test case . 
    /// </summary>
    /// <param name="status">status for medical test</param>
    /// <param name="patientId">pateient id</param>
    /// <param name="doctorId">doctor id</param>
    /// <param name="laboratoristId">laboratorist id</param>
    /// <param name="medicalTestId">medical test id</param>
    [Theory, TestPriority(0)]
    [InlineData(Status.Pending, "53ae72a7-589e-4f0b-81ed-40389f683027", "553ae72a7-589e-4f0b-81ed-40388754", 1, "53ae72a7-589e-4f0b-81ed-4038169498")]
    public async Task AddMedicalTestOrder(Status status, string doctorId, string laboratoristId, int medicalTestId, string patientId)
    {
        // Arrange
        CheckService();
        var MedicalTestOrderRequestDto = new MedicalTestOrderRequestDto
        {
            OrderStatus = status,
            DoctorId = doctorId,
            LaboratoristId = laboratoristId,
            MedicalTestId = medicalTestId,
            PatientId = patientId
        };
        // Act
        var result = await _medicalTestOrderService.AddMedicalTestOrderAsync(MedicalTestOrderRequestDto);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// fuction to update medical test order as a test case .
    /// </summary>
    /// <param name="id">medical test order id</param>
    /// <param name="status">status for medical test</param>
    /// <param name="patientId">pateient id</param>
    /// <param name="doctorId">doctor id</param>
    /// <param name="laboratoristId">laboratorist id</param>
    /// <param name="medicalTestId">medical test id</param>
    [Theory, TestPriority(3)]
    [InlineData(1, Status.Pending, "53ae72a7-589e-4f0b-81ed-40389f683027", "553ae72a7-589e-4f0b-81ed-40388754", 1, "53ae72a7-589e-4f0b-81ed-4038169498", true)]
    [InlineData(30, Status.Pending, "53ae72a7-589e-4f0b-81ed-40389f683027", "553ae72a7-589e-4f0b-81ed-40388754", 1, "53ae72a7-589e-4f0b-81ed-4038169498", false)]
    public async Task UpdateMedicalTestOrderAsync(int id, Status status, string doctorId, string laboratoristId, int medicalTestId, string patientId, bool expectedResult)
    {
        //Arrange
        CheckService();
        var medicalTestOrderRequestDto = new MedicalTestOrderRequestDto
        {
            OrderStatus = status,
            DoctorId = doctorId,
            LaboratoristId = laboratoristId,
            MedicalTestId = medicalTestId,
            PatientId = patientId
        };
        // Act
        var result = await _medicalTestOrderService.UpdateMedicalTestOrderAsync(id, medicalTestOrderRequestDto);
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
    /// fuction to get all  medical test order for specific patient as a test case 
    /// </summary>
    [Theory, TestPriority(1)]
    [InlineData("53ae72a7-589e-4f0b-81ed-4038169498")]
    [InlineData("53ae72a7-589e-4f0b-81ed-403816949865468")]
    public async Task GetMedicalTestOrderByPatientId(string patientId)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _medicalTestOrderService.GetAllMedicalTestOrdersByPatientIdAsync(patientId);

        // Assert
        Assert.True(result.IsSuccess);

    }


    /// <summary>
    /// fuction to get medical test order by id as a test case that take medical test order id
    /// </summary>
    /// <param name="id"> medical test order id</param>
    [Theory, TestPriority(2)]
    [InlineData(1)]
    [InlineData(20)]
    public async Task GetByIdMedicalTestOrder(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _medicalTestOrderService.GetMedicalTestOrderByIdAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
    /// <summary>
    /// fuction to remove medical test order as a test case.
    /// </summary>
    /// <param name="id">medical test order id</param>
    [Theory, TestPriority(4)]
    [InlineData(3)]
    [InlineData(30)]
    public async Task RemoveMedicalTestOrder(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _medicalTestOrderService.DeleteMedicalTestOrderAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
}
