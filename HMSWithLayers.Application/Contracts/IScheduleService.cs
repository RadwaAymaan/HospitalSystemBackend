using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IScheduleService : IApplicationService, IScopedService
{
    public Task<Result> AddScheduleAsync(ScheduleRequestDto scheduleRequestDto);
    public Task<Result<List<ScheduleResponseDto>>> GetAllSchedulesAsync();
    public Task<Result<ScheduleResponseDto>> GetScheduleByIdAsync(int id);
    public Task<Result<ScheduleResponseDto>> UpdateScheduleAsync(int id, ScheduleRequestDto scheduleRequestDto);
    public Task<Result> DeleteScheduleAsync(int id);
}
