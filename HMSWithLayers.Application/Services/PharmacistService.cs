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

public class PharmacistService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<PharmacistService> logger, IAuthService authService) : IPharmacistService
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<PharmacistService> _logger = logger;
    private readonly IAuthService _authService = authService;

    /// <summary>
    /// function to add pharmacist that take pharmacist dto   
    /// </summary>
    /// <param name="pharmacistDto">pharmacist dto</param>
    /// <returns>pharmacist added successfully</returns>
    public async Task<Result> AddPharmacistAsync(PharmacistRequestDto pharmacistDto)
    {
        var pharmacist = _mapper.Map<Pharmacist>(pharmacistDto);
        var pharmacistAdded = await _authService.RegisterPharmacistAsync(pharmacistDto);
        if (!pharmacistAdded.IsSuccess)
        {
            return Result.Error(pharmacistAdded.Errors.FirstOrDefault());
        }
        _logger.LogInformation("Pharmacist added successfully in the database");
        return Result.SuccessWithMessage("Pharmacist added successfully");
    }
    /// <summary>
    /// function to remove  pharmacist that take pharmacist id 
    /// </summary>
    /// <param name="Id">pharmacist id</param>
    /// <returns>pharmacist remove successfully</returns>
    public async Task<Result> DeletePharmacistAsync(string Id)
    {
        var pharmacist = await _dbContext.Pharmacists.FindAsync(Id);

        if (pharmacist is null)
        {
            _logger.LogWarning("pharmacist Invaild Id ,Id {pharmacistId}", Id);
            return Result.NotFound(["pharmacist Invaild Id"]);
        }

        _dbContext.Pharmacists.Remove(pharmacist);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("pharmacist remove successfully in the database");
        return Result.SuccessWithMessage("Pharmacist remove successfully ");
    }

    /// <summary>
    /// function to get all pharmacists 
    /// </summary>
    /// <returns>list of pharmacist response dto </returns>
    public async Task<Result<List<PharmacistResponseDto>>> GetAllPharmacistsAsync()
    {
        var pharmacist = await _dbContext.Users.OfType<Pharmacist>()
              .ProjectTo<PharmacistResponseDto>(_mapper.ConfigurationProvider)
              .ToListAsync();
        _logger.LogInformation("Fetching all pharmacists. Total count: {doctor}.", pharmacist.Count);
        return Result.Success(pharmacist);
    }
    /// <summary>
    /// function to get  pharmacist by id  that take  pharmacist id
    /// </summary>
    /// <param name="Id">pharmacist id</param>
    /// <returns>pharmacist response dto </returns>
    public async Task<Result<PharmacistResponseDto>> GetPharmacistByIdAsync(string Id)
    {
        var pharmacist = await _dbContext.Users.OfType<Pharmacist>()
              .ProjectTo<PharmacistResponseDto>(_mapper.ConfigurationProvider)
              .FirstOrDefaultAsync(d => d.Id == Id);
        if (pharmacist is null)
        {
            _logger.LogWarning("pharmacist Id not found,Id {pharmacistId}", Id);
            return Result.NotFound(["pharmacist not found"]);
        }
        _logger.LogInformation("Fetching pharmacist");
        return Result.Success(pharmacist);
    }
    /// <summary>
    /// function to update pharmacist  that take  pharmacist id and pharmacist dto
    /// </summary>
    /// <param name="Id">pharmacist id</param>
    /// <param name="pharmacistDto">pharmacist dto</param>
    /// <returns>pharmacist response dto </returns>
    public async Task<Result<PharmacistResponseDto>> UpdatePharmacistAsycn(string Id, PharmacistRequestDto pharmacistDto)
    {
        var pharmacist = await _dbContext.Pharmacists.FindAsync(Id);

        if (pharmacist is null)
        {
            _logger.LogWarning("pharmacist Id not found,Id {pharmacistId}", Id);
            return Result.NotFound(["Pharmacist not found"]);
        }

        _mapper.Map(pharmacistDto, pharmacist);

        await _dbContext.SaveChangesAsync();

        var pharmacistResponse = _mapper.Map<PharmacistResponseDto>(pharmacist);
        if (pharmacistResponse is null)
        {
            _logger.LogError("Failed to map pharmacistDto to pharmacistResponseDto. pharmacistDto: {@pharmacistDto}", pharmacistDto);
            return Result.Invalid(new List<ValidationError>
                {
                    new ValidationError
                    {
                        ErrorMessage = "Validation Errror"
                    }
                });
        }

        _logger.LogInformation("Updated pharmacist , Id {Id}", Id);

        return Result.Success(pharmacistResponse);
    }
}

