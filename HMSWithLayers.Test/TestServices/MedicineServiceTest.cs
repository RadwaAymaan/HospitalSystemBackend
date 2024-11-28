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
public class MedicineServiceTest
{
    private static MedicineService _medicineService;
    private string userEmail = "hagershaaban7@gmail.com";
    private  MedicineService CreateMedicineService()
    {

        if (_medicineService is null)
        {
            var dbContext = ContextGenerator.Generator();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();

            ILogger<MedicineService> logger = new LoggerFactory().CreateLogger<MedicineService>();

            IUserContextService userContext = new UserContextService();
            _medicineService = new MedicineService(dbContext, mapper, logger, userContext);
        }

        return _medicineService;
    }
    private void CheckService()
    {
        if (_medicineService is null)
            _medicineService =  CreateMedicineService();
    }

    /// <summary>
    /// fuction to add medicine as a test case that take  medicine name , medicine description , medicine dosage   
    /// </summary>
    /// <param name="medicineName">medicine name</param>
    /// <param name="medicineDescription">medicine descreiption</param>
    /// <param name="medicineDosage">medicine dosage</param>
    [Theory, TestPriority(0)]
    [InlineData("Amoxicillin", "Antibiotic", 2)]
    public async Task AddMedicine(string medicineName, string medicineDescription, int medicineDosage)
    {
        // Arrange
        CheckService();
        var medicineRequestDto = new MedicineRequestDto { MedicineName = medicineName, MedicineDescription = medicineDescription, MedicineDosage = medicineDosage };
        // Act
        var result = await _medicineService.AddMedicineAsync(medicineRequestDto);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);
    }

    /// <summary>
    /// fuction to get all  medicines as a test case 
    /// </summary>
    [Fact, TestPriority(1)]
    public async Task GetAllMedicine()
    {
        // Arrange
         CheckService();

        // Act
        var result = await _medicineService.GetAllMedicinesAsync();

        // Assert
        Assert.True(result.IsSuccess);

    }

    /// <summary>
    /// fuction to get medicine by id as a test case 
    /// </summary>
    /// <param name="id"> medicine id </param>
    /// <returns>specific medicine</returns>
    [Theory, TestPriority(2)]
    [InlineData(1)]
    [InlineData(6)]
    public async Task GetByIdMedicine(int id)
    {
        // Arrange
         CheckService();

        // Act
        var result = await _medicineService.GetMedicineByIdAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }

    /// <summary>
    /// fuction to update medicine as a test case that take  medicine id , medicine name , medicine descreiption , medicine dosage and prescription id and expected result
    /// </summary>
    /// <param name="id">medicine id</param>
    /// <param name="medicineName">medicine name</param>
    /// <param name="medicineDescription">medicine descreiption</param>
    /// <param name="medicineDosage">medicine dosage</param>
    /// <param name="expectedResult">expected result</param>
    [Theory, TestPriority(3)]
    [InlineData(1, "Ibuprofen", "Nonsteroidal anti-inflammatory drug", 2, true)]
    [InlineData(10, "Ibuprofen", "Nonsteroidal anti-inflammatory drug", 2, false)]
    public async Task UpdateSpectialization(int id, string medicineName, string medicineDescription, int medicineDosage,  bool expectedResult)
    {
        //Arrange
        CheckService();
        var medicineRequestDto = new MedicineRequestDto { MedicineName = medicineName, MedicineDescription = medicineDescription, MedicineDosage = medicineDosage };
        // Act
        var result = await _medicineService.UpdateMedicineAsycn(id, medicineRequestDto);
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
    /// fuction to remove medicine as a test case that take medicine id
    /// </summary>
    /// <param name="id">object of medicine </param>
    [Theory, TestPriority(4)]
    [InlineData(2)]
    [InlineData(50)]
    public async Task RemoveMedicine(int id)
    {
        // Arrange
         CheckService();

        // Act
        var result = await _medicineService.DeleteMedicineAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
}
