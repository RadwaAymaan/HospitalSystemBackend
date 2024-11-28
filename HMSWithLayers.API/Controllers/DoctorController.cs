using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSWithLayers.API.Controllers;
public class DoctorController(IDoctorService doctorService) : BaseController
{
    private readonly IDoctorService _doctorService = doctorService;
    /// <summary>
    /// action for add doctor that take doctor dto   
    /// </summary>
    /// <param name="doctorDto">doctor dto</param>
    /// <returns>result of an added doctor successfully</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> AddDoctor(DoctorRequestDto doctorDto)
    {
        return await _doctorService.AddDoctorAsync(doctorDto);
    }

    /// <summary>
    /// action for get all doctor  
    /// </summary>
    /// <returns>result of list from doctor response dto </returns>
    [HttpGet]
    [Authorize(Roles = "Admin,Patient")]
    [ProducesResponseType(typeof(Result<List<DoctorResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<DoctorResponseDto>>> GetAllDoctor()
    {
        return await _doctorService.GetAllDoctorsAsync();
    }

    /// <summary>
    /// action for get by id doctor  that take  doctor id
    /// </summary>
    /// <param name="id">doctor id</param>
    /// <returns>result of doctor response dto </returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Patient")]
    [ProducesResponseType(typeof(Result<DoctorResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<DoctorResponseDto>> GetDoctorById(string id)
    {
        return await _doctorService.GetDoctorByIdAsync(id);
    }

    /// <summary>
    /// action for update doctor by id that take  doctor id and doctor dto
    /// </summary>
    /// <param name="id">doctor id</param>
    /// <param name="doctorDto">doctor dto</param>
    /// <returns>result of doctor response dto after updated</returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Doctor")]
    [ProducesResponseType(typeof(Result<DoctorResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<DoctorResponseDto>> UpdateDoctor(string id, DoctorRequestDto doctorDto)
    {
        return await _doctorService.UpdateDoctorAsycn(id, doctorDto);
    }

    /// <summary>
    /// action for remove  doctor by id that take doctor id 
    /// </summary>
    /// <param name="id">doctor id</param>
    /// <returns>result of doctor remove successfully</returns>
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> DeleteDoctor(string id)
    {
        return await _doctorService.DeleteDoctorAsync(id);
    }
}

