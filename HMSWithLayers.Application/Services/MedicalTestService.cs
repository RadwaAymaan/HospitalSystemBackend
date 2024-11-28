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

public class MedicalTestService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<MedicalTestService> logger, IUserContextService userContext) : IMedicalTestService
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<MedicalTestService> _logger = logger;
    private readonly IUserContextService _userContext = userContext;


    /// <summary>
    /// Retrieves all labs asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing the list of labs.</returns>
    public async Task<Result<List<LabResponseDto>>> GetAllLabsAsync()
    {
        var labs = await _dbContext.MedicalTests.OfType<Lab>()
            .ProjectTo<LabResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        _logger.LogInformation("Fetching all Labs. Total count: {Lab}.", labs.Count);
        return Result.Success(labs);
    }

    /// <summary>
    /// Retrieves a lab by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the lab to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation, containing the lab.</returns>
    public async Task<Result<LabResponseDto>> GetLabByIdAsync(int id)
    {
        var labTest = await _dbContext.MedicalTests.OfType<Lab>()
            .ProjectTo<LabResponseDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (labTest is null)
        {
            _logger.LogWarning("LabTest Id not found,Id {id}", id);
            return Result.NotFound($"LabTest with id {id} not found");
        }
        _logger.LogInformation("Fetching LabTest");
        return Result.Success(labTest);
    }

    /// <summary>
    /// Adds a new lab asynchronously.
    /// </summary>
    /// <param name="LabRequestDto">The lab to add.</param>
    /// <returns>A task that represents the asynchronous operation, indicating success or failure.</returns>
    public async Task<Result> AddLabAsync(LabRequestDto labRequestDto)
    {
        var labTest = _mapper.Map<Lab>(labRequestDto);

        if (labTest is null)
        {
            _logger.LogError("Failed to map LabRequestDto to Lab. LabRequestDto: {@LabRequestDto}", labRequestDto);
            return Result.Invalid(new List<ValidationError>
                {
                    new ValidationError
                    {
                        ErrorMessage = "Validation Error"
                    }
                });
        }
        labTest.CreatedBy = _userContext.Email;
        await _dbContext.MedicalTests.AddAsync(labTest);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("LabTest added successfully to the database");
        return Result.SuccessWithMessage("LabTest added successfully");
    }

    /// <summary>
    /// Updates an existing lab asynchronously.
    /// </summary>
    /// <param name="id">The ID of the lab to update.</param>
    /// <param name="LabRequestDto">The updated lab data.</param>
    /// <returns>A task that represents the asynchronous operation, containing the updated lab.</returns>
    public async Task<Result<LabResponseDto>> UpdateLabAsync(int id, LabRequestDto labRequestDto)
    {
        var labTest = await _dbContext.MedicalTests.FindAsync(id);

        if (labTest is null)
        {
            _logger.LogWarning("LabTest Id not found,Id {id}", id);
            return Result.NotFound($"LabTest with id {id} not found");
        }
        labTest.ModifiedBy = _userContext.Email;
        _mapper.Map(labRequestDto, labTest);
        await _dbContext.SaveChangesAsync();

        var labTestResponse = _mapper.Map<LabResponseDto>(labTest);
        if (labTestResponse is null)
        {
            _logger.LogError("Failed to map labTest to labTestResponse. labTest: {@labTest}", labTestResponse);
            return Result.Invalid(new List<ValidationError>
                {
                    new ValidationError
                    {
                        ErrorMessage = "Validation Error"
                    }
                });
        }

        _logger.LogInformation("Updated LabTest , Id {Id}", id);

        return Result.Success(labTestResponse);
    }

    /// <summary>
    /// Deletes a lab asynchronously.
    /// </summary>
    /// <param name="id">The ID of the lab to delete.</param>
    /// <returns>A task that represents the asynchronous operation, indicating success or failure.</returns>
    public async Task<Result> DeleteLabAsync(int id)
    {
        var labTest = await _dbContext.MedicalTests.FindAsync(id);

        if (labTest is null)
        {
            _logger.LogWarning("LabTest Id not found,Id {id}", id);
            return Result.NotFound($"LabTest with id {id} not found");
        }

        _dbContext.MedicalTests.Remove(labTest);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("LabTest removed successfully in the database");
        return Result.SuccessWithMessage("LabTest removed successfully");
    }

    /// <summary>
    /// Retrieves all scans asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing the list of scans.</returns>
    public async Task<Result<List<ScanResponseDto>>> GetAllScansAsync()
    {
        var scans = await _dbContext.MedicalTests.OfType<Scan>()
            .ProjectTo<ScanResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        _logger.LogInformation("Fetching all Scans. Total count: {Scan}.", scans.Count);
        return Result.Success(scans);
    }

    /// <summary>
    /// Retrieves a scan by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the scan to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation, containing the scan.</returns>
    public async Task<Result<ScanResponseDto>> GetScanByIdAsync(int id)
    {
        var scanTest = await _dbContext.MedicalTests.OfType<Scan>()
            .ProjectTo<ScanResponseDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (scanTest is null)
        {
            _logger.LogWarning("ScanTest Id not found,Id {id}", id);
            return Result.NotFound(["ScanTest not found"]);
        }
        _logger.LogInformation("Fetching ScanTest");
        return Result.Success(scanTest);
    }

    /// <summary>
    /// Adds a new scan asynchronously.
    /// </summary>
    /// <param name="ScanRequestDto">The scan to add.</param>
    /// <returns>A task that represents the asynchronous operation, indicating success or failure.</returns>
    public async Task<Result> AddScanAsync(ScanRequestDto scanRequestDto)
    {
        var scanTest = _mapper.Map<Scan>(scanRequestDto);

        if (scanTest is null)
        {
            _logger.LogError("Failed to map ScanRequestDto to Scan. ScanRequestDto: {@ScanRequestDto}", scanRequestDto);
            return Result.Invalid(new List<ValidationError>
            {
                new ValidationError
                {
                    ErrorMessage = "Validation Error"
                }
            });
        }
        scanTest.CreatedBy = _userContext.Email;
        await _dbContext.MedicalTests.AddAsync(scanTest);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("ScanTest added successfully to the database");
        return Result.SuccessWithMessage("ScanTest added successfully");
    }

    /// <summary>
    /// Updates an existing scan asynchronously.
    /// </summary>
    /// <param name="id">The ID of the lab to update.</param>
    /// <param name="ScanRequestDto">The updated scan data.</param>
    /// <returns>A task that represents the asynchronous operation, containing the updated scan.</returns>
    public async Task<Result<ScanResponseDto>> UpdateScanAsync(int id, ScanRequestDto ScanRequestDto )
    {
        var scanTest = await _dbContext.MedicalTests.FindAsync(id);

        if (scanTest is null)
        {
            _logger.LogWarning("ScanTest Id not found,Id {id}", id);
            return Result.NotFound(["ScanTest not found"]);
        }

        scanTest.ModifiedBy = _userContext.Email;
        _mapper.Map(ScanRequestDto, scanTest);
        await _dbContext.SaveChangesAsync();

        var scanTestResponse = _mapper.Map<ScanResponseDto>(scanTest);
        if (scanTestResponse is null)
        {
            _logger.LogError("Failed to map scanTest to scanTestResponse. scanTest: {@scanTest}", scanTestResponse);
            return Result.Invalid(new List<ValidationError>
            {
                new ValidationError
                {
                    ErrorMessage = "Validation Error"
                }
            });
        }

        _logger.LogInformation("Updated ScanTest , Id {Id}", id);

        return Result.Success(scanTestResponse);
    }

    /// <summary>
    /// Deletes a scan asynchronously.
    /// </summary>
    /// <param name="id">The ID of the scan to delete.</param>
    /// <returns>A task that represents the asynchronous operation, indicating success or failure.</returns>
    public async Task<Result> DeleteScanAsync(int id)
    {
        var scanTest = await _dbContext.MedicalTests.FindAsync(id);

        if (scanTest is null)
        {
            _logger.LogWarning("ScanTest Id not found,Id {id}", id);
            return Result.NotFound(["ScanTest not found"]);
        }

        _dbContext.MedicalTests.Remove(scanTest);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("ScanTest removed successfully in the database");
        return Result.SuccessWithMessage("ScanTest removed successfully");
    }
}
