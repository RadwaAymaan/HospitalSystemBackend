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

public class NurseService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<NurseService> logger, IAuthService authService) : INurseService
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<NurseService> _logger = logger;
    private readonly IAuthService _authService = authService;

    /// <summary>
	/// function to add nurse that take nurseDto   
	/// </summary>
	/// <param name="nurseDto">nurse dto</param>
	/// <returns>nurse added successfully</returns>
    public async Task<Result> AddNurseAsync(NurseRequestDto nurseDto)
    {       
        var nurse = await _authService.RegisterNurseAsync(nurseDto);

        if (!nurse.IsSuccess)
        {
            return Result.Error(nurse.Errors.FirstOrDefault());
        }

        _logger.LogInformation("nurse added successfully in the database");

        return Result.SuccessWithMessage("nurse added successfully");
    }

    /// <summary>
	/// function to get all nurses
	/// </summary>
	/// <returns>list all nurses response dto </returns>
    public async Task<Result<List<NurseGetAllResponseDto>>> GetAllNurseAsync()
    {
        var nurses = await _dbContext.Users.OfType<Nurse>()
          .ProjectTo<NurseGetAllResponseDto>(_mapper.ConfigurationProvider)
          .ToListAsync();

        _logger.LogInformation("Fetching all nurses. Total count: {nurses}.", nurses.Count);

        return Result.Success(nurses);
    }

    // <summary>
    /// function to get nurse by id that take nurse id
    /// </summary>
    /// <param name="Id">nurse id</param>
    /// <returns>details for nurse response dto</returns>
    public async Task<Result<NurseResponseDto>> GetNurseByIdAsync(string Id)
    {
        var nurse = await _dbContext.Users.OfType<Nurse>()
              .ProjectTo<NurseResponseDto>(_mapper.ConfigurationProvider)
              .FirstOrDefaultAsync(n => n.Id == Id);

        if (nurse is null)
        {
            _logger.LogWarning("nurse id not found,Id {nurseId}", Id);

            return Result.NotFound(["nurse not found"]);
        }

        _logger.LogInformation("Fetching nurse by id");

        return Result.Success(nurse);
    }

    /// <summary>
	/// function to update nurse that take nurse id and nurse laboratorist dto
	/// </summary>
	/// <param name="Id">nurse id</param>
	/// <param name="nurseDto">nurse dto</param>
	/// <returns>updated nurse response dto </returns>
    public async Task<Result<NurseResponseDto>> UpdateNurseAsync(string Id, NurseRequestDto nurseDto)
    {
        var nurse = await _dbContext.Nurses.FindAsync(Id);

        if (nurse is null)
        {
            _logger.LogWarning("nurse id not found,Id {nurseId}", Id);

            return Result.NotFound(["nurse not found"]);
        }

        _mapper.Map(nurseDto, nurse);

        await _dbContext.SaveChangesAsync();

        var mappednurse = _mapper.Map<NurseResponseDto>(nurse);

        if (mappednurse is null)
        {
            _logger.LogError("Failed to map nurseDto to nurseDtoResponseDto. nurseDto: {@nurseDto}", nurseDto);

            return Result.Invalid(new List<ValidationError>
        {
            new ValidationError
            {
               ErrorMessage = "Validation Errror"
            }
        });
        }

        _logger.LogInformation("Updated nurse , Id {Id}", Id);

        return Result.Success(mappednurse);
    }

    /// <summary>
    /// function to remove nurse that take nurse id 
    /// </summary>
    /// <param name="Id">nurse id</param>
    /// <returns>nurse remove successfully</returns>
    public async Task<Result> DeleteNurseAsync(string Id)
    {
        var nurse = await _dbContext.Nurses.FindAsync(Id);

        if (nurse is null)
        {
            _logger.LogWarning("Invaild id for nurse ,Id {nurseId}", Id);

            return Result.NotFound(["Invaild id for nurse"]);
        }

        _dbContext.Nurses.Remove(nurse);

        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("nurse remove successfully in the database");

        return Result.SuccessWithMessage("nurse remove successfully ");
    }

}
