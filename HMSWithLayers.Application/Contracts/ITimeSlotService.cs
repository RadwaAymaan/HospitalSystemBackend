using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface ITimeSlotService : IApplicationService, IScopedService
{
    public Task<Result> AddTimeSlotAsync(TimeSlotRequestDto timeSlotRequestDto);
    public Task<Result<List<TimeSlotResponseDto>>> GetAllTimeSlotAsync();
    public Task<Result<TimeSlotResponseDto>> GetTimeSlotByIdAsync(int id);
    public Task<Result<TimeSlotResponseDto>> UpdateTimeSlotAsync(int id, TimeSlotRequestDto timeSlotRequestDto);
    public Task<Result> DeleteTimeSlotAsync(int id);

}
