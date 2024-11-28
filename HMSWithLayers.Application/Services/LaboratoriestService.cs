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

public class LaboratoriestService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<LaboratoriestService> logger, IAuthService authService) : ILaboratoriestService
{
	private readonly HMSBaseDbContext _dbContext = dbContext;
	private readonly IMapper _mapper = mapper;
	private readonly ILogger<LaboratoriestService> _logger = logger;
	private readonly IAuthService _authService = authService;

	
	/// <summary>
	/// function to add laboratoriest that take laboratoriestDto   
	/// </summary>
	/// <param name="LaboratoriestDto">laboratoriest dto</param>
	/// <returns>laboratoriest added successfully</returns>
	public async Task<Result> AddLaboratoriestAsync(LaboratoriestRequestDto laboratoriestDto)
	{
		var mappedLaboratorist = _mapper.Map<Laboratorist>(laboratoriestDto);

		var laboratoriest = await _authService.RegisterLaboratoristAsync(laboratoriestDto);

		if (!laboratoriest.IsSuccess)
		{
			return Result.Error(laboratoriest.Errors.FirstOrDefault());
		}

		_logger.LogInformation("Laboratorist added successfully in the database");

		return Result.SuccessWithMessage("Laboratorist added successfully");
	}

	/// <summary>
	/// function to get all laboratoriests
	/// </summary>
	/// <returns>list alllaboratoriests response dto </returns>
	public async Task<Result<List<LaboratoriestResponseDto>>> GetAllLaboratoriestsAsync()
	{
		var laboratoriests = await _dbContext.Users.OfType<Laboratorist>()
			  .ProjectTo<LaboratoriestResponseDto>(_mapper.ConfigurationProvider)
			  .ToListAsync();

		_logger.LogInformation("Fetching all laboratoriests. Total count: {laboratoriests}.", laboratoriests.Count);

		return Result.Success(laboratoriests);
	}

	/// <summary>
	/// function to get laboratoriest by id that take laboratoriest id
	/// </summary>
	/// <param name="Id">laboratoriest id</param>
	/// <returns>details for laboratoriest response dto</returns>
	public async Task<Result<LaboratoriestResponseDto>> GetLaboratoriestByIdAsync(string id)
	{
		var laboratoriest = await _dbContext.Users.OfType<Laboratorist>()
				  .ProjectTo<LaboratoriestResponseDto>(_mapper.ConfigurationProvider)
				  .FirstOrDefaultAsync(L => L.Id == id);

		if (laboratoriest is null)
		{
			_logger.LogWarning("laboratoriest id not found,Id {laboratoriestId}", id);

			return Result.NotFound(["laboratoriest not found"]);
		}

		_logger.LogInformation("Fetching laboratoriest by id");

		return Result.Success(laboratoriest);
	}

	/// <summary>
	/// function to update laboratorist that take laboratorist id and room laboratorist dto
	/// </summary>
	/// <param name="Id">laboratorist id</param>
	/// <param name="LaboratoriestDto">laboratorist dto</param>
	/// <returns>updated laboratorist response dto </returns>
	public async Task<Result<LaboratoriestResponseDto>> UpdateLaboratoriestAsync(string id, LaboratoriestRequestDto laboratoriestDto)
	{
		var laboratorist = await _dbContext.Laboratorists.FindAsync(id);

		if (laboratorist is null)
		{
			_logger.LogWarning("laboratorist id not found,Id {laboratoristId}", id);

			return Result.NotFound(["laboratorist not found"]);
		}

		_mapper.Map(laboratoriestDto, laboratorist);

		await _dbContext.SaveChangesAsync();

		var mappedLaboratoriest = _mapper.Map<LaboratoriestResponseDto>(laboratorist);

		if (mappedLaboratoriest is null)
		{
			_logger.LogError("Failed to map pharmacistDto to laboratoriestDtoResponseDto. laboratoriestDto: {@laboratoriestDtoDto}", laboratoriestDto);

			return Result.Invalid(new List<ValidationError>
			{
			    new ValidationError
				{
				   ErrorMessage = "Validation Errror"
				}
			});
		}

		_logger.LogInformation("Updated laboratorist , Id {Id}", id);

		return Result.Success(mappedLaboratoriest);
	}

	/// <summary>
	/// function to remove laboratorist that take laboratorist id 
	/// </summary>
	/// <param name="Id">laboratorist id</param>
	/// <returns>laboratorist remove successfully</returns>
	public async Task<Result> DeleteLaboratoriestAsync(string id)
	{
		var laboratorist = await _dbContext.Laboratorists.FindAsync(id);

		if (laboratorist is null)
		{
			_logger.LogWarning("Invaild id for laboratorist ,Id {laboratoristId}", id);

			return Result.NotFound(["Invaild id for laboratorist"]);
		}

		_dbContext.Laboratorists.Remove(laboratorist);

		await _dbContext.SaveChangesAsync();

		_logger.LogInformation("laboratorist remove successfully in the database");

		return Result.SuccessWithMessage("laboratorist remove successfully");
	}
}
