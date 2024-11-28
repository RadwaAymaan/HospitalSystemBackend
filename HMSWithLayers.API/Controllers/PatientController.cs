using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSWithLayers.API.Controllers;
public class PatientController(IPatientService patientService) : BaseController
{
    private readonly IPatientService _patientService = patientService;

    /// <summary>
    /// action for get all  patients that take list of patient response dto  
    /// </summary>
    /// <returns>result of list from patient response dto</returns>

    [HttpGet]
    [Authorize(Roles = "Admin,Doctor")]
    [ProducesResponseType(typeof(Result<List<PatientGetAllResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<PatientGetAllResponseDto>>> GetAllPatients()
    {
        return await _patientService.GetAllPatientsAsync();
    }


    /// <summary>
    /// action for get patient by id that take patient id
    /// </summary>
    /// <param name="id">patient id</param>
    /// <returns>result of patient  response dto</returns>

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Doctor")]
    [ProducesResponseType(typeof(Result<PatientByIdResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<PatientByIdResponseDto>> GetPatientById(string id)
    {
        return await _patientService.GetPatientByIdAsync(id);
    }

    /// <summary>
    /// action for update patient by id that take patient id and patient dto 
    /// </summary>
    /// <param name="id">patient id</param>
    /// <param name="PatientDto">patient dto</param>
    /// <returns>result of patient response dto after updated</returns>

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Patient")]
    [ProducesResponseType(typeof(Result<PatientByIdResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<PatientByIdResponseDto>> UpdatePatient(string id, PatientRequestDto patientDto)
    {
        return await _patientService.UpdatePatientAsync(id, patientDto);
    }

    /// <summary>
    /// action for remove patient by id that take patient id .
    /// </summary>
    /// <param name="id">patient id</param>
    /// <returns>result of patient remove successfully</returns>

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> DeletePatient(string id)
    {
        return await _patientService.DeletePatientAsync(id);
    }
}
