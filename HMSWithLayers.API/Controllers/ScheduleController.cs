using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HMSWithLayers.API.Controllers;

public class ScheduleController(IScheduleService scheduleService) : BaseController
{
    private readonly IScheduleService _scheduleService = scheduleService;

    /// <summary>
    /// action for add schedule that take schedule dto  
    /// </summary>
    /// <param name="scheduleDto">schedule dto</param>
    /// <returns>result of schedule added successfully .</returns>
    [HttpPost]
    [Authorize(Roles = "Admin, Doctor")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> AddSchedule(ScheduleRequestDto scheduleDto)
    {
        return await _scheduleService.AddScheduleAsync(scheduleDto);
    }
    /// <summary>
    /// action for get all schedule  
    /// </summary>
    /// <returns>result of list from schedule response dto</returns>
    [HttpGet]
    [Authorize(Roles = "Admin, Doctor")]
    [ProducesResponseType(typeof(Result<List<ScheduleResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<ScheduleResponseDto>>> GetAllschedules()
    {
        return await _scheduleService.GetAllSchedulesAsync();
    }
    /// <summary>
    ///  action for get schedule by id  that take  schedule id
    /// </summary>
    /// <param name="Id">schedule id</param>
    /// <returns>result of schedule response dto</returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, Doctor")]
    [ProducesResponseType(typeof(Result<ScheduleResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<ScheduleResponseDto>> GetscheduleById(int id)
    {
        return await _scheduleService.GetScheduleByIdAsync(id);
    }
    /// <summary>
    /// action for update schedule that take schedule dto   
    /// </summary>
    /// <param name="id">schedule id</param>
    /// <param name="scheduleDto">schedule dto</param>
    /// <returns>result for Schedule response dto after updated successfully</returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin, Doctor")]
    [ProducesResponseType(typeof(Result<ScheduleResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<ScheduleResponseDto>> UpdateSchedule(int id, ScheduleRequestDto scheduleDto)
    {
        return await _scheduleService.UpdateScheduleAsync(id, scheduleDto);
    }
    /// <summary>
    ///  action for remove Schedule that take schedule id  
    /// </summary>
    /// <param name="Id">schedule id</param>
    /// <returns>result for schedule removed successfully </returns>
    [HttpDelete]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> DeleteScheduleAsycn(int id)
    {
        return await _scheduleService.DeleteScheduleAsync(id);
    }
}
