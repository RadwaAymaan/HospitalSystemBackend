using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSWithLayers.API.Controllers;

public class PharmacistController(IPharmacistService pharmacistService) : BaseController
{
    private readonly IPharmacistService _pharmacistService = pharmacistService;

    /// <summary>
    /// action for add pharmacist that take pharmacist dto   
    /// </summary>
    /// <param name="pharmacistDto">pharmacist dto</param>
    /// <returns>result of pharmacist added successfully</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> AddPharmacis(PharmacistRequestDto pharmacistDto)
    {
        return await _pharmacistService.AddPharmacistAsync(pharmacistDto);
    }

    /// <summary>
    /// action for get all pharmacist  
    /// </summary>
    /// <returns>result of list from pharmacist response dto </returns>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<List<PharmacistResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<PharmacistResponseDto>>> GetAllPharmacist()
    {
        return await _pharmacistService.GetAllPharmacistsAsync();
    }

    /// <summary>
    /// action for get by id pharmacist  that take  pharmacist id
    /// </summary>
    /// <param name="id">pharmacist id</param>
    /// <returns>result of pharmacist response dto </returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Pharmacist")]
    [ProducesResponseType(typeof(Result<PharmacistResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<PharmacistResponseDto>> GetPharmacistById(string id)
    {
        return await _pharmacistService.GetPharmacistByIdAsync(id);
    }

    /// <summary>
    /// action for update pharmacist by id that take  pharmacist id and pharmacist dto
    /// </summary>
    /// <param name="id">pharmacist id</param>
    /// <param name="pharmacistDto">pharmacist dto</param>
    /// <returns>result of pharmacist response dto </returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<PharmacistResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<PharmacistResponseDto>> UpdatePharmacist(string id, PharmacistRequestDto pharmacistDto)
    {
        return await _pharmacistService.UpdatePharmacistAsycn(id, pharmacistDto);
    }

    /// <summary>
    /// action for remove  pharmacist by id that take pharmacist id 
    /// </summary>
    /// <param name="id">pharmacist id</param>
    /// <returns>result of pharmacist remove successfully</returns>
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> DeletePharmacist(string id)
    {
        return await _pharmacistService.DeletePharmacistAsync(id);
    }
}
