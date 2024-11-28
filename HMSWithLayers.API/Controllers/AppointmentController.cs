using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Application.Services;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HMSWithLayers.API.Controllers;


public class AppointmentController(IAppointmentService appointmentService) : BaseController
{
    private readonly IAppointmentService _appointmentService= appointmentService;


    /// <summary>
    /// gets all appointments.
    /// </summary>
    /// <returns>a Result of list from  appointment response dtos</returns>
    [HttpGet]
    [Authorize(Roles = "Admin, Doctor, Patient")]
    [ProducesResponseType(typeof(Result<List<AppointmentResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<AppointmentResponseDto>>> GetAllAppointmentsAsync()
    {
        return await _appointmentService.GetAllAppointmentAsync();
    }

    /// <summary>
    /// gets an appointment by id.
    /// </summary>
    /// <param name="id">the id for appointment to retrieve</param>
    /// <returns>a result of appointment response dto </returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, Doctor, Patient")]
    [ProducesResponseType(typeof(Result<AppointmentResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<AppointmentResponseDto>> GetAppointmentByIdAsync(int id)
    {
        return await _appointmentService.GetAppointmentByIdAsync(id);
    }

    /// <summary>
    /// adds new appointment that take appointment dto.
    /// </summary>
    /// <param name="appointmentDto">the appointment to create</param>
    /// <returns>result of an added appointment successfully</returns>
    [HttpPost]
    [Authorize(Roles = "Admin, Patient")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> AddAppointmentAsync(AppointmentRequestDto appointmentDto)
    {
        return await _appointmentService.AddAppointmentAsync(appointmentDto);
    }

    /// <summary>
    /// updates an existing appointment that take appoinment dto and appointment id.
    /// </summary>
    /// <param name="appointmentDto">the appointment information to update</param>
    /// <param name="id">the id of the appointment to update</param>
    /// <returns>the result of appointment response dto after updated </returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin, Patient")]
    [ProducesResponseType(typeof(Result<AppointmentResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<AppointmentResponseDto>> UpdateAppointmentAsync(AppointmentRequestDto appointmentDto, int id)
    {
        return await _appointmentService.UpdateAppointmentAsync(id, appointmentDto);
    }

    /// <summary>
    /// gets appointments for a specific doctor.
    /// </summary>
    /// <returns>result of list  from  appointment response dto for specific doctor</returns>
    [HttpGet("Doctor")]
    [Authorize(Roles = "Admin, Doctor")]
    [ProducesResponseType(typeof(Result<List<AppointmentResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<AppointmentResponseDto>>> GetAppointmentsForSpecificDoctorAsync()
    {
        return await _appointmentService.GetAllAppointmentForSpecificDoctor(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }

    /// <summary>
    /// gets appointments for a specific patient.
    /// </summary>
    /// <returns>result of list  from  appointment response dto for specific patient</returns>
    [HttpGet("Patient")]
    [Authorize(Roles = "Admin, Patient")]
    [ProducesResponseType(typeof(Result<List<AppointmentResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<AppointmentResponseDto>>> GetAppointmentsForSpecificPatientAsync()
    {
        return await _appointmentService.GetAllAppointmentForSpecificPatient(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
    /// <summary>
    /// action for remove appointment by id that take appointment id 
    /// </summary>
    /// <param name="id">appointment id</param>
    /// <returns>result of appointment removed successfully</returns>
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> Deleteappointment(int id)
    {
        return await _appointmentService.DeleteAppointmentAsync(id);
    }
}
