using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSWithLayers.API.Controllers;
public class InventoryController(IInventoryService inventoryService) : BaseController
{
    private readonly IInventoryService _inventoryService = inventoryService;

    /// <summary>
    /// action for add inventory that take inventory request dto   
    /// </summary>
    /// <param name="inventoryDto">inventory dto</param>
    /// <returns>result of inventory added successfully</returns>
    [HttpPost]
    [Authorize(Roles ="Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> AddInventory(InventoryRequestDto InventoryDto)
    {
        return await _inventoryService.AddInventoryAsync(InventoryDto);
    }

    /// <summary>
    /// action for get all inventories 
    /// </summary>
    /// <returns>result of list from inventory response dto</returns>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<List<InventoryResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<InventoryResponseDto>>> GetAllInventories()
    {
        return await _inventoryService.GetAllInventoriesAsync();
    }

    /// <summary>
    /// action for get by id inventory  that take  inventory id
    /// </summary>
    /// <param name="id">inventory id</param>
    /// <returns>result of inventory response dto </returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<InventoryResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<InventoryResponseDto>> GetInventoryById(int id)
    {
        return await _inventoryService.GetInventoryByIdAsync(id);
    }
    /// <summary>
    /// action for update inventory by id that take  inventory id and inventory request dto
    /// </summary>
    /// <param name="id">inventory id</param>
    /// <param name="inventoryDto">inventory dto</param>
    /// <returns>result of inventory response dto after updated</returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<InventoryResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<InventoryResponseDto>> UpdateInventory(int id, InventoryRequestDto inventoryDto)
    {
        return await _inventoryService.UpdateInventoryAsync(id, inventoryDto);
    }

    /// <summary>
    /// action for remove inventory by id that take inventory id 
    /// </summary>
    /// <param name="id">inventory id</param>
    /// <returns>result of inventory removed successfully</returns>
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> DeleteInventory(int id)
    {
        return await _inventoryService.DeleteInventoryAsync(id);
    }
}
