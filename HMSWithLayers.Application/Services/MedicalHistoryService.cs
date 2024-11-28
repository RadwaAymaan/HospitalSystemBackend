using HMSWithLayers.Core.Result;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Castle.Core.Logging;
using HMSWithLayers.Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HMSWithLayers.Infrastructure.BaseContext;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Domain.Entities;

namespace HMSWithLayers.Application.Services;

public class MedicalHistoryService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<MedicalHistoryService> logger, IUserContextService userContext) : IMedicalHistoryService
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<MedicalHistoryService> _logger = logger;
    private readonly IUserContextService _userContext = userContext;


    /// <summary>
    /// Gets medical histories by patient record ID asynchronously.
    /// </summary>
    /// <param name="patientId">The ID of the patient record.</param>
    /// <returns>A list of medical history response DTOs.</returns>
    public async Task<Result<List<MedicalHistoryResponseDto>>> GetMedicalHistoryByPatientId(string patientId)
    {
        var medicalHistory = await _dbContext.MedicalHistories
           .Where(s => s.PatientId.Equals(patientId))
           .ProjectTo<MedicalHistoryResponseDto>(_mapper.ConfigurationProvider)
           .ToListAsync();

        _logger.LogInformation("Fetching all MedicalHistories by patient Id. Total count: {MedicalHistory}.", medicalHistory.Count);
        return Result.Success(medicalHistory);
    }

    /// <summary>
    /// Gets a medical history by its ID asynchronously.
    /// </summary>
    /// <param name="Id">The ID of the medical history to retrieve.</param>
    /// <returns>The medical history response DTO, or null if not found.</returns>
    public async Task<Result<MedicalHistoryResponseDto>> GetMedicalHistoryeById(int id)
    {
        var medicalHistory = await _dbContext.MedicalHistories
            .ProjectTo<MedicalHistoryResponseDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(medicalHistory => medicalHistory.Id == id);

        if (medicalHistory is null)
        {
            _logger.LogWarning("MedicalHistory Id not found,Id {id}", id);
            return Result.NotFound(["MedicalHistory not found"]);
        }

        _logger.LogInformation("Fetching MedicalHistory");
        return Result.Success(medicalHistory);
    }

    /// <summary>
    /// Adds a medical history asynchronously.
    /// </summary>
    /// <param name="medicalHistoryDto">The medical history DTO to add.</param>
    /// <returns>The number of entities added.</returns>
    public async Task<Result> AddMedicalHistoryAsync(MedicalHistoryRequestDto medicalHistoryDto )
    {
        var medicalHistory = _mapper.Map<MedicalHistory>(medicalHistoryDto);

        if (medicalHistory is null)
        {
            _logger.LogError("Failed to map medicalHistoryDto to MedicalHistory. medicalHistoryDto: {@medicalHistoryDto}", medicalHistoryDto);
            return Result.Invalid(new List<ValidationError>
            {
                new ValidationError
                {
                    ErrorMessage = "Validation Error"
                }
            });
        }
        medicalHistory.CreatedBy = _userContext.Email;
        await _dbContext.MedicalHistories.AddAsync(medicalHistory);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("MedicalHistory added successfully to the database");
        return Result.SuccessWithMessage("MedicalHistory added successfully");
    }

    /// <summary>
    /// Updates a medical history asynchronously.
    /// </summary>
    /// <param name="id">The ID of the medical history to update.</param>
    /// <param name="medicalHistoryDto">The medical history DTO containing updated information.</param>
    /// <returns>The updated medical history response DTO, or null if not found.</returns>
    public async Task<Result<MedicalHistoryResponseDto>> UpdateMedicalHistory(int id, MedicalHistoryRequestDto medicalHistoryDto )
    {
        var medicalHistory = await _dbContext.MedicalHistories.FindAsync(id);

        if (medicalHistory is null)
        {
            _logger.LogWarning("MedicalHistory Id not found,Id {id}", id);
            return Result.NotFound(["MedicalHistory not found"]);
        }
        medicalHistory.ModifiedBy = _userContext.Email;
        _mapper.Map(medicalHistoryDto, medicalHistory);

        await _dbContext.SaveChangesAsync();

        var medicalHistoryResponse = _mapper.Map<MedicalHistoryResponseDto>(medicalHistory);
        if (medicalHistoryResponse is null)
        {
            _logger.LogError("Failed to map medicalHistory to medicalHistoryResponse. medicalHistory: {@medicalHistory}", medicalHistoryResponse);
            return Result.Invalid(new List<ValidationError>
            {
                new ValidationError
                {
                    ErrorMessage = "Validation Error"
                }
            });
        }

        _logger.LogInformation("Updated Specialization , Id {Id}", id);

        return Result.Success(medicalHistoryResponse);
    }

    /// <summary>
    /// Deletes a medical history asynchronously by its ID.
    /// </summary>
    /// <param name="id">The ID of the medical history to delete.</param>
    /// <returns>The number of entities deleted.</returns>
    public async Task<Result> DeleteMedicalHistory(int id)
    {
        var medicalHistory = await _dbContext.MedicalHistories.FindAsync(id);

        if (medicalHistory is null)
        {
            _logger.LogWarning("MedicalHistory Id not found,Id {id}", id);
            return Result.NotFound(["MedicalHistory not found"]);
        }

        _dbContext.MedicalHistories.Remove(medicalHistory);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("MedicalHistory removed successfully in the database");
        return Result.SuccessWithMessage("MedicalHistory removed successfully");
    }
}
