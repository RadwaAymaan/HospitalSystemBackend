using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSWithLayers.API.Controllers;
public class SpecializationController(ISpecializationService specializationService) : BaseController
{
    private readonly ISpecializationService _specializationService = specializationService;
    /// <summary>
    /// action for add specialization that take specialization dto   
    /// </summary>
    /// <param name="specializationDto">specialization dto</param>
    /// <returns>result of specialization added successfully</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> AddSpecialization(SpecializationRequestDto SpecializationDto)
    {
        return await _specializationService.AddSpectializationAsync(SpecializationDto);
    }
    /// <summary>
    /// action for get all specialization  
    /// </summary>
    /// <returns>result of list from specialization response dto </returns>
    [HttpGet]
    [Authorize(Roles = ("Admin,Doctor,Nurse"))]
    [ProducesResponseType(typeof(Result<List<SpecializationResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<SpecializationResponseDto>>> GetAllSpecialization()
    {
        return await _specializationService.GetAllSpecializationsAsync();
    }
    /// <summary>
    /// action for get by id specialization  that take  specialization id
    /// </summary>
    /// <param name="id">specialization id</param>
    /// <returns>result of specialization response dto </returns>
    [HttpGet("{id}")]
    [Authorize(Roles = ("Admin,Doctor,Nurse"))]
    [ProducesResponseType(typeof(Result<SpecializationResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<SpecializationResponseDto>> GetSpecializationById(int id)
    {
        return await _specializationService.GetSpecializationByIdAsync(id);
    }
    /// <summary>
    /// action for update specialization by id that take  specialization id and specialization dto
    /// </summary>
    /// <param name="id">specialization id</param>
    /// <param name="specializationDto">specialization dto</param>
    /// <returns>result of specialization response dto after updated</returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<SpecializationResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<SpecializationResponseDto>> UpdateSpecialization(int id, SpecializationRequestDto specializationDto)
    {
        return await _specializationService.UpdateSpecializationAsycn(id, specializationDto);
    }
    /// <summary>
    /// action for remove  specialization by id that take specialization id 
    /// </summary>
    /// <param name="id">specialization id</param>
    /// <returns>result of specialization remove successfully</returns>
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> DeleteSpecialization(int id)
    {
        return await _specializationService.DeleteSpecializationAsync(id);
    }

}