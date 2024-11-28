using HMSWithLayers.Core.Result;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HMSWithLayers.Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HMSWithLayers.Infrastructure.BaseContext;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Core.CustomExceptions;

namespace HMSWithLayers.Application.Services;

public class RoomService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<RoomService> logger, IUserContextService userContext) : IRoomService
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<RoomService> _logger = logger;
    private readonly IUserContextService _userContext = userContext;


    /// <summary>
    /// function to add Room that take RoomRequestDto   
    /// </summary>
    /// <param name="RoomRequestDto">Room dto</param>
    /// <returns>Room added successfully</returns>
    public async Task<Result> AddRoomAsync(RoomRequestDto roomRequestDto)
    {
        var mappedroom = _mapper.Map<Room>(roomRequestDto);
        if (mappedroom is null)
        {
            _logger.LogError("Failed to map RoomRequestDto to Room. RoomRequestDto: {@RoomRequestDto}", roomRequestDto);
            return Result.Invalid(new List<ValidationError>
                {
                    new ValidationError
                    {
                        ErrorMessage = "Validation Errror"
                    }
                });
        }

        mappedroom.CreatedBy = _userContext.Email;
        _dbContext.Rooms.Add(mappedroom);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("Room added successfully in the database");
        return Result.SuccessWithMessage("Room added successfully");
    }
    /// <summary>
    /// function to remove  room that take room id 
    /// </summary>
    /// <param name="Id">room id</param>
    /// <returns>room remove successfully</returns>

    public async Task<Result> DeleteRoomAsync(int id)
    {

        var room = await _dbContext.Rooms.FindAsync(id);

        if (room is null)
        {
            _logger.LogWarning("room Invaild Id ,Id {roomId}", id);
            return Result.NotFound(["room Invaild Id"]);
        }

        _dbContext.Rooms.Remove(room);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("room remove successfully in the database");
        return Result.SuccessWithMessage("room remove successfully ");
    }
    /// <summary>
    /// function to get all room 
    /// </summary>
    /// <returns>list of room response dto </returns>
    public async Task<Result<List<RoomGetAllResponseDto>>> GetAllRoomsAsync()
    {
        var room = await _dbContext.Rooms
             .ProjectTo<RoomGetAllResponseDto>(_mapper.ConfigurationProvider)
             .ToListAsync();
        _logger.LogInformation("Fetching all room. Total count: {room}.", room.Count);
        return Result.Success(room);
    }

    public async Task<Result<RoomResponseDto>> GetRoomByIdAsync(int Id)
    {
        var room = await _dbContext.Rooms
               .ProjectTo<RoomResponseDto>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync(s => s.Id == Id); ;
        if (room is null)
        {
            _logger.LogWarning("room Id not found,Id {roomId}", Id);
            return Result.NotFound(["room not found"]);
        }
        _logger.LogInformation("Fetching room");
        return Result.Success(room);
    }
    /// <summary>
    /// function to update room  that take  room id and room dto
    /// </summary>
    /// <param name="Id">room id</param>
    /// <param name="roomDto">room dto</param>
    /// <returns>room response dto </returns>
    public async Task<Result<RoomResponseDto>> UpdateRoomAsycn(int id, RoomRequestDto roomRequestDto)
    {
        var room = await _dbContext.Rooms.FindAsync(id);

        if (room is null)
        {
            _logger.LogWarning("room Id not found,Id {roomId}", id);
            return Result.NotFound(["room not found"]);
        }
        room.ModifiedBy = _userContext.Email;
        _mapper.Map(roomRequestDto, room);

        await _dbContext.SaveChangesAsync();

        var roomResponse = _mapper.Map<RoomResponseDto>(room);
        if (roomResponse is null)
        {
            _logger.LogError("Failed to map roomDto to roomResponseDto. roomDto: {@roomDto}", roomRequestDto);
            return Result.Invalid(new List<ValidationError>
            {
                new ValidationError
                {
                    ErrorMessage = "Validation Errror"
                }
            });
        }

        _logger.LogInformation("Updated room , Id {Id}", id);

        return Result.Success(roomResponse);
    }

    /// <summary>
    /// function to book room  that take  room id and patient id
    /// </summary>
    /// <param name="roomId">room id</param>
    /// <param name="patientId">patient id</param>
    /// <returns> room booked successfuly </returns>
    public async Task<Result> BookRoomAsync(int roomId, string patientId)
    {
        var room = _dbContext.Rooms.Find(roomId);
        var patient = _dbContext.Patients.Find(patientId);

        if (room is null)
        {
            throw new ResourceNotFoundException("Room", roomId);
        }

        if (!(patient?.RoomId is null))
        {
            _logger.LogInformation("Patient already booked a room");
            return Result.Error("You already booked a room");
        }

        if (!RoomAvailability(room))
        {
            _logger.LogInformation("Room has the maximum number of patients");
            return Result.Error("Room is not available");
        }


        patient.RoomId = roomId;
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("Room booked successfuly");
        return Result.SuccessWithMessage("Room booked successfuly");
    }

    /// <summary>
    /// function to checkout from room  that take patient id
    /// </summary>
    /// <param name="patientId">patient id</param>
    /// <returns> checkout successfuly </returns>
    public async Task<Result> RoomCheckoutAsync(string patientId)
    {
        var patient = _dbContext.Patients.Find(patientId);

        if (patient?.RoomId is null)
        {
            return Result.NotFound("You are not exist in any room");
        }

        patient.Room.Availability = true;
        patient.RoomId = null;
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("patient checkout successfuly");
        return Result.SuccessWithMessage("Checkout successfuly");
    }
    /// <summary>
    /// checks the availability of a room based on the number of patients it currently contains.
    /// </summary>
    /// <param name="room">the room to check availability for.</param>
    /// <returns>true if the room is available, false otherwise.</returns>
    public bool RoomAvailability(Room room)
    {
        if (room.Patients?.Count < room.RoomType.NumberOfPatient)
        {
            room.Availability = false;
            return true;
        }
        room.Availability = true;
        return false;
    }
}
