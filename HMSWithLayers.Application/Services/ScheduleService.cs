using HMSWithLayers.Core.Result;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HMSWithLayers.Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HMSWithLayers.Infrastructure.BaseContext;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Domain.Entities;

namespace HMSWithLayers.Application.Services;

public class ScheduleService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<ScheduleService> logger, IUserContextService userContext) : IScheduleService
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<ScheduleService> _logger = logger;
    private readonly IUserContextService _userContext = userContext;


    /// <summary>
    /// function to add Schedule that take ScheduleRequestDto   
    /// </summary>
    /// <param name="scheduleRequestDto">Schedule dto</param>
    /// <returns>Schedule added successfully </returns>
    public async Task<Result> AddScheduleAsync(ScheduleRequestDto scheduleRequestDto)
    {
        var doctor = await _dbContext.Users.OfType<Doctor>().FirstOrDefaultAsync(d => d.Id.Equals(scheduleRequestDto.DoctorId));
        var timeSlot = await _dbContext.TimeSlots.FirstOrDefaultAsync(t => t.Id == scheduleRequestDto.TimeSlotId);
        if (doctor is null || timeSlot is null)
        {
            _logger.LogError("Failed to map schedule to schedule. scheduleRequestDto: {@scheduleRequestDto}",scheduleRequestDto);
            return Result.NotFound(["Doctor or Time Slot Invalid "]);
        }
        var schedule = new Schedule
        {
            Doctor = doctor,
            TimeSlot = timeSlot
        };

        schedule.CreatedBy = _userContext.Email;
        _dbContext.Schedules.Add(schedule);
         await _dbContext.SaveChangesAsync();
        _logger.LogInformation("Schedule added successfully to the database");
        return Result.SuccessWithMessage("Schedule added successfully");
    }
    /// <summary>
    /// function to get all schedule 
    /// </summary>
    /// <returns>list all schedule response dto </returns>
    public async Task<Result<List<ScheduleResponseDto>>> GetAllSchedulesAsync()
    {
        var result = await _dbContext.Schedules
                  .ProjectTo<ScheduleResponseDto>(_mapper.ConfigurationProvider)
                  .ToListAsync();
        _logger.LogInformation("Fetching all Schedule. Total count: {Schedule}.", result.Count);
        return Result.Success(result);
    }

    /// <summary>
    /// function to get schedule by id that take schedule id
    /// </summary>
    /// <param name="Id">schedule id</param>
    /// <returns>schedule response dto</returns>
    public async Task<Result<ScheduleResponseDto>> GetScheduleByIdAsync(int id)
    {
        var result = await _dbContext.Schedules
                .ProjectTo<ScheduleResponseDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(schedule => schedule.Id == id);

        if (result is null)
        {
            _logger.LogWarning("Schedule Id not found,Id {ScheduleId}", id);
            return Result.NotFound(["Schedule not found"]);
        }
        _logger.LogInformation("Fetching Schedule");
        return Result.Success(result);
    }
 
    /// <summary>
    /// function to update Schedule that take Schedule dto   
    /// </summary>
    /// <param name="Id">schedule id</param>
    /// <param name="scheduleRequestDto">schedule dto</param>
    /// <returns>Updated Schedule </returns>
    public async Task<Result<ScheduleResponseDto>> UpdateScheduleAsync(int id, ScheduleRequestDto scheduleRequestDto)
    {
        var result = await _dbContext.Schedules.FindAsync(id);

        if (result is null)
        {
            _logger.LogWarning("Schedule Id not found,Id {ScheduleId}", id);
            return Result.NotFound(["Schedule not found"]);
        }
        result.ModifiedBy = _userContext.Email;
        _mapper.Map(scheduleRequestDto, result);

        await _dbContext.SaveChangesAsync();

        var scheduleResponse = _mapper.Map<ScheduleResponseDto>(result);
        if (scheduleResponse is null)
        {
            _logger.LogError("Failed to map ScheduleRequestDto to ScheduleResponseDto. ScheduleRequestDto: {@ScheduleRequestDto}", scheduleResponse);
            return Result.Invalid(new List<ValidationError>
                {
                    new ValidationError
                    {
                        ErrorMessage = "Validation Errror"
                    }
                });
        }

        _logger.LogInformation("Updated Schedule , Id {id}", id);

        return Result.Success(scheduleResponse);

    }
    /// <summary>
    /// function to delete Schedule that take scheduleRequestDto   
    /// </summary>
    /// <param name="Id">schedule id</param>
    /// <returns>Schedule removed successfully </returns>
    public async Task<Result> DeleteScheduleAsync(int id)
    {
        var schedule = await _dbContext.Schedules.FindAsync(id);

        if (schedule is null)
        {
            _logger.LogWarning("Schedule Invaild Id ,Id {ScheduleId}", id);
            return Result.NotFound(["Schedule Invaild Id"]);
        }

        _dbContext.Schedules .Remove(schedule);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("Schedule removed successfully in the database");
        return Result.SuccessWithMessage("Schedule removed successfully");
    }
}
