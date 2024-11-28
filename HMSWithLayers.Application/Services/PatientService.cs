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

public class PatientService(HMSBaseDbContext dbContext, ILogger<PatientService> logger, IMapper mapper) : IPatientService
{
	private readonly HMSBaseDbContext _dbContext = dbContext;
	private readonly ILogger<PatientService> _logger = logger;
	private readonly IMapper _mapper = mapper;

	/// <summary>
	/// function to get all patients  
	/// </summary>
	/// <returns>list all patients response dto </returns>
	public async Task<Result<List<PatientGetAllResponseDto>>> GetAllPatientsAsync()
	{
		var patients = await _dbContext.Users.OfType<Patient>()
			  .ProjectTo<PatientGetAllResponseDto>(_mapper.ConfigurationProvider)
			  .ToListAsync();

		_logger.LogInformation("Fetching all patients. Total count: {patients}.", patients.Count);

		return Result.Success(patients);
	}

	/// <summary>
	/// function to get patient by id that take  patient id
	/// </summary>
	/// <param name="Id">patient id</param>
	/// <returns>details for patient response dto</returns>
	public async Task<Result<PatientByIdResponseDto>> GetPatientByIdAsync(string Id)
	{
		var patient = await _dbContext.Users.OfType<Patient>()
			  .ProjectTo<PatientByIdResponseDto>(_mapper.ConfigurationProvider)
			  .FirstOrDefaultAsync(P => P.Id == Id);

		if (patient is null)
		{
			_logger.LogWarning("patient id not found,Id {patientId}", Id);

			return Result.NotFound(["patient not found"]);
		}

		_logger.LogInformation("Fetching patient by id");

		return Result.Success(patient);
	}

    /// <summary>
    /// function to update patient by id that take  patient id and patient dto
    /// </summary>
    /// <param name="Id">patient id</param>
    /// <param name="patientRequestDto">patient dto</param>
    /// <returns>updated patient response dto </returns>

    public async Task<Result<PatientByIdResponseDto>> UpdatePatientAsync(string Id, PatientRequestDto patientRequestDto)
	{
		var patient = await _dbContext.Patients.FindAsync(Id);

		if (patient is null)
		{
			_logger.LogWarning("patient id not found,Id {patient id}", Id);

			return Result.NotFound(["patient not found"]);
		}

		_mapper.Map(patientRequestDto, patient);

		await _dbContext.SaveChangesAsync();

		var mappedPatient = _mapper.Map<PatientByIdResponseDto>(patient);

		if (mappedPatient is null)
		{
			_logger.LogError("Failed to map patient dto to patient . PatientByIdResponseDto: {@PatientByIdResponseDto}", patientRequestDto);

			return Result.Invalid(new List<ValidationError>
			{
			   new ValidationError
			   {
				  ErrorMessage = "Validation Errror"
			   }
			});
		}

		_logger.LogInformation("Updated patient , Id {Id}", Id);

		return Result.Success(mappedPatient);
	}

	/// <summary>
	/// function to remove patient by id that take patient id 
	/// </summary>
	/// <param name="Id">patient id</param>
	/// <returns>patiet remove successfully</returns>
	public async Task<Result> DeletePatientAsync(string Id)
	{
		var patient = await _dbContext.Patients.FindAsync(Id);

		if (patient is null)
		{
			_logger.LogWarning("Invaild id for patient ,Id {pateintId}", Id);

			return Result.NotFound(["Invaild id for patient"]);
		}

		_dbContext.Patients.Remove(patient);

		await _dbContext.SaveChangesAsync();

		_logger.LogInformation("patient remove successfully in the database");

		return Result.SuccessWithMessage("patient remove successfully ");
	}
}
