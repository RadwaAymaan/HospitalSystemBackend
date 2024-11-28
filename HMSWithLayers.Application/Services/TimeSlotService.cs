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

public class TimeSlotService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<TimeSlotService> logger, IUserContextService userContext) : ITimeSlotService
{

    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<TimeSlotService> _logger = logger;
    private readonly IUserContextService _userContext = userContext;

    /// <summary>
    /// function to add TimeSlot that take timeSlotDto   
    /// </summary>
    /// <param name="timeSlotRequestDto">time slot request dto</param>
    /// <returns>TimeSlot added successfully </returns>
    public async Task<Result> AddTimeSlotAsync(TimeSlotRequestDto timeSlotRequestDto)
    {     
        var result = _mapper.Map<TimeSlot>(timeSlotRequestDto);
        if (result is null)
        {
            _logger.LogError("Failed to map TimeSlotRequestDto to TimeSlot. TimeSlotRequestDto: {@TimeSlotRequestDto}", timeSlotRequestDto);
            return Result.Invalid(new List<ValidationError>
            {
                new ValidationError
                {
                    ErrorMessage = "Validation Errror"
                }
            });
        }
        result.CreatedBy = _userContext.Email;
        _dbContext.TimeSlots.Add(result);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("TimeSlot added successfully to the database");
        return Result.SuccessWithMessage("TimeSlot added successfully");
    }
    /// <summary>
    /// function to get all timeslot 
    /// </summary>
    /// <returns>list all time slot response dto </returns>
    public async Task<Result<List<TimeSlotResponseDto>>> GetAllTimeSlotAsync()
    {
        var result = await _dbContext.TimeSlots 
                  .ProjectTo<TimeSlotResponseDto>(_mapper.ConfigurationProvider)
                  .ToListAsync();
        _logger.LogInformation("Fetching all TimeSlot. Total count: {TimeSlot}.", result.Count);
        return Result.Success(result);
    }

    /// <summary>
    /// function to get time slot by id that take  time slote id
    /// </summary>
    /// <param name="Id">time slot id</param>
    /// <returns>time slot response dto</returns>
    public async Task<Result<TimeSlotResponseDto>> GetTimeSlotByIdAsync(int id)
    {
        var result = await _dbContext.TimeSlots
                .ProjectTo<TimeSlotResponseDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(timeslot => timeslot.Id == id);

        if (result is null)
        {
            _logger.LogWarning("TimeSlot Id not found,Id {TimeSlotId}", id);
            return Result.NotFound(["TimeSlot not found"]);
        }
        _logger.LogInformation("Fetching TimeSlot");
        return Result.Success(result);
    }
    /// <summary>
    /// function to update TimeSlot that take timeSlotDto   
    /// </summary>
    /// <param name="Id">time slot id</param>
    /// <param name="timeSlotRequestDto">timeSlot dto</param>
    /// <returns>Updated TimeSlot </returns>
    public async Task<Result<TimeSlotResponseDto>> UpdateTimeSlotAsync(int id, TimeSlotRequestDto timeSlotRequestDto)
    {
        var result = await _dbContext.TimeSlots.FindAsync(id);

        if (result is null)
        {
            _logger.LogWarning("TimeSlot Id not found,Id {TimeSlotId}", id);
            return Result.NotFound(["TimeSlot not found"]);
        }

        result.ModifiedBy = _userContext.Email;
        _mapper.Map(timeSlotRequestDto, result);

        await _dbContext.SaveChangesAsync();

        var timeSlotResponse = _mapper.Map<TimeSlotResponseDto>(result);
        if (timeSlotResponse is null)
        {
            _logger.LogError("Failed to map TimeSlotRequestDto to TimeSlotResponseDto. TimeSlotRequestDto: {@TimeSlotRequestDto}", timeSlotResponse);
            return Result.Invalid(new List<ValidationError>
                {
                    new ValidationError
                    {
                        ErrorMessage = "Validation Errror"
                    }
                });
        }

        _logger.LogInformation("Updated TimeSlot , Id {Id}", id);

        return Result.Success(timeSlotResponse);

    } /// <summary>
      /// function to delete TimeSlot that take timeSlotDto   
      /// </summary>
      /// <param name="Id">time slot id</param>
      /// <returns>TimeSlot removed successfully </returns>
    public async Task<Result> DeleteTimeSlotAsync(int id)
    {
        var timeSlot = await _dbContext.TimeSlots .FindAsync(id);

        if (timeSlot is null)
        {
            _logger.LogWarning("TimeSlot Invaild Id ,Id {TimeSlotId}", id);
            return Result.NotFound(["TimeSlot Invaild Id"]);
        }

        _dbContext.TimeSlots .Remove(timeSlot);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("TimeSlot removed successfully in the database");
        return Result.SuccessWithMessage("TimeSlot removed successfully");
    }
}

