using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IInventoryService : IApplicationService, IScopedService
{
    public Task<Result> AddInventoryAsync(InventoryRequestDto inventoryRequestDto);
    public Task<Result<List<InventoryResponseDto>>> GetAllInventoriesAsync();
    public Task<Result<InventoryResponseDto>> GetInventoryByIdAsync(int id);
    public Task<Result<InventoryResponseDto>> UpdateInventoryAsync(int id, InventoryRequestDto inventoryRequestDto);
    public Task<Result> DeleteInventoryAsync(int id);
}
