using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HMSWithLayers.API.Controllers;

public class RoomController(IRoomService roomService) : BaseController
{
    private readonly IRoomService _roomService = roomService;

    /// <summary>
    /// action for add Room that take Room dto   
    /// </summary>
    /// <param name="RoomDto">Room dto</param>
    /// <returns>result of Room added successfully.</returns>
    [HttpPost]
    [Authorize(Roles ="Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> AddRoom(RoomRequestDto RoomDto)
    {
        return await _roomService.AddRoomAsync(RoomDto);
    }
    /// <summary>
    /// action for get all Room  
    /// </summary>
    /// <returns>result of list from Room response dto </returns>
    [HttpGet]
    [Authorize(Roles = "Admin,Patient")]
    [ProducesResponseType(typeof(Result<List<RoomGetAllResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<RoomGetAllResponseDto>>> GetAllRoom()
    {
        return await _roomService.GetAllRoomsAsync();
    }
    /// <summary>
    /// action for get by id Room  that take  Room id
    /// </summary>
    /// <param name="id">Room id</param>
    /// <returns>result of Room response dto </returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Patient")]
    [ProducesResponseType(typeof(Result<RoomResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<RoomResponseDto>> GetRoomById(int id)
    {
        return await _roomService.GetRoomByIdAsync(id);
    }
    /// <summary>
    /// action for update Room by id that take  Room id and Room dto
    /// </summary>
    /// <param name="id">Room id</param>
    /// <param name="RoomDto">Room dto</param>
    /// <returns>result of Room response dto after updated successfully</returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<RoomResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<RoomResponseDto>> UpdateRoom(int id, RoomRequestDto RoomDto)
    {
        return await _roomService.UpdateRoomAsycn(id, RoomDto);
    }
    /// <summary>
    /// action for remove  Room by id that take Room id 
    /// </summary>
    /// <param name="id">Room id</param>
    /// <returns>result of Room remove successfully</returns>
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> DeleteRoom(int id)
    {
        return await _roomService.DeleteRoomAsync(id);
    }

    /// <summary>
    /// action for book room that take room id
    /// </summary>
    /// <param name="roomId">Room id</param>
    /// <returns>result of book room successfully</returns>
    [HttpPost("BookRoom")]
    [Authorize(Roles = "Patient")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> BookRoom(int roomId)
    {
        var patientId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        return await _roomService.BookRoomAsync(roomId, patientId);
    }

    /// <summary>
    /// action for checkout from room 
    /// </summary>
    /// <returns>result of checkout from room successfully</returns>
    [HttpPost("RoomCheckout")]
    [Authorize(Roles = "Patient")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> RoomCheckout()
    {
        var patientId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        return await _roomService.RoomCheckoutAsync(patientId);
    }
}
