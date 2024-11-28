using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HMSWithLayers.API.Controllers;

public class PrescriptionController(IPrescriptionService prescriptionService) : BaseController
{
    private readonly IPrescriptionService _prescriptionService = prescriptionService;

    /// <summary>
    /// action for get all prescriptions .
    /// </summary>
    /// <returns>result of list from prescription response dto</returns>
    [HttpGet]
    [Authorize(Roles = "Admin, Doctor")]
    [ProducesResponseType(typeof(Result<List<PrescriptionResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<PrescriptionResponseDto>>> GetAllIPrescriptions()
    {
        return await _prescriptionService.GetAllPrescriptionsAsync();
    }

    /// <summary>
    /// action for get a prescription by id that take prescription id.
    /// </summary>
    /// <param name="id">prescription id</param>
    /// <returns>result of prescription response dto</returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, Doctor")]
    [ProducesResponseType(typeof(Result<PrescriptionResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<PrescriptionResponseDto>> GetPrescriptionById(int id)
    {
        return await _prescriptionService.GetPrescriptionByIdAsync(id);
    }

    /// <summary>
    /// action for Add a new prescription that take prescription request dto.
    /// </summary>
    /// <param name="prescriptionDto">prescription request dto.</param>
    /// <returns>result of the prescription added successfully.</returns>
    [HttpPost]
    [Authorize(Roles = "Admin, Doctor")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> AddPrescription(PrescriptionRequestDto prescriptionDto)
    {
        return await _prescriptionService.AddPrescriptionAsync(prescriptionDto);
    }

    /// <summary>
    /// action for Update an existing prescription that take prescription request dto and prescription id.
    /// </summary>
    /// <param name="prescriptionDto">prescription request dto.</param>
    /// <param name="id">prescription id.</param>
    /// <returns>result of prescription response dto after updated successfully.</returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin, Doctor")]
    [ProducesResponseType(typeof(Result<PrescriptionResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<PrescriptionResponseDto>> UpdatePrescriptionAsync(PrescriptionRequestDto prescriptionDto, int id)
    {
        return await _prescriptionService.UpdatePrescriptionAsync(id,prescriptionDto);
    }

    /// <summary>
    /// action for remove a prescription that take prescription id.
    /// </summary>
    /// <param name="id">prescription id.</param>
    /// <returns>result of the prescription removed successfully.</returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin, Doctor")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> DeletePrescriptionAsync(int id)
    {
        return await _prescriptionService.DeletePrescriptionAsync(id);
    }
}
