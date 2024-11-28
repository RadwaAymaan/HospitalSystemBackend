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

public class RoomTypeService(HMSBaseDbContext dbContext, ILogger<RoomTypeService> logger, IMapper mapper) : IRoomTypeService
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly ILogger<RoomTypeService> _logger = logger;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// function to add Room type that take roomTypeRequestDto   
    /// </summary>
    /// <param name="roomTypeRequestDto">roomType dto</param>
    /// <returns>room type added successfully in databse </returns>
    public async Task<Result> AddRoomTypeAsync(RoomTypeRequestDto roomTypeRequestDto)
    {
        var mappedroomType = _mapper.Map<RoomType>(roomTypeRequestDto);
        if (mappedroomType is null)
        {
            _logger.LogError("Failed to map roomTypeRequestDto to roomType. RoomTypeRequestDto: {@RoomTypeRequestDto}", roomTypeRequestDto);
            return Result.Invalid(new List<ValidationError>
            {
                 new ValidationError
                 {
                   ErrorMessage = "Validation Error"
                 }

            });
        }

        _dbContext.RoomTypes.Add(mappedroomType);

        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("RoomType added successfully in the database");

        return Result.SuccessWithMessage("RoomType added successfully");
    }

    /// <summary>
    /// function to get all room types  
    /// </summary>
    /// <returns>list all room types response dto </returns>
    public async Task<Result<List<RoomTypeResponseDto>>> GetAllRoomTypesAsync()
    {
        var roomTypes = await _dbContext.RoomTypes
              .ProjectTo<RoomTypeResponseDto>(_mapper.ConfigurationProvider)
              .ToListAsync();

        _logger.LogInformation("Fetching all room types. Total count: {room types}.", roomTypes.Count);

        return Result.Success(roomTypes);
    }

    /// <summary>
    /// function to get room type by id that take  room type id
    /// </summary>
    /// <param name="Id">room type id</param>
    /// <returns>details for room type response dto</returns>
    public async Task<Result<RoomTypeResponseDto>> GetRoomTypeByIdAsync(int Id)
    {
        var roomType = await _dbContext.RoomTypes
              .ProjectTo<RoomTypeResponseDto?>(_mapper.ConfigurationProvider)
              .FirstOrDefaultAsync(T => T.Id == Id);

        if (roomType is null)
        {
            _logger.LogWarning("room type Id not found,Id {roomTypeId}", Id);

            return Result.NotFound(["room type not found"]);
        }

        _logger.LogInformation("Fetching room type by id");

        return Result.Success(roomType);

    }

	/// <summary>
	/// function to update room type  that take  room type id and room type dto
	/// </summary>
	/// <param name="Id">room type id</param>
	/// <param name="RoomTypeRequestDto">room type dto</param>
	/// <returns>updated room type response dto </returns>
	public async Task<Result<RoomTypeResponseDto>> UpdateRoomTypeAsync(int Id, RoomTypeRequestDto roomTypeRequestDto)
    {
        var roomType = await _dbContext.RoomTypes.FindAsync(Id);

        if (roomType is null)
        {
            _logger.LogWarning("room type id not found,Id {room type id}", Id);
            return Result.NotFound(["room type not found"]);
        }

        _mapper.Map(roomTypeRequestDto, roomType);

        await _dbContext.SaveChangesAsync();

        var mappedRoomType = _mapper.Map<RoomTypeResponseDto>(roomType);

        if (mappedRoomType is null)
        {
            _logger.LogError("Failed to map room type dto to room type dto. RoomTypeRequestDto: {@RoomTypeRequestDto}", roomTypeRequestDto);

            return Result.Invalid(new List<ValidationError>
            {
               new ValidationError
               {
                  ErrorMessage = "Validation Errror"
               }
            });
        }

        _logger.LogInformation("Updated room type , Id {Id}", Id);

        return Result.Success(mappedRoomType);
    }

    /// <summary>
    /// function to remove  room type that take room type id 
    /// </summary>
    /// <param name="Id">room type id</param>
    /// <returns>room type remove successfully</returns>
    public async Task<Result> DeleteRoomTypeAsync(int Id)
    {
        var roomType = await _dbContext.RoomTypes.FindAsync(Id);

        if (roomType is null)
        {
            _logger.LogWarning("Invaild Id for room type ,Id {roomTypeId}", Id);

            return Result.NotFound(["Invaild Id for room type"]);
        }

        _dbContext.RoomTypes.Remove(roomType);

        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("room type remove successfully in the database");

        return Result.SuccessWithMessage("room type remove successfully ");
    }
}
