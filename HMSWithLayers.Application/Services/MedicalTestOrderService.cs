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

public class MedicalTestOrderService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<MedicalTestOrderService> logger, IUserContextService userContext) : IMedicalTestOrderService
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<MedicalTestOrderService> _logger = logger;
    private readonly IUserContextService _userContext = userContext;



    /// <summary>
    /// Retrieves all medical test orders asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, returning a Result containing a list of MedicalTestOrderResponseDto.</returns>
    public async Task<Result<List<MedicalTestOrderResponseDto>>> GetAllMedicalTestOrdersAsync()
    {
        var medicalTestOrders = await _dbContext.MedicalTestOrders
            .ProjectTo<MedicalTestOrderResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        _logger.LogInformation("Fetching all MedicalTestOrders. Total count: {MedicalTestOrder}.", medicalTestOrders.Count);
        return Result.Success(medicalTestOrders);
    }

    /// <summary>
    /// Retrieves all medical test orders for a specific patient asynchronously.
    /// </summary>
    /// <param name="Id">The ID of the patient.</param>
    /// <returns>A task representing the asynchronous operation, returning a Result containing a list of MedicalTestOrderResponseDto.</returns>
    public async Task<Result<List<MedicalTestOrderResponseDto>>> GetAllMedicalTestOrdersByPatientIdAsync(string Id)
    {
        var medicalTestOrders = await _dbContext.MedicalTestOrders
            .Where(t => t.PatientId.Equals(Id))
            .ProjectTo<MedicalTestOrderResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        _logger.LogInformation("Fetching all MedicalTestOrders by patient Id. Total count: {MedicalTestOrder}.", medicalTestOrders.Count);
        return Result.Success(medicalTestOrders);
    }

    /// <summary>
    /// Retrieves a medical test order by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the medical test order to retrieve.</param>
    /// <returns>A task representing the asynchronous operation, returning a Result containing a MedicalTestOrderResponseDto.</returns>
    public async Task<Result<MedicalTestOrderResponseDto>> GetMedicalTestOrderByIdAsync(int id)
    {
        var medicalTestOrder = await _dbContext.MedicalTestOrders
            .ProjectTo<MedicalTestOrderResponseDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (medicalTestOrder is null)
        {
            _logger.LogWarning("MedicalTestOrder Id not found,Id {id}", id);
            return Result.NotFound(["MedicalTestOrder not found"]);
        }
        _logger.LogInformation("Fetching MedicalTestOrder");
        return Result.Success(medicalTestOrder);
    }

    /// <summary>
    /// Adds a medical test order asynchronously.
    /// </summary>
    /// <param name="medicalTestOrderDto">The DTO representing the medical test order to add.</param>
    /// <returns>A task representing the asynchronous operation, returning a Result indicating the outcome of the operation.</returns>
    public async Task<Result> AddMedicalTestOrderAsync(MedicalTestOrderRequestDto medicalTestOrderDto)
    {
        var medicalTestOrder = _mapper.Map<MedicalTestOrder>(medicalTestOrderDto);

        var medicalTest = _dbContext.MedicalTests.Find(medicalTestOrderDto.MedicalTestId);
        var patient = _dbContext.Patients.Find(medicalTestOrderDto.PatientId);
        var doctor = _dbContext.Doctors.Find(medicalTestOrderDto.DoctorId);
        var laboratorist = _dbContext.Laboratorists.Find(medicalTestOrderDto.LaboratoristId);

        if (medicalTestOrder is null)
        {
            _logger.LogError("Failed to map medicalTestOrderDto to MedicalTestOrder. medicalTestOrderDto: {@medicalTestOrderDto}", medicalTestOrderDto);
            return Result.Invalid(new List<ValidationError>
            {
                new ValidationError
                {
                    ErrorMessage = "Validation Error"
                }
            });
        }

        if (medicalTest is null)
        {
            _logger.LogWarning("MedicalTest Id not found,Id {medicalTestId}", medicalTestOrderDto.MedicalTestId);
            return Result.NotFound(["MedicalTest not found"]);
        }

        if (patient is null)
        {
            _logger.LogWarning("Patient Id not found,Id {patientId}", medicalTestOrderDto.PatientId);
            return Result.NotFound(["Patient not found"]);
        }

        if (doctor is null)
        {
            _logger.LogWarning("Doctor Id not found,Id {doctorId}", medicalTestOrderDto.DoctorId);
            return Result.NotFound(["Doctor not found"]);
        }

        if (laboratorist is null)
        {
            _logger.LogWarning("Laboratorist Id not found,Id {laboratoristId}", medicalTestOrderDto.LaboratoristId);
            return Result.NotFound(["Laboratorist not found"]);
        }

        medicalTestOrder.CreatedBy = _userContext.Email;
        await _dbContext.MedicalTestOrders.AddAsync(medicalTestOrder);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("MedicalTestOrder added successfully to the database");
        return Result.SuccessWithMessage("MedicalTestOrder added successfully");
    }

    /// <summary>
    /// Updates a medical test order asynchronously.
    /// </summary>
    /// <param name="id">The ID of the medical test order to update.</param>
    /// <param name="medicalTestOrderDto">The DTO representing the updated medical test order.</param>
    /// <returns>A task representing the asynchronous operation, returning a Result containing the updated MedicalTestOrderResponseDto.</returns>
    public async Task<Result<MedicalTestOrderResponseDto>> UpdateMedicalTestOrderAsync(int id, MedicalTestOrderRequestDto medicalTestOrderDto)
    {
        var medicalTestOrder = await _dbContext.MedicalTestOrders.FindAsync(id);

        var medicalTest = _dbContext.MedicalTests.Find(medicalTestOrderDto.MedicalTestId);
        var patient = _dbContext.Patients.Find(medicalTestOrderDto.PatientId);
        var doctor = _dbContext.Doctors.Find(medicalTestOrderDto.DoctorId);
        var laboratorist = _dbContext.Laboratorists.Find(medicalTestOrderDto.LaboratoristId);

        if (medicalTestOrder is null)
        {
            _logger.LogWarning("MedicalTestOrder Id not found,Id {id}", id);
            return Result.NotFound(["MedicalTestOrder not found"]);
        }

        if (medicalTest is null)
        {
            _logger.LogWarning("MedicalTest Id not found,Id {medicalTestId}", medicalTestOrderDto.MedicalTestId);
            return Result.NotFound(["MedicalTest not found"]);
        }

        if (patient is null)
        {
            _logger.LogWarning("Patient Id not found,Id {patientId}", medicalTestOrderDto.PatientId);
            return Result.NotFound(["Patient not found"]);
        }

        if (doctor is null)
        {
            _logger.LogWarning("Doctor Id not found,Id {doctorId}", medicalTestOrderDto.DoctorId);
            return Result.NotFound(["Doctor not found"]);
        }

        if (laboratorist is null)
        {
            _logger.LogWarning("Laboratorist Id not found,Id {laboratoristId}", medicalTestOrderDto.LaboratoristId);
            return Result.NotFound(["Laboratorist not found"]);
        }

        medicalTestOrder.ModifiedBy = _userContext.Email;

        _mapper.Map(medicalTestOrderDto, medicalTestOrder);

        await _dbContext.SaveChangesAsync();

        var medicalTestOrderResponse = _mapper.Map<MedicalTestOrderResponseDto>(medicalTestOrder);
        if (medicalTestOrderResponse is null)
        {
            _logger.LogError("Failed to map medicalTestOrder to medicalTestOrderResponse. medicalTestOrder: {@medicalTestOrder}", medicalTestOrderResponse);
            return Result.Invalid(new List<ValidationError>
            {
                new ValidationError
                {
                    ErrorMessage = "Validation Error"
                }
            });
        }

        _logger.LogInformation("Updated MedicalTestOrder , Id {Id}", id);

        return Result.Success(medicalTestOrderResponse);
    }

    /// <summary>
    /// Deletes a medical test order asynchronously.
    /// </summary>
    /// <param name="id">The ID of the medical test order to delete.</param>
    /// <returns>A task representing the asynchronous operation, returning a Result indicating the outcome of the operation.</returns>
    public async Task<Result> DeleteMedicalTestOrderAsync(int id)
    {
        var medicalTestOrder = await _dbContext.MedicalTestOrders.FindAsync(id);

        if (medicalTestOrder is null)
        {
            _logger.LogWarning("MedicalTestOrder Id not found,Id {id}", id);
            return Result.NotFound(["MedicalTestOrder not found"]);
        }

        _dbContext.MedicalTestOrders.Remove(medicalTestOrder);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("MedicalTestOrder removed successfully in the database");
        return Result.SuccessWithMessage("MedicalTestOrder removed successfully");
    }
}