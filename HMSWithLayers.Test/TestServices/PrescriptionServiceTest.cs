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
public class PrescriptionServiceTest
{
    private static PrescriptionService _prescriptionService;
    private string userEmail = "hagershaaban7@gmail.com";
    private PrescriptionService CreatePrescriptionService()
    {

        if (_prescriptionService is null)
        {
            var dbContext = ContextGenerator.Generator();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();

            ILogger<PrescriptionService> logger = new LoggerFactory().CreateLogger<PrescriptionService>();

            IUserContextService userContext = new UserContextService();
            _prescriptionService = new PrescriptionService(dbContext, mapper, logger, userContext);
        }

        return _prescriptionService;
    }
    private void CheckService()
    {
        if (_prescriptionService is null)
            _prescriptionService = CreatePrescriptionService();
    }

    /// <summary>
    /// fuction to add Prescription as a test case .   
    /// </summary>
    /// <param name="name">Prescription name</param>
    /// <param name="description">Prescription descreiption</param>
    /// <param name="date">Prescription date</param>
    /// <param name="doctorId">doctor id</param>
    /// <param name="medicineId">medicine id</param>
    /// <param name="patientId">patient id</param>
    [Theory, TestPriority(0)]
    [InlineData("Pain reliever", "Pain and fever reliever", "2024-03-14 12:30:00", "53ae72a7-589e-4f0b-81ed-40389f683027", "53ae72a7-589e-4f0b-81ed-4038169498",1)]
    public async Task AddPrescription(string name, string description,string date,string doctorId, string patientId,int medicineId)
    {
        // Arrange
        CheckService();
        var PrescriptionRequestDto = new PrescriptionRequestDto { Name = name, Description= description ,Date = DateTime.Parse(date),DoctorId = doctorId, MedicineId = medicineId, PatientId= patientId };
        // Act
        var result = await _prescriptionService.AddPrescriptionAsync(PrescriptionRequestDto);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);
    }

    /// <summary>
    /// fuction to get all  Prescriptions as a test case 
    /// </summary>
    /// <returns>boolean for check result is success or failed</returns>
    [Fact, TestPriority(1)]
    public async Task GetAllPrescription()
    {
        // Arrange
        CheckService();

        // Act
        var result = await _prescriptionService.GetAllPrescriptionsAsync();

        // Assert
        Assert.True(result.IsSuccess);

    }

    /// <summary>
    /// fuction to get Prescription by id as a test case 
    /// </summary>
    /// <param name="Prescription">list of Prescription </param>
    /// <returns>list of Prescription</returns>
    [Theory, TestPriority(2)]
    [InlineData(1)]
    [InlineData(6)]
    public async Task GetByIdPrescription(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _prescriptionService.GetPrescriptionByIdAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }

    /// <summary>
    /// fuction to update Prescription as a test case that take  Prescription id , Prescription name , Prescription descreiption , Prescription dosage and prescription id and expected result
    /// </summary>
    /// <param name="name">Prescription name</param>
    /// <param name="description">Prescription descreiption</param>
    /// <param name="date">Prescription date</param>
    /// <param name="doctorId">doctor id</param>
    /// <param name="medicineId">medicine id</param>
    /// <param name="patientId">patient id</param>
    [Theory, TestPriority(3)]
    [InlineData(1,"Pain reliever", "Pain and fever reliever", "2024-03-14 12:30:00", "53ae72a7-589e-4f0b-81ed-40389f683027", "53ae72a7-589e-4f0b-81ed-4038169498", 1,true)]
    [InlineData(10,"Pain reliever", "Pain and fever reliever", "2024-03-14 12:30:00", "53ae72a7-589e-4f0b-81ed-40389f683027", "53ae72a7-589e-4f0b-81ed-4038169498", 1,false)]
    public async Task UpdateSpectialization(int id, string name, string description, string date, string doctorId, string patientId, int medicineId, bool expectedResult)
    {
        //Arrange
        CheckService();
        var PrescriptionRequestDto = new PrescriptionRequestDto { Name = name, Description = description, Date = DateTime.Parse(date), DoctorId = doctorId, MedicineId = medicineId, PatientId = patientId };
        // Act
        var result = await _prescriptionService.UpdatePrescriptionAsync(id, PrescriptionRequestDto);
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
    /// fuction to remove Prescription as a test case that take Prescription id
    /// </summary>
    /// <param name="Prescription">object of Prescription </param>
    /// <returns>Prescription remove successfully</returns>
    [Theory, TestPriority(4)]
    [InlineData(2)]
    [InlineData(50)]
    public async Task RemovePrescription(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _prescriptionService.DeletePrescriptionAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
}
