using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSWithLayers.API.Controllers;

public class RoomTypeController(IRoomTypeService roomTypeService) : BaseController
{
    private readonly IRoomTypeService _roomTypeService = roomTypeService;

    /// <summary>
    ///action for add room type that take roomType request dto.  
    /// </summary>
    /// <param name="RoomTypeDto">room type Dto</param>
    /// <returns>result room type added successfully</returns>

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> AddRoomType(RoomTypeRequestDto roomTypeDto)
    {
        return await _roomTypeService.AddRoomTypeAsync(roomTypeDto);
    }


    /// <summary>
    /// action for get all  room types that take room type response dto  
    /// </summary>
    /// <returns>result of list from room types response dto</returns>

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<List<RoomTypeResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<RoomTypeResponseDto>>> GetAllRoomTypes()
    {
        return await _roomTypeService.GetAllRoomTypesAsync();
    }

    /// <summary>
    /// action for get room type by id that take room type id
    /// </summary>
    /// <param name="id">room type id</param>
    /// <returns>result of room type  response dto</returns>

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<RoomTypeResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<RoomTypeResponseDto>> GetRoomTypeById(int id)
    {
        return await _roomTypeService.GetRoomTypeByIdAsync(id);
    }

    /// <summary>
    /// action for update room type by id that take room type id and room type dto 
    /// </summary>
    /// <param name="id">room type id</param>
    /// <param name="roomTypeDto">room type dto</param>
    /// <returns>result of room type response dto after updated</returns>
    /// 
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<RoomTypeResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<RoomTypeResponseDto>> UpdateRoomType(int id, RoomTypeRequestDto roomTypeDto)
    {
        return await _roomTypeService.UpdateRoomTypeAsync(id, roomTypeDto);
    }

    /// <summary>
    /// action for remove  room type by id that take room type id
    /// </summary>
    /// <param name="id">room type id</param>
    /// <returns>result of room type remove successfully</returns>
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> DeleteRoomType(int id)
    {
        return await _roomTypeService.DeleteRoomTypeAsync(id);
    }

}
