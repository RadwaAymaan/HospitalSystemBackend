using AutoMapper;
using AutoMapper.QueryableExtensions;
using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HMSWithLayers.Application.Services;
public class DoctorService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<DoctorService> logger, IAuthService authService)  : IDoctorService
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<DoctorService> _logger = logger;
    private readonly IAuthService _authService = authService;

    
    /// <summary>
    /// function to add doctor that take doctor dto   
    /// </summary>
    /// <param name="specializationDto">specialization dto</param>
    /// <returns>doctor added successfully</returns>
    public async Task<Result> AddDoctorAsync(DoctorRequestDto doctorRequestDto)
    {   var doctor =  _mapper.Map<Doctor>(doctorRequestDto);
        var specialization = await _dbContext.Specializations.FindAsync(doctorRequestDto.SpecializationId);
        if (specialization is null)
        {
            _logger.LogWarning("specialization Invaild Id ,Id {specializationId}", doctorRequestDto.SpecializationId);
            return Result.NotFound(["specialization Invaild Id"]);
        }
        doctor.Specialization = specialization; 
        var doctorAdded =  await _authService.RegisterDoctorAsync(doctorRequestDto);
        if(!doctorAdded.IsSuccess)
        {
            return Result.Error(doctorAdded.Errors.FirstOrDefault());
        }
        _logger.LogInformation("Doctor added successfully in the database");
        return Result.SuccessWithMessage("Doctor added successfully");
    }
    /// <summary>
    /// function to remove  doctor that take doctor id 
    /// </summary>
    /// <param name="Id">doctor id</param>
    /// <returns>doctor remove successfully</returns>
    public async Task<Result> DeleteDoctorAsync(string id)
    {
        var doctor = await _dbContext.Doctors.FindAsync(id);

        if (doctor is null)
        {
            _logger.LogWarning("doctor Invaild Id ,Id {doctorId}", id);
            return Result.NotFound(["doctor Invaild Id"]);
        }

        _dbContext.Doctors.Remove(doctor);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("doctor remove successfully in the database");
        return Result.SuccessWithMessage("Doctor remove successfully ");
    }

    /// <summary>
    /// function to get all doctors 
    /// </summary>
    /// <returns>list of doctor response dto </returns>
    public async Task<Result<List<DoctorResponseDto>>> GetAllDoctorsAsync()
    {
        var doctors = await _dbContext.Users.OfType<Doctor>()
                  .ProjectTo<DoctorResponseDto>(_mapper.ConfigurationProvider)
                  .ToListAsync();
        _logger.LogInformation("Fetching all doctor. Total count: {doctor}.", doctors.Count);
        return Result.Success(doctors);
    }

    /// <summary>
    /// function to get  doctor by id  that take  doctor id
    /// </summary>
    /// <param name="Id">doctor id</param>
    /// <returns>doctor response dto </returns>
    public async Task<Result<DoctorResponseDto>> GetDoctorByIdAsync(string id)
    {
        var doctor = await _dbContext.Users.OfType<Doctor>()
                  .ProjectTo<DoctorResponseDto>(_mapper.ConfigurationProvider)
                  .FirstOrDefaultAsync(d => d.Id == id);
        if (doctor is null)
        {
            _logger.LogWarning("doctor Id not found,Id {doctorId}", id);
            return Result.NotFound(["doctor not found"]);
        }
        _logger.LogInformation("Fetching doctor");
        return Result.Success(doctor);
    }

    /// <summary>
    /// function to update doctor  that take  doctor id and doctor dto
    /// </summary>
    /// <param name="Id">doctor id</param>
    /// <param name="DoctorRequestDto">doctor dto</param>
    /// <returns>doctor response dto </returns>
    public async Task<Result<DoctorResponseDto>> UpdateDoctorAsycn(string id, DoctorRequestDto doctorRequestDto)
    {
        var doctor = await _dbContext.Doctors.FindAsync(id);

        if (doctor is null)
        {
            _logger.LogWarning("doctor Id not found,Id {doctorId}", id);
            return Result.NotFound(["Doctor not found"]);
        }

        _mapper.Map(doctorRequestDto, doctor);

        await _dbContext.SaveChangesAsync();

        var doctorResponse = _mapper.Map<DoctorResponseDto>(doctor);
        if (doctorResponse is null)
        {
            _logger.LogError("Failed to map DoctorRequestDto to doctorResponseDto. DoctorRequestDto: {@DoctorRequestDto}", doctorRequestDto);
            return Result.Invalid(new List<ValidationError>
                {
                    new ValidationError
                    {
                        ErrorMessage = "Validation Errror"
                    }
                });
        }

        _logger.LogInformation("Updated doctor , Id {Id}", id);

        return Result.Success(doctorResponse);
    }
}
