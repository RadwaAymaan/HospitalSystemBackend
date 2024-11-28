using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IRoomTypeService : IApplicationService, IScopedService
{
    public Task<Result> AddRoomTypeAsync(RoomTypeRequestDto roomTypeRequestDto);
    public Task<Result<List<RoomTypeResponseDto>>> GetAllRoomTypesAsync();
    public Task<Result<RoomTypeResponseDto>> GetRoomTypeByIdAsync(int id);
    public Task<Result<RoomTypeResponseDto>> UpdateRoomTypeAsync(int id, RoomTypeRequestDto roomTypeRequestDto);
    public Task<Result> DeleteRoomTypeAsync(int id);
}
