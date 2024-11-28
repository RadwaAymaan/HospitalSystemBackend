using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HMSWithLayers.API.Controllers;

public class MedicalHistoryController(IMedicalHistoryService medicalHistoryService) : BaseController
{
    private readonly IMedicalHistoryService _medicalHistoryService = medicalHistoryService;

    /// <summary>
    /// action for get all medical history for a specific patient.
    /// </summary>
    /// <returns>result of list from medical history response dto for a specific patient</returns>
    [HttpGet("Patient")]
    [ProducesResponseType(typeof(Result<List<MedicalHistoryResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Patient")]
    public async Task<Result<List<MedicalHistoryResponseDto>>> GetMedicalHistoryForPatient()
    {
        return await _medicalHistoryService.GetMedicalHistoryByPatientId(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }

    /// <summary>
    /// action for get medical history by id.
    /// </summary>
    /// <param name="id">id of the medical history.</param>
    /// <returns>result of medical history response dto for specific id</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Result<MedicalHistoryResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Admin, Doctor")]
    public async Task<Result<MedicalHistoryResponseDto>> GetMedicalHistoryById(int id)
    {
        return await _medicalHistoryService.GetMedicalHistoryeById(id);
    }

    /// <summary>
    /// action for add medical history that take medicine dto 
    /// </summary>
    /// <param name="medicalHistoryDto">The dto representing the medical history to add.</param>
    /// <returns>result of medical history added successfully. </returns>
    [HttpPost]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Admin, Doctor")]
    public async Task<Result> AddMedicalHistory(MedicalHistoryRequestDto medicalHistoryDto)
    {
        return await _medicalHistoryService.AddMedicalHistoryAsync(medicalHistoryDto);
    }

    /// <summary>
    /// action for medical history that take id for medical history and medicine dto.
    /// </summary>
    /// <param name="id">the id of the medical history</param>
    /// <param name="medicalHistoryDto">the dto representing the updated medical history.</param>
    /// <returns>result of medical history updated successfully. </returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Result<MedicalHistoryResponseDto?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Admin, Doctor")]
    public async Task<Result<MedicalHistoryResponseDto>> UpdateMedicalHistory(int id, MedicalHistoryRequestDto medicalHistoryDto)
    {
        return await _medicalHistoryService.UpdateMedicalHistory(id, medicalHistoryDto);
    }

    /// <summary>
    /// action for remove medical history by id that take medical history id .
    /// </summary>
    /// <param name="id">the id of the medical history.</param>
    /// <returns>result of medical history remove successfully.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Admin, Doctor")]
    public async Task<Result> DeleteMedicalHistory(int id)
    {
        return await _medicalHistoryService.DeleteMedicalHistory(id);
    }
}
