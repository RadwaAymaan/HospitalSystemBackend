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

public class PrescriptionService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<PrescriptionService> logger, IUserContextService userContext) : IPrescriptionService
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<PrescriptionService> _logger = logger;
    private readonly IUserContextService _userContext = userContext;

    /// <summary>
    /// Gets all prescriptions asynchronously.
    /// </summary>
    /// <returns>A list of all prescription response DTO.</returns>
    public async Task<Result<List<PrescriptionResponseDto>>> GetAllPrescriptionsAsync()
    {
        var prescription = await _dbContext.Prescriptions
            .ProjectTo<PrescriptionResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        _logger.LogInformation("Fetching all prescriptions. Total count: {Prescription}.", prescription.Count);
        return Result.Success(prescription);
    }

    /// <summary>
    /// Gets a prescription by ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the item to retrieve.</param>
    /// <returns>An item response DTO or null if not found.</returns>
    public async Task<Result<PrescriptionResponseDto>> GetPrescriptionByIdAsync(int id)
    {
        var prescription = await _dbContext.Prescriptions
            .ProjectTo<PrescriptionResponseDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(prescription => prescription.Id == id);

        if (prescription is null)
        {
            _logger.LogWarning("Prescription Id not found,Id {id}", id);
            return Result.NotFound(["Prescription not found"]);
        }
        _logger.LogInformation("Fetching prescription");
        return Result.Success(prescription);
    }

    /// <summary>
    /// Adds a new prescription asynchronously.
    /// </summary>
    /// <param name="prescriptionDto">The DTO representing the item to add.</param>
    /// <returns>The number of rows affected..</returns>
    public async Task<Result> AddPrescriptionAsync(PrescriptionRequestDto prescriptionDto)
    {
        var medicine = await _dbContext.Medicines.FindAsync(prescriptionDto.MedicineId);

        var prescription = _mapper.Map<Prescription>(prescriptionDto);

        if (prescription is null)
        {
            _logger.LogError("Failed to map prescriptionDto to prescription. prescriptionDto: {@prescriptionDto}", prescriptionDto);
            return Result.Invalid(new List<ValidationError>
            {
                new ValidationError
                {
                    ErrorMessage = "Validation Error"
                }
            });
        }

        if (medicine is null)
        {
            _logger.LogWarning("Medicine Id not found,Id {medicineId}", prescriptionDto.MedicineId);
            return Result.NotFound(["Medicine not found"]);
        }

        prescription.Medicines = new List<Medicine> { medicine }; ;

        prescription.CreatedBy = _userContext.Email;
        prescription.DoctorId = _userContext.UserId;
        _dbContext.Prescriptions.Add(prescription);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("Prescription added successfully to the database");
        return Result.SuccessWithMessage("Prescription added successfully");
    }

    /// <summary>
    /// Updates a prescription asynchronously.
    /// </summary>
    /// <param name="prescriptionDto">The DTO representing the updated prescription.</param>
    /// <param name="id">The ID of the prescription to update.</param>
    /// <returns>The updated prescription response DTO or null if not found.</returns>
    public async Task<Result<PrescriptionResponseDto>> UpdatePrescriptionAsync(int id ,PrescriptionRequestDto prescriptionDto)
    {
        var prescription = await _dbContext.Prescriptions.FindAsync(id);
        var medicine = await _dbContext.Medicines.FindAsync(prescriptionDto.MedicineId);

        if (prescription is null)
        {
            _logger.LogWarning("Prescription Id not found,Id {id}", id);
            return Result.NotFound(["Prescription not found"]);
        }

        if (medicine is null)
        {
            _logger.LogWarning("Medicine Id not found,Id {medicineId}", prescriptionDto.MedicineId);
            return Result.NotFound(["Medicine not found"]);
        }

        prescription.ModifiedBy = _userContext.Email;
        prescription.DoctorId = _userContext.UserId;
        _mapper.Map(prescriptionDto, prescription);
       
        prescription.Medicines.Add(medicine);
        await _dbContext.SaveChangesAsync();

        var prescriptionResponse = _mapper.Map<PrescriptionResponseDto>(prescription);

        if (prescriptionResponse is null)
        {
            _logger.LogError("Failed to map prescription to prescriptionResponse. prescription: {@prescription}", prescriptionResponse);
            return Result.Invalid(new List<ValidationError>
            {
                new ValidationError
                {
                    ErrorMessage = "Validation Error"
                }
            });
        }

        _logger.LogInformation("Updated prescription, Id {Id}", id);

        return Result.Success(prescriptionResponse);
    }

    /// <summary>
    /// Deletes a prescription asynchronously.
    /// </summary>
    /// <param name="id">The ID of the prescription to delete.</param>
    /// <returns>The number of rows affected.</returns>
    public async Task<Result> DeletePrescriptionAsync(int id)
    {
        var prescription = await _dbContext.Prescriptions.FindAsync(id);

        if (prescription is null)
        {
            _logger.LogWarning("Prescription Id not found,Id {id}", id);
            return Result.NotFound(["Prescription not found"]);
        }

        _dbContext.Prescriptions.Remove(prescription);

        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("Prescription removed successfully in the database");
        return Result.SuccessWithMessage("Prescription removed successfully");
    }
}
