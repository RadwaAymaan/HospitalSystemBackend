using HMSWithLayers.Core.Result;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HMSWithLayers.Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HMSWithLayers.Infrastructure.BaseContext;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Domain.Entities;

namespace  HMSWithLayers.Application.Services;

public class InventoryService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<InventoryService> logger) : IInventoryService
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<InventoryService> _logger = logger;

   
    /// <summary>
    /// function for add inventory that take inventoryRequestDto   
    /// </summary>
    /// <param name="inventoryRequestDto">inventory dto</param>
    /// <returns>inventory added successfully</returns>
    public async Task<Result> AddInventoryAsync(InventoryRequestDto inventoryRequestDto)
    {
        var mappedInventory = _mapper.Map<Inventory>(inventoryRequestDto);
        if (mappedInventory is null)
        {
            _logger.LogError("Failed to map InventoryRequestDto to Inventory. InventoryRequestDto: {@InventoryRequestDto}", inventoryRequestDto);
            return Result.Invalid(new List<ValidationError>
            {
                new ValidationError
                {
                    ErrorMessage = "Validation Errror"
                }
            });
        }
        _dbContext.Inventories.Add(mappedInventory);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("inventory added successfully to the database");
        return Result.SuccessWithMessage("Inventory added successfully");
    }
    /// <summary>
    /// function for remove inventory by id that take inventory id 
    /// </summary>
    /// <param name="id">inventory id</param>
    /// <returns>Inventory removed successfully</returns>
    public async Task<Result> DeleteInventoryAsync(int id)
    {
        var inventory = await _dbContext.Inventories.FindAsync(id);

        if (inventory is null)
        {
            _logger.LogWarning("inventory Invaild Id ,Id {inventoryId}", id);
            return Result.NotFound(["inventory Invaild Id"]);
        }

        _dbContext.Inventories.Remove(inventory);
        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("Inventory remove successfully in the database");
        return Result.SuccessWithMessage("Inventory removed successfully");
    }

    /// <summary>
    /// function for get all inventory  
    /// </summary>
    /// <returns>list of inventory response dto </returns>
    public async Task<Result<List<InventoryResponseDto>>> GetAllInventoriesAsync()
    {
        var mappedInventory = await _dbContext.Inventories
                  .ProjectTo<InventoryResponseDto>(_mapper.ConfigurationProvider)
                  .ToListAsync();
        _logger.LogInformation("Fetching all Inventory. Total count: {Inventory}.", mappedInventory.Count);
        return Result.Success(mappedInventory);
    }

    /// <summary>
    /// function for get by id inventory  that take  inventory id
    /// </summary>
    /// <param name="id">inventory id</param>
    /// <returns>inventory response dto </returns>
    public async Task<Result<InventoryResponseDto>> GetInventoryByIdAsync(int id)
    {
        var inventory = await _dbContext.Inventories
                  .ProjectTo<InventoryResponseDto>(_mapper.ConfigurationProvider)
                  .FirstOrDefaultAsync(s => s.Id == id);
        if (inventory is null)
        {
            _logger.LogWarning("inventory Id not found,Id {inventoryId}", id);
            return Result.NotFound(["Inventory not found"]);
        }
        _logger.LogInformation("Fetching Inventory");
        return Result.Success(inventory);
    }
    /// <summary>
    /// function for update inventory by id that take  inventory id and inventoryRequestDto
    /// </summary>
    /// <param name="id">inventory id</param>
    /// <param name="inventoryRequestDto">inventory dto</param>
    /// <returns>inventory response dto </returns>
    public async Task<Result<InventoryResponseDto>> UpdateInventoryAsync(int id, InventoryRequestDto inventoryRequestDto)
    {
        var inventory = await _dbContext.Inventories.FindAsync(id);

        if (inventory is null)
        {
            _logger.LogWarning("inventory Id not found,Id {inventoryId}", id);
            return Result.NotFound(["inventory not found"]);
        }

        _mapper.Map(inventoryRequestDto, inventory);

        await _dbContext.SaveChangesAsync();

        var inventoryResponse = _mapper.Map<InventoryResponseDto>(inventory);
        if (inventoryResponse is null)
        {
            _logger.LogError("Failed to map InventoryRequestDto to InventoryResponseDto. InventoryRequestDto: {@InventoryRequestDto}", inventoryRequestDto);
            return Result.Invalid(new List<ValidationError>
                {
                    new ValidationError
                    {
                        ErrorMessage = "Validation Errror"
                    }
                });
        }

        _logger.LogInformation("Updated Inventory , Id {Id}", id);

        return Result.Success(inventoryResponse);
    }
}

