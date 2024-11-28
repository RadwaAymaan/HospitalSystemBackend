using AutoMapper;
using AutoMapper.QueryableExtensions;
using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace HMSWithLayers.Application.Services;

public class AppointmentService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<AppointmentService> logger, IUserContextService userContext, IMessagingService messagingService) : IAppointmentService
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<AppointmentService> _logger = logger;
    private readonly IUserContextService _userContext = userContext;
    private readonly IMessagingService _messagingService = messagingService;



    /// <summary>
    /// Adds an appointment asynchronously.
    /// </summary>
    /// <param name="AppointmentRequestDto">The appointment DTO to add.</param>
    /// <returns>A Result of the add attempt.</returns
    public async Task<Result> AddAppointmentAsync(AppointmentRequestDto AppointmentRequestDto)
    {
        var doctor = await _dbContext.Doctors.FirstOrDefaultAsync(d => d.Id.Equals(AppointmentRequestDto.DoctorId));
        var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id.Equals(AppointmentRequestDto.PatientId));
        if (doctor is null || patient is null)
        {
            _logger.LogWarning("Patient or Doctor was not found while trying to add appointment.");
            return Result.Error("Patient or Doctor was not found.");
        }

        var appointment = _mapper.Map<Appointment>(AppointmentRequestDto);
        AppointmentSendEmail(appointment);

        appointment.CreatedBy = _userContext.Email;
        _dbContext.Appointments.Add(appointment);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("Appointment added successfully to the database");
        return Result.SuccessWithMessage("Appointment added successfully");
    }
    private void AppointmentSendEmail(Appointment appointment)
    {
        TimeOnly appointmentTimeSpan = TimeOnly.Parse("00:00:00");
        DateTime appointmentDate = appointment.Date.ToDateTime(appointmentTimeSpan);
        Hangfire.BackgroundJob.Schedule(() =>
        _messagingService.SendMessage("hagershaaban7@gmail.com", "Appointment Reminder", $"Your appointment  is scheduled for {appointment.Date.ToShortDateString()} at {appointment.StartTime.ToShortTimeString()}."), appointmentDate.TimeOfDay);
    }

    /// <summary>
    /// Deletes an appointment asynchronously.
    /// </summary>
    /// <param name="Id">The ID of the appointment to delete.</param>
    /// <returns>The Result of the delete attempt</returns>
    public async Task<Result> DeleteAppointmentAsync(int id)
    {
        var findAppointment = await _dbContext.Appointments.FindAsync(id);

        if (findAppointment == null)
        {
            _logger.LogWarning("Appointment Id not found, Id {AppointmentId} ", id);
            return Result.NotFound(["The appointment is not found"]);
        }

        _dbContext.Remove(findAppointment);
        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("Appointment removed successfully in the database");
        return Result.SuccessWithMessage("Appointment removed successfully");
    }

    /// <summary>
    /// Gets all appointments asynchronously.
    /// </summary>
    /// <returns>A Result containing appointments response DTOs.</returns>
    public async Task<Result<List<AppointmentResponseDto>>> GetAllAppointmentAsync()
    {
        var appointments = await _dbContext.Appointments
            .ProjectTo<AppointmentResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        _logger.LogInformation("Fetching all appointments. Total count: {appointments}.", appointments.Count);
        return Result.Success(appointments);
    }

    /// <summary>
    /// Gets all appointments for a specific doctor asynchronously.
    /// </summary>
    /// <returns>A Result containing appointments response DTOs.</returns>
    public async Task<Result<List<AppointmentResponseDto>>> GetAllAppointmentForSpecificDoctor(string doctorId)
    {
        var appointment = await _dbContext.Appointments
            .Where(s => s.Doctor.Id.Equals(doctorId))
            .ProjectTo<AppointmentResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        _logger.LogInformation("Fetching appointment. Total count: {appointment}.", appointment.Count);
        return Result.Success(appointment);
    }

    /// <summary>
    /// Gets all appointments for a specific patientasynchronously.
    /// </summary>
    /// <returns>A Result containing appointments response DTOs.</returns>
    public async Task<Result<List<AppointmentResponseDto>>> GetAllAppointmentForSpecificPatient(string patientId)
    {
        var appointment = await _dbContext.Appointments
            .Where(s => s.Patient.Id.Equals(patientId))
            .ProjectTo<AppointmentResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        _logger.LogInformation("Fetching appointment. Total count: {appointment}.", appointment.Count);
        return Result.Success(appointment);
    }

    /// <summary>
    /// Gets an appointment by ID asynchronously.
    /// </summary>
    /// <param name="Id">The ID of the appointment to retrieve.</param>
    /// <returns>A Result containing appointment response DTO or NotFound Result if item is not found.</returns>
    public async Task<Result<AppointmentResponseDto>> GetAppointmentByIdAsync(int id)
    {
        var appointment = await _dbContext.Appointments
            .ProjectTo<AppointmentResponseDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(appointment => appointment.Id == id);

        if (appointment is null)
        {
            _logger.LogWarning("Appointment Id not found,Id {AppointmentId}", id);
            return Result.NotFound(["The appointment is not found"]);
        }

        _logger.LogInformation("Fetched one appointment");
        return Result.Success(appointment);
    }

    /// <summary>
    /// Updates an existing appointment asynchronously.
    /// </summary>
    /// <param name="appointmentRequestDto">The DTO representing the appointment to update.</param>
    /// <param name="Id">The ID of the item to update.</param>
    /// <returns>The Result of the update attempt.</returns>
    public async Task<Result<AppointmentResponseDto>> UpdateAppointmentAsync(int id, AppointmentRequestDto appointmentRequestDto)
    {
        var appointmentFound = await _dbContext.Appointments.FirstOrDefaultAsync(s => s.Id == id);

        if (appointmentFound is null)
        {
            _logger.LogWarning("Appointment Id not found,Id {AppointmentId}", id);
            return Result.NotFound(["The appointment is not found"]);
        }

        var doctor = await _dbContext.Doctors.FirstOrDefaultAsync(d => d.Id == appointmentRequestDto.DoctorId);
        var patient = await _dbContext.Patients.FirstOrDefaultAsync(d => d.Id == appointmentRequestDto.PatientId);

        if (doctor is null || patient is null)
        {
            _logger.LogWarning("Patient or Doctor was not found while trying to add appointment.");
            return Result.Error("Patient or Doctor was not found.");
        }
        appointmentFound.ModifiedBy = _userContext.Email;
        _mapper.Map(appointmentRequestDto, appointmentFound);
        await _dbContext.SaveChangesAsync();

        var appointmentResponseDto = _mapper.Map<AppointmentResponseDto>(appointmentFound);

        if (appointmentResponseDto is null)
        {
            _logger.LogError("Failed to map AppointmentRequestDto to AppointmentResponseDto. appointmentDto: {@AppointmentRequestDto}", appointmentRequestDto);
            return Result.Invalid(new List<ValidationError>
                {
                    new ValidationError
                    {
                        ErrorMessage = "Validation Errror"
                    }
                });
        }

        _logger.LogInformation("Appointment updated successfully");
        return Result.Success(appointmentResponseDto, "Successfully updated appointment");
    }
}
