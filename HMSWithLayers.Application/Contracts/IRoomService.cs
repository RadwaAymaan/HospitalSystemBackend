using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IRoomService : IApplicationService, IScopedService
{
    public Task<Result> AddRoomAsync(RoomRequestDto roomRequestDto);
    public Task<Result<List<RoomGetAllResponseDto>>> GetAllRoomsAsync();
    public Task<Result<RoomResponseDto>> GetRoomByIdAsync(int id);
    public Task<Result<RoomResponseDto>> UpdateRoomAsycn(int id, RoomRequestDto roomRequestDto);
    public Task<Result> DeleteRoomAsync(int id);
    public Task<Result> BookRoomAsync(int id, string patientId);
    public Task<Result> RoomCheckoutAsync(string patientId);
}
