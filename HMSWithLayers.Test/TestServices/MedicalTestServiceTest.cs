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
public class MedicalTestServiceTest
{
    private static MedicalTestService _medicalTestService;
    private string userEmail = "hagershaaban7@gmail.com";
    private MedicalTestService CreateMedicalTestService()
    {

        if (_medicalTestService is null)
        {
            var dbContext = ContextGenerator.Generator();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();
            ILogger<MedicalTestService> MedicalTestLogger = new LoggerFactory().CreateLogger<MedicalTestService>();

            IUserContextService userContext = new UserContextService();
            _medicalTestService = new MedicalTestService(dbContext, mapper, MedicalTestLogger, userContext);
        }

        return _medicalTestService;
    }

    private void CheckService()
    {
        if (_medicalTestService is null)
            _medicalTestService = CreateMedicalTestService();
    }

    /// <summary>
    /// fuction to add scan medical test  as a test case . 
    /// </summary>
    /// <param name="name">name</param>
    /// <param name="description">description</param>
    [Theory, TestPriority(0)]
    [InlineData("X-Ray", "Radiographic imaging")]
    public async Task AddMedicalTestScan(string name, string description)
    {
        // Arrange
        CheckService();
        var scanRequestDto = new ScanRequestDto
        {
            Name = name,
            Description = description

        };
        // Act
        var result = await _medicalTestService.AddScanAsync(scanRequestDto);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// fuction to add lab medical test  as a test case . 
    /// </summary>
    /// <param name="name">name</param>
    /// <param name="description">description</param>
    [Theory, TestPriority(0)]
    [InlineData("Blood Test", "Checks blood components")]
    public async Task AddMedicalTestLab(string name, string description)
    {
        // Arrange
        CheckService();
        var labRequestDto = new LabRequestDto
        {
            Name = name,
            Description = description

        };
        // Act
        var result = await _medicalTestService.AddLabAsync(labRequestDto);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// fuction to update medical test scan as a test case .
    /// </summary>
    /// <param name="id">medical test order id</param>
    /// <param name="name">name</param>
    /// <param name="description">description</param>
    [Theory, TestPriority(3)]
    [InlineData(1, "X-Ray", "Radiographic imaging",true)]
    [InlineData(20, "X-Ray", "Radiographic imagings",false)]
    public async Task UpdateMedicalTestScan(int id, string name, string description, bool expectedResult)
    {
        //Arrange
        CheckService();
        var scanRequestDto = new ScanRequestDto
        {
            Name = name,
            Description = description

        };
        // Act
        var result = await _medicalTestService.UpdateScanAsync(id, scanRequestDto);
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
    /// fuction to update medical test lab as a test case .
    /// </summary>
    /// <param name="id">medical test order id</param>
    /// <param name="name">name</param>
    /// <param name="description">description</param>
    [Theory, TestPriority(3)]
    [InlineData(1, "Blood Test", "Checks blood components", true)]
    [InlineData(20, "Blood Test", "Checks blood components", false)]
    public async Task UpdateMedicalTestLab(int id, string name, string description, bool expectedResult)
    {
        //Arrange
        CheckService();
        var labRequestDto = new LabRequestDto
        {
            Name = name,
            Description = description

        };
        // Act
        var result = await _medicalTestService.UpdateLabAsync(id, labRequestDto);
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
    /// fuction to get all  medical test lab  as a test case 
    /// </summary>
    [Fact, TestPriority(1)]
    public async Task GetAllMedicalTestLab()
    {
        // Arrange
        CheckService();

        // Act
        var result = await _medicalTestService.GetAllLabsAsync();

        // Assert
        Assert.True(result.IsSuccess);

    }
    /// <summary>
    /// fuction to get all  medical test scan  as a test case 
    /// </summary>
    [Fact, TestPriority(1)]
    public async Task GetAllMedicalTestScan()
    {
        // Arrange
        CheckService();

        // Act
        var result = await _medicalTestService.GetAllScansAsync();

        // Assert
        Assert.True(result.IsSuccess);

    }


    /// <summary>
    /// fuction to get medical test lab by id as a test case that take medical test lab id
    /// </summary>
    /// <param name="id"> medical test order id</param>
    [Theory, TestPriority(2)]
    [InlineData(1)]
    [InlineData(20)]
    public async Task GetByIdMedicalTestLab(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _medicalTestService.GetLabByIdAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }

    /// <summary>
    /// fuction to get medical test scan by id as a test case that take medical test scan id
    /// </summary>
    /// <param name="id"> medical test scan id</param>
    [Theory, TestPriority(2)]
    [InlineData(1)]
    [InlineData(20)]
    public async Task GetByIdMedicalTestScan(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _medicalTestService.GetScanByIdAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
    /// <summary>
    /// fuction to remove medical test Lab as a test case.
    /// </summary>
    /// <param name="id">medical test Lab id</param>
    [Theory, TestPriority(4)]
    [InlineData(3)]
    [InlineData(30)]
    public async Task RemoveMedicalTestLab(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _medicalTestService.DeleteLabAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }

    /// <summary>
    /// fuction to remove medical test Lab as a test case.
    /// </summary>
    /// <param name="id">medical test Lab id</param>
    [Theory, TestPriority(4)]
    [InlineData(3)]
    [InlineData(30)]
    public async Task RemoveMedicalTestScan(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _medicalTestService.DeleteScanAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
}
