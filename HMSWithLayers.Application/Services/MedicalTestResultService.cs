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

public class MedicalTestResultService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<MedicalTestResultService> logger, IUserContextService userContext) : IMedicalTestResultService
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<MedicalTestResultService> _logger = logger;
    private readonly IUserContextService _userContext = userContext;

    /// <summary>
    /// Retrieves all medical test results.
    /// </summary>
    /// <returns>The list of medical test results.</returns>
    public async Task<Result<List<MedicalTestResultResponseDto>>> GetAllMedicalTestResultsAsync()
    {
        var medicalTestResults = await _dbContext.MedicalTestResults
            .ProjectTo<MedicalTestResultResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        _logger.LogInformation("Fetching all MedicalTestResults. Total count: {MedicalTestResult}.", medicalTestResults.Count);
        return Result.Success(medicalTestResults);
    }

    /// <summary>
    /// Retrieves all medical test results for a specific patient asynchronously.
    /// </summary>
    /// <param name="Id">The ID of the patient.</param>
    /// <returns>A task representing the asynchronous operation, returning a Result containing a list of MedicalTestResultResponseDto.</returns>
    public async Task<Result<List<MedicalTestResultResponseDto>>> GetAllMedicalTestResultsByPatientIdAsync(string id)
    {
        var medicalTestResults = await _dbContext.MedicalTestResults
            .Where(t => t.MedicalTestOrder.PatientId.Equals(id))
            .ProjectTo<MedicalTestResultResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        _logger.LogInformation("Fetching all MedicalTestResults by patientId. Total count: {MedicalTestResult}.", medicalTestResults.Count);
        return Result.Success(medicalTestResults);
    }

    /// <summary>
    /// Retrieves a medical test result by its ID.
    /// </summary>
    /// <param name="Id">The ID of the medical test result.</param>
    /// <returns>The medical test result, or null if not found.</returns>
    public async Task<Result<MedicalTestResultResponseDto>> GetMedicalTestResultByIdAsync(int id)
    {
        var medicalTestResult = await _dbContext.MedicalTestResults
            .ProjectTo<MedicalTestResultResponseDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (medicalTestResult is null)
        {
            _logger.LogWarning("MedicalTestResult Id not found,Id {id}", id);
            return Result.NotFound(["MedicalTestResult not found"]);
        }
        _logger.LogInformation("Fetching MedicalTestResult");
        return Result.Success(medicalTestResult);
    }

    /// <summary>
    /// Adds a new medical test result.
    /// </summary>
    /// <param name="MedicalTestResultRequestDto">The medical test result DTO.</param>
    /// <returns>The number of state entries written to the database.</returns>
    public async Task<Result> AddMedicalTestResultAsync(MedicalTestResultRequestDto MedicalTestResultRequestDto)
    {
        var medicalTestResult = _mapper.Map<MedicalTestResult>(MedicalTestResultRequestDto);

        var medicalTestOrder = _dbContext.MedicalTests.Find(MedicalTestResultRequestDto.MedicalTestOrderId);
        var laboratorist = _dbContext.Laboratorists.Find(MedicalTestResultRequestDto.LaboratoristId);

        if (medicalTestResult is null)
        {
            _logger.LogError("Failed to map MedicalTestResultRequestDto to MedicalTestResult. MedicalTestResultRequestDto: {@MedicalTestResultRequestDto}", MedicalTestResultRequestDto);
            return Result.Invalid(new List<ValidationError>
            {
                new ValidationError
                {
                    ErrorMessage = "Validation Error"
                }
            });
        }

        if (medicalTestOrder == null)
        {
            _logger.LogWarning("MedicalTestOrder Id not found,Id {medicalTestOrderId}", MedicalTestResultRequestDto.MedicalTestOrderId);
            return Result.NotFound(["MedicalTestOrder not found"]);
        }

        if (laboratorist == null)
        {
            _logger.LogWarning("Laboratorist Id not found,Id {laboratoristId}", MedicalTestResultRequestDto.LaboratoristId);
            return Result.NotFound(["Laboratorist not found"]);
        }
        medicalTestResult.CreatedBy = _userContext.Email;
        await _dbContext.MedicalTestResults.AddAsync(medicalTestResult);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("MedicalTestResult added successfully to the database");
        return Result.SuccessWithMessage("MedicalTestResult added successfully");
    }

    /// <summary>
    /// Updates an existing medical test result.
    /// </summary>
    /// <param name="id">The ID of the medical test result to update.</param>
    /// <param name="MedicalTestResultRequestDto">The medical test result DTO with updated information.</param>
    /// <returns>The updated medical test result, or null if not found.</returns>
    public async Task<Result<MedicalTestResultResponseDto>> UpdateMedicalTestResultAsync(int id, MedicalTestResultRequestDto MedicalTestResultRequestDto)
    {
        var medicalTestResult = await _dbContext.MedicalTestResults.FindAsync(id);

        var medicalTestOrder = _dbContext.MedicalTests.Find(MedicalTestResultRequestDto.MedicalTestOrderId);
        var laboratorist = _dbContext.Laboratorists.Find(MedicalTestResultRequestDto.LaboratoristId);

        if (medicalTestResult is null)
        {
            _logger.LogWarning("MedicalTestResult Id not found,Id {id}", id);
            return Result.NotFound(["MedicalTestResult not found"]);
        }

        if (medicalTestOrder == null)
        {
            _logger.LogWarning("MedicalTestOrder Id not found,Id {medicalTestOrderId}", MedicalTestResultRequestDto.MedicalTestOrderId);
            return Result.NotFound(["MedicalTestOrder not found"]);
        }

        if (laboratorist == null)
        {
            _logger.LogWarning("Laboratorist Id not found,Id {laboratoristId}", MedicalTestResultRequestDto.LaboratoristId);
            return Result.NotFound(["Laboratorist not found"]);
        }
        medicalTestResult.ModifiedBy = _userContext.Email;
        _mapper.Map(MedicalTestResultRequestDto, medicalTestResult);

        await _dbContext.SaveChangesAsync();

        var medicalTestResultResponse = _mapper.Map<MedicalTestResultResponseDto>(medicalTestResult);
        if (medicalTestResultResponse is null)
        {
            _logger.LogError("Failed to map medicalTestResult to medicalTestResultResponse. medicalTestResult: {@medicalTestResult}", medicalTestResultResponse);
            return Result.Invalid(new List<ValidationError>
            {
                new ValidationError
                {
                    ErrorMessage = "Validation Error"
                }
            });
        }

        _logger.LogInformation("Updated Specialization , Id {Id}", id);

        return Result.Success(medicalTestResultResponse);
    }

    /// <summary>
    /// Deletes a medical test result by its ID.
    /// </summary>
    /// <param name="Id">The ID of the medical test result to delete.</param>
    /// <returns>The number of state entries written to the database.</returns>
    public async Task<Result> DeleteMedicalTestResultAsync(int Id)
    {
        var medicalTestResult = await _dbContext.MedicalTestResults.FindAsync(Id);

        if (medicalTestResult is null)
        {
            _logger.LogWarning("MedicalTestResult Id not found,Id {id}", Id);
            return Result.NotFound(["MedicalTestResult not found"]);
        }

        _dbContext.MedicalTestResults.Remove(medicalTestResult);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("MedicalTestResult removed successfully in the database");
        return Result.SuccessWithMessage("MedicalTestResult removed successfully");
    }
}
