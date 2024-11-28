using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HMSWithLayers.API.Controllers;

public class MedicalTestResultController(IMedicalTestResultService medicalTestResultService) : BaseController
{
    private readonly IMedicalTestResultService _medicalTestResultService = medicalTestResultService;

    /// <summary>
    /// action for get all medical test result.
    /// </summary>
    /// <returns>result of list from medical test result response dto</returns>
    [HttpGet]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result<List<MedicalTestResultResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]

    public async Task<Result<List<MedicalTestResultResponseDto>>> GetAllMedicalTestResults()
    {
        return await _medicalTestResultService.GetAllMedicalTestResultsAsync();
    }

    /// <summary>
    /// action for get all medical test results for a specific patient.
    /// </summary>
    /// <returns>result of list from medical test result response dto for a specific patient</returns>
    [HttpGet("Patient")]
    [Authorize(Roles = "Patient")]
    [ProducesResponseType(typeof(Result<List<MedicalTestResultResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]

    public async Task<Result<List<MedicalTestResultResponseDto>>> GetAllMedicalTestResultsForPatient()
    {
        return await _medicalTestResultService.GetAllMedicalTestResultsByPatientIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }

    /// <summary>
    /// action for get medical test result by id that take medical test result id.
    /// </summary>
    /// <param name="id">medical test result id.</param>
    /// <returns>result of medical test result response dto</returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, Laboratorist , Patient")]
    [ProducesResponseType(typeof(Result<MedicalTestResultResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<MedicalTestResultResponseDto>> GetMedicalTestResultById(int id)
    {
        return await _medicalTestResultService.GetMedicalTestResultByIdAsync(id);
    }

    /// <summary>
    /// action for Add new a medical test result that take medical test result request dto.
    /// </summary>
    /// <param name="medicalTestResultDto">medical test result request dto</param>
    /// <returns>result of medical test result added successfully</returns>
    [HttpPost]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]

    public async Task<Result> AddMedicalTestResult(MedicalTestResultRequestDto medicalTestResultDto)
    {
        return await _medicalTestResultService.AddMedicalTestResultAsync(medicalTestResultDto);
    }

    /// <summary>
    /// action for update a medical test result that take medical test result request dto and medical test result id.
    /// </summary>
    /// <param name="id">medical test result id.</param>
    /// <param name="medicalTestResultDto">medical test result request dto</param>
    /// <returns>result of medical test result response dto after updated</returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result<MedicalTestResultResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]

    public async Task<Result<MedicalTestResultResponseDto>> UpdateMedicalTestResult(int id, MedicalTestResultRequestDto medicalTestResultDto)
    {
        return await _medicalTestResultService.UpdateMedicalTestResultAsync(id, medicalTestResultDto);
    }

    /// <summary>
    /// action for remove medical test result that take medical test result id.
    /// </summary>
    /// <param name="id">medical test result id.</param>
    /// <returns>result of medical test result removed successfully</returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]

    public async Task<Result> DeleteMedicalTestResult(int id)
    {
        return await _medicalTestResultService.DeleteMedicalTestResultAsync(id);
    }
}