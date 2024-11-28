using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HMSWithLayers.API.Controllers;


public class MedicalTestController(IMedicalTestService medicalTestService) : BaseController
{
    private readonly IMedicalTestService _medicalTestServices = medicalTestService;

    /// <summary>
    /// action for get all lab tests .
    /// </summary>
    /// <returns>result of list from lab tests response dto </returns>
    [HttpGet("Lab")]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result<List<LabResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<LabResponseDto>>> GetAllLabTests()
    {
        return await _medicalTestServices.GetAllLabsAsync();
    }

    /// <summary>
    /// action for get lab test by id that take lab test id.
    /// </summary>
    /// <param name="id">id for the lab test</param>
    /// <returns>result of lab tests response dto </returns>
    [HttpGet("Lab/{id}")]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result<LabResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<LabResponseDto>> GetLabTestById(int id)
    {
        return await _medicalTestServices.GetLabByIdAsync(id);
    }

    /// <summary>
    /// action for Add a new lab test that take lab request dto.
    /// </summary>
    /// <param name="labDto"> lab test request dto</param>
    /// <returns>result of lab tests added successfully</returns>
    [HttpPost("Lab")]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> AddLabTestAsync(LabRequestDto labDto)
    {
        return await _medicalTestServices.AddLabAsync(labDto);
    }

    /// <summary>
    /// action for update an existing lab test that take lab test request dto.
    /// </summary>
    /// <param name="id">id for  lab test.</param>
    /// <param name="labDto">lab test request dto.</param>
    /// <returns>result of lab tests response dto after updated successfully</returns>
    [HttpPut("Lab/{id}")]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result<LabResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<LabResponseDto>> UpdateLabTestAsync(int id, LabRequestDto labDto)
    {
        return await _medicalTestServices.UpdateLabAsync(id, labDto);
    }

    /// <summary>
    /// action for remove  lab test that take lab test id.
    /// </summary>
    /// <param name="id">id for  lab test.</param>
    /// <returns>result of lab tests removed successfully</returns>
    [HttpDelete("Lab/{id}")]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> DeleteLabTestAsync(int id)
    {
        return await _medicalTestServices.DeleteLabAsync(id);
    }


    /// <summary>
    /// action for get  all scan tests.
    /// </summary>
    /// <returns>result of list from scan tests </returns>
    [HttpGet("Scan")]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result<List<ScanResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<ScanResponseDto>>> GetAllScanTests()
    {
        return await _medicalTestServices.GetAllScansAsync();
    }

    /// <summary>
    /// action for get by id  scan test that take lab scan id.
    /// </summary>
    /// <param name="id">id scan test </param>
    /// <returns>result of scan test </returns>
    [HttpGet("Scan/{id}")]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result<ScanResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<ScanResponseDto>> GetScanTestById(int id)
    {
        return await _medicalTestServices.GetScanByIdAsync(id);
    }

    /// <summary>
    /// action for Add a new scan test that take scan test request dto.
    /// </summary>
    /// <param name="scanDto"> scan test request dto.</param>
    /// <returns>result of scan test added successfully.</returns>
    [HttpPost("Scan")]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> AddScanTestAsync(ScanRequestDto scanDto)
    {
        return await _medicalTestServices.AddScanAsync(scanDto);

    }

    /// <summary>
    /// action for update an existing scan test that take scan test request dto and scan test id.
    /// </summary>
    /// <param name="id">id for scan test.</param>
    /// <param name="scanDto">scan test request dto.</param>
    /// <returns>result of scan test response dto after updated successfully.</returns>
    [HttpPut("Scan/{id}")]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result<ScanResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<ScanResponseDto>> UpdateScanTestAsync(int id, ScanRequestDto scanDto)
    {
        return await _medicalTestServices.UpdateScanAsync(id, scanDto);
    }

    /// <summary>
    /// action for remove  scan test that take scan test id.
    /// </summary>
    /// <param name="id">id for scan test.</param>
    /// <returns>result of scan test added successfully.</returns>
    [HttpDelete("Scan/{id}")]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> DeleteScanTestAsync(int id)
    {
        return await _medicalTestServices.DeleteScanAsync(id);
    }
}
