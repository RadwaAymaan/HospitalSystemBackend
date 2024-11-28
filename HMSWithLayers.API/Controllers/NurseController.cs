using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Application.Services;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSWithLayers.API.Controllers;

public class NurseController(INurseService nurseService) : BaseController
{
    private readonly INurseService _nurseService = nurseService;

    /// <summary>
    /// action for add nurse that take nurse dto   
    /// </summary>
    /// <param name="nurseDto">nurse dto</param>
    /// <returns>result nurse added successfully</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> AddNurse(NurseRequestDto nurseDto)
    {
        return await _nurseService.AddNurseAsync(nurseDto);
    }


    /// <summary>
    /// action for get all nurse  
    /// </summary>
    /// <returns>result of list from nurse response dto </returns>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<List<NurseGetAllResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<NurseGetAllResponseDto>>> GetAllNurse()
    {
        return await _nurseService.GetAllNurseAsync();
    }

    /// <summary>
    /// action for get by id nurse  that take  nurse id
    /// </summary>
    /// <param name="id">nurse id</param>
    /// <returns>result of nurse response dto </returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Patient,Doctor")]
    [ProducesResponseType(typeof(Result<NurseResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<NurseResponseDto>> GetNurseById(string id)
    {
        return await _nurseService.GetNurseByIdAsync(id);
    }

    /// <summary>
    /// action for update nurse by id that take  nurse id and nurse dto
    /// </summary>
    /// <param name="id">nurse id</param>
    /// <param name="nurseDto">nurse dto</param>
    /// <returns>result of nurse response dto afetr updated</returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<NurseResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<NurseResponseDto>> UpdateNurse(string id, NurseRequestDto nurseDto)
    {
        return await _nurseService.UpdateNurseAsync(id, nurseDto);
    }

    /// <summary>
    /// action for remove  nurse by id that take nurse id 
    /// </summary>
    /// <param name="id">nurse id</param>
    /// <returns>result of nurse remove successfully</returns>
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> DeleteNurse(string id)
    {
        return await _nurseService.DeleteNurseAsync(id);
    }
}
