using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSWithLayers.API.Controllers;
public class LaboratoriestController(ILaboratoriestService laboratoriestService) : BaseController
{
    private readonly ILaboratoriestService _laboratoriestService = laboratoriestService;

    /// <summary>
    /// action for add laboratoriest that take laboratoriest dto   
    /// </summary>
    /// <param name="LaboratoriestDto">laboratoriest dto</param>
    /// <returns>result from laboratoriest added successfully</returns>

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> AddLaboratoriest(LaboratoriestRequestDto laboratoriestDto)
    {
        return await _laboratoriestService.AddLaboratoriestAsync(laboratoriestDto);
    }

    /// <summary>
    /// action for get all laboratoriest  
    /// </summary>
    /// <returns>result of list from laboratoriest response dto </returns>

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<List<LaboratoriestResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<LaboratoriestResponseDto>>> GetAllLaboratoriests()
    {
        return await _laboratoriestService.GetAllLaboratoriestsAsync();
    }

    /// <summary>
    /// action for get laboratoriest by id that take  laboratoriest id
    /// </summary>
    /// <param name="id">laboratoriest id</param>
    /// <returns>result of laboratoriest response dto</returns>

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<LaboratoriestResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<LaboratoriestResponseDto>> GetLaboratoriestById(string id)
    {
        return await _laboratoriestService.GetLaboratoriestByIdAsync(id);
    }

    /// <summary>
    /// action for update laboratoriest by id that take laboratoriest id and laboratoriest dto
    /// </summary>
    /// <param name="id">laboratoriest id</param>
    /// <param name="LaboratoriestDto">laboratoriest dto</param>
    /// <returns>result of laboratoriest response dto after updated</returns>

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<LaboratoriestResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<LaboratoriestResponseDto>> UpdateLaboratoriest(string id, LaboratoriestRequestDto laboratoriestDto)
    {
        return await _laboratoriestService.UpdateLaboratoriestAsync(id, laboratoriestDto);
    }

    /// <summary>
    /// action for remove laboratoriest by id that take laboratoriest id as query string 
    /// </summary>
    /// <param name="id">laboratoriest id</param>
    /// <returns>result of laboratoriest remove successfully</returns> 

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> DeleteLaboratoriest(string id)
    {
        return await _laboratoriestService.DeleteLaboratoriestAsync(id);
    }
}
