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

public class SpecializationService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<SpecializationService> logger) : ISpecializationService
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<SpecializationService> _logger = logger;

   
    
    /// <summary>
    /// function to add specialization that take SpecializationRequestDto   
    /// </summary>
    /// <param name="SpecializationRequestDto">specialization dto</param>
    /// <returns>specialization added successfully</returns>

    public async Task<Result> AddSpectializationAsync(SpecializationRequestDto SpecializationRequestDto)
    {
        var specializationMap = _mapper.Map<Specialization>(SpecializationRequestDto);
        if (specializationMap is null)
        {
            _logger.LogError("Failed to map SpecializationRequestDto to Specialization. SpecializationRequestDto: {@SpecializationRequestDto}", SpecializationRequestDto);
            return Result.Invalid(new List<ValidationError>
                {
                    new ValidationError
                    {
                        ErrorMessage = "Validation Errror"
                    }
                });
        }
        _dbContext.Specializations.Add(specializationMap);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("Specialization added successfully in the database");
        return Result.SuccessWithMessage("Specialization added successfully");
    }
    /// <summary>
    /// function to remove  specialization that take specialization id 
    /// </summary>
    /// <param name="Id">specialization id</param>
    /// <returns>specialization remove successfully</returns>

    public async Task<Result> DeleteSpecializationAsync(int Id)
    {
        var specialization = await _dbContext.Specializations.FindAsync(Id);

        if (specialization is null)
        {
            _logger.LogWarning("specialization Invaild Id ,Id {specializationId}", Id);
            return Result.NotFound(["specialization Invaild Id"]);
        }

        _dbContext.Specializations.Remove(specialization);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("Specialization remove successfully in the database");
        return Result.SuccessWithMessage("Specialization remove successfully ");
    }
    /// <summary>
    /// function to get all specialization 
    /// </summary>
    /// <returns>list of specialization response dto </returns>
    public async Task<Result<List<SpecializationResponseDto>>> GetAllSpecializationsAsync()
    {
        var specialization = await _dbContext.Specializations
              .ProjectTo<SpecializationResponseDto>(_mapper.ConfigurationProvider)
              .ToListAsync();
        _logger.LogInformation("Fetching all Specialization. Total count: {Specialization}.", specialization.Count);
        return Result.Success(specialization);
    }
    /// <summary>
    /// function to get  specialization by id  that take  specialization id
    /// </summary>
    /// <param name="Id">specialization id</param>
    /// <returns>specialization response dto </returns>
    public async Task<Result<SpecializationResponseDto>> GetSpecializationByIdAsync(int Id)
    {
        var specialization = await _dbContext.Specializations
              .ProjectTo<SpecializationResponseDto>(_mapper.ConfigurationProvider)
              .FirstOrDefaultAsync(s => s.Id == Id);
        if (specialization is null)
        {
            _logger.LogWarning("specialization Id not found,Id {specializationId}", Id);
            return Result.NotFound(["Specialization not found"]);
        }
        _logger.LogInformation("Fetching Specialization");
        return Result.Success(specialization);
    }
    /// <summary>
    /// function to update specialization  that take  specialization id and specialization dto
    /// </summary>
    /// <param name="Id">specialization id</param>
    /// <param name="SpecializationRequestDto">specialization dto</param>
    /// <returns>specialization response dto </returns>
    public async Task<Result<SpecializationResponseDto>> UpdateSpecializationAsycn(int Id, SpecializationRequestDto SpecializationRequestDto)
    {
        var specialization = await _dbContext.Specializations.FindAsync(Id);

        if (specialization is null)
        {
            _logger.LogWarning("specialization Id not found,Id {specializationId}", Id);
            return Result.NotFound(["Specialization not found"]);
        }

        _mapper.Map(SpecializationRequestDto, specialization);

        await _dbContext.SaveChangesAsync();

        var specializationResponse = _mapper.Map<SpecializationResponseDto>(specialization);
        if (specializationResponse is null)
        {
            _logger.LogError("Failed to map SpecializationRequestDto to SpecializationResponseDto. SpecializationRequestDto: {@SpecializationRequestDto}", SpecializationRequestDto);
            return Result.Invalid(new List<ValidationError>
                {
                    new ValidationError
                    {
                        ErrorMessage = "Validation Errror"
                    }
                });
        }

        _logger.LogInformation("Updated Specialization , Id {Id}", Id);

        return Result.Success(specializationResponse);
    }
}
