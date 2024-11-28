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
using HMSWithLayers.Application.Contracts;

namespace HMSWithLayers.Test.TestServices;
[TestCaseOrderer(
ordererTypeName: "HMSWithLayers.Test.TestPriority.PriorityOrderer",
ordererAssemblyName: "HMSWithLayers.Test")]
public class SpecializationServiceTest
{
    private static SpecializationService _specializationService;

    private SpecializationService CreateSpecializationService()
    {

        if (_specializationService is null)
        {
            var dbContext = ContextGenerator.Generator();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();
            ILogger<SpecializationService> SpecializationLogger = new LoggerFactory().CreateLogger<SpecializationService>();

            _specializationService = new SpecializationService(dbContext, mapper, SpecializationLogger);
        }

        return _specializationService;
    }

    private void CheckService()
    {
        if (_specializationService is null)
            _specializationService = CreateSpecializationService();
    }

    /// <summary>
    /// fuction to add specialization as a test case that take  specialization name . 
    /// </summary>
    /// <param name="specializationName">specialization name</param>
    [Theory, TestPriority(0)]
    [InlineData("Cardiology")]
    public async Task AddSpecialization(string specializationName)
    {
        // Arrange
        CheckService();
        var specializationRequestDto = new SpecializationRequestDto { SpecializationName = specializationName};
        // Act
        var result = await _specializationService.AddSpectializationAsync(specializationRequestDto);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// fuction to update specialization as a test case .
    /// </summary>
    /// <param name="specializationName">specialization name</param>
    /// <param name="id">specialization id</param>
    /// <param name="expectedResult">expected result</param>
    [Theory, TestPriority(3)]
    [InlineData(1, "Forensic Pathology", true)]
    [InlineData(20, "Forensic Pathology", false)]
    public async Task UpdateSpecializationAsync(int id, string specializationName,bool expectedResult)
    {
        //Arrange
        CheckService();
        var specializationRequestDto = new SpecializationRequestDto
        {
            SpecializationName = specializationName
        };
        // Act
        var result = await _specializationService.UpdateSpecializationAsycn(id, specializationRequestDto);
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
    /// fuction to get all  specialization as a test case 
    /// </summary>
    [Fact, TestPriority(1)]
    public async Task GetAllSpecialization()
    {
        // Arrange
        CheckService();

        // Act
        var result = await _specializationService.GetAllSpecializationsAsync();

        // Assert
        Assert.True(result.IsSuccess);

    }
    /// <summary>
    /// fuction to get specialization by id as a test case that take specialization id
    /// </summary>
    /// <param name="id"> Specialization id</param>
    [Theory, TestPriority(2)]
    [InlineData(1)]
    [InlineData(20)]
    public async Task GetByIdSpecialization(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _specializationService.GetSpecializationByIdAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
    /// <summary>
    /// fuction to remove specialization as a test case that take specialization id
    /// </summary>
    /// <param name="id">Specialization id</param>
    [Theory, TestPriority(4)]
    [InlineData(2)]
    [InlineData(30)]
    public async Task RemoveSpecialization_ReturnResult(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _specializationService.DeleteSpecializationAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
}
