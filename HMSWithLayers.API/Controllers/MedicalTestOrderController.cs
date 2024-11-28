using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HMSWithLayers.API.Controllers;

public class MedicalTestOrderController(IMedicalTestOrderService medicalTestOrderService) : BaseController
{
    private readonly IMedicalTestOrderService _medicalTestOrderService = medicalTestOrderService;

    /// <summary>
    /// action for get  all medical test orders .
    /// </summary>
    /// <returns>result of list from medical test orders response dto</returns>
    [HttpGet]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result<List<MedicalTestOrderResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]

    public async Task<Result<List<MedicalTestOrderResponseDto>>> GetAllMedicalTestOrders()
    {
        return await _medicalTestOrderService.GetAllMedicalTestOrdersAsync();
    }

    /// <summary>
    /// action for get all medical test orders for a specific patient.
    /// </summary>
    /// <returns>result of list from medical test orders response dto for a specific patient</returns>
    [HttpGet("Patient")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Patient")]
    public async Task<Result<List<MedicalTestOrderResponseDto>>> GetAllMedicalTestOrdersForPatient()
    {
        return await _medicalTestOrderService.GetAllMedicalTestOrdersByPatientIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }

    /// <summary>
    /// action for get medical test order by id.
    /// </summary>
    /// <returns>result of  medical test orders response dto </returns>    
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result<MedicalTestOrderResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]

    public async Task<Result<MedicalTestOrderResponseDto>> GetMedicalTestOrderById(int id)
    {
        return await _medicalTestOrderService.GetMedicalTestOrderByIdAsync(id);
    }

    /// <summary>
    /// action for Add a medical test order that take medical test order request dto.
    /// </summary>
    /// <param name="medicalTestOrderDto">medical test order request dto</param>
    /// <returns>result of medical test order added successfully.</returns>
    [HttpPost]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]

    public async Task<Result> AddMedicalTestOrder(MedicalTestOrderRequestDto medicalTestOrderDto)
    {
        return await _medicalTestOrderService.AddMedicalTestOrderAsync(medicalTestOrderDto);
    }

    /// <summary>
    /// action for update a medical test order that take medical test order request dto and id .
    /// </summary>
    /// <param name="medicalTestOrderDto">medical test order request dto</param>
    /// <param name="id">medical test order id</param>
    /// <returns>result of medical test order reqponse dto after updated successfully.</returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin, Laboratorist")]
    [ProducesResponseType(typeof(Result<MedicalTestOrderResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]

    public async Task<Result<MedicalTestOrderResponseDto>> UpdateMedicalTestOrder(int id, MedicalTestOrderRequestDto medicalTestOrderDto)
    {
        return await _medicalTestOrderService.UpdateMedicalTestOrderAsync(id, medicalTestOrderDto);
    }

    /// <summary>
    /// action for remove a medical test order that take medical test order id.
    /// </summary>
    /// <param name="id">medical test order id</param>
    /// <returns>result of medical test order remove successfully.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Admin, Laboratorist")]
    public async Task<Result> DeleteMedicalTestOrder(int id)
    {
        return await _medicalTestOrderService.DeleteMedicalTestOrderAsync(id);
    }
}
