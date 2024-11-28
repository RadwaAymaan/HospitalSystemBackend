using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HMSWithLayers.API.Controllers;

public class TimeSlotController(ITimeSlotService timeSlotService) : BaseController
{
    private readonly ITimeSlotService _timeSlotService = timeSlotService;

    /// <summary>
    /// action for add time slot action that take timeSlot dto   
    /// </summary>
    /// <param name="timeSlotDto">time slot dto</param>
    /// <returns>result for time slot added successfully.</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> AddTimeSlot(TimeSlotRequestDto timeSlotDto)
    {
        return await _timeSlotService.AddTimeSlotAsync(timeSlotDto);
    }
    /// <summary>
    /// action for get all time slot.  
    /// </summary>
    /// <returns>result of list from time slot response dto</returns>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<List<TimeSlotResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<TimeSlotResponseDto>>> GetAllTimeSlots()
    {
        return await _timeSlotService.GetAllTimeSlotAsync();
    }
    /// <summary>
    /// action for get time slot by id that take time slot id.  
    /// </summary>
    /// <returns>result of time slot response dto</returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<TimeSlotResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<TimeSlotResponseDto>> GetTimeSlotById(int id)
    {
        return await _timeSlotService.GetTimeSlotByIdAsync(id);
    }
    /// <summary>
    /// action for update time slot action that take timeSlot dto and time slot id
    /// </summary>
    /// <param name="Id">time slot id</param>
    /// <param name="timeSlotDto">time slot dto</param>
    /// <returns>result of time slot response dto after updated successfully. </returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<TimeSlotResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<TimeSlotResponseDto>> UpdateTimeSlot(int id, TimeSlotRequestDto timeSlotDto)
    {
        return await _timeSlotService.UpdateTimeSlotAsync(id, timeSlotDto);
    }
    /// <summary>
    ///  action for remove TimeSlot that take timeSlot id   
    /// </summary>
    /// <param name="Id">time slot id</param>
    /// <returns>result of TimeSlot removed successfully </returns>
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> DeleteTimeSlotAsycn(int id)
    {
        return await _timeSlotService.DeleteTimeSlotAsync(id);
    }
}
