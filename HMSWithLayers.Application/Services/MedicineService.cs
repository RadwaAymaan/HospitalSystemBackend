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

public class MedicineService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<MedicineService> logger, IUserContextService userContext) : IMedicineService
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<MedicineService> _logger = logger;
    private readonly IUserContextService _userContext = userContext;

    /// <summary>
    /// function to add medicine that take medicine dto   
    /// </summary>
    /// <param name="MedicineRequestDto">medicine dto</param>
    /// <returns>medicine added successfully</returns>
    public async Task<Result> AddMedicineAsync(MedicineRequestDto medicineRequestDto)
    {
        var medicine = _mapper.Map<Medicine>(medicineRequestDto);
        if (medicine is null)
        {
            _logger.LogError("Failed to map MedicineRequestDto to medicine. MedicineRequestDto: {@MedicineRequestDto}", medicineRequestDto);
            return Result.Invalid(new List<ValidationError>
                {
                    new ValidationError
                    {
                        ErrorMessage = "Validation Errror"
                    }
                });
        }
        
        medicine.CreatedBy = _userContext.Email;
        _dbContext.Medicines.Add(medicine);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("Medicine added successfully in the database");
        return Result.SuccessWithMessage("Medicine added successfully");
    }
    /// <summary>
    /// function to remove  medicine that take medicine id 
    /// </summary>
    /// <param name="Id">medicine id</param>
    /// <returns>medicine remove successfully</returns>
    public async Task<Result> DeleteMedicineAsync(int id)
    {
        var medicine = await _dbContext.Medicines.FindAsync(id);
        if (medicine is null)
        {
            _logger.LogWarning("medicine Invaild Id ,Id {medicineId}", id);
            return Result.NotFound(["medicine Invaild Id"]);
        }
        medicine.Prescriptions = medicine.Prescriptions;
        _dbContext.Medicines.Remove(medicine);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("medicine remove successfully in the database");
        return Result.SuccessWithMessage("Medicine remove successfully ");
    }
    /// <summary>
    /// function to get all medicine 
    /// </summary>
    /// <returns>list of medicine response dto </returns>
    public async Task<Result<List<MedicineResponseDto>>> GetAllMedicinesAsync()
    {
        var medicine = await _dbContext.Medicines
                          .ProjectTo<MedicineResponseDto>(_mapper.ConfigurationProvider)
                          .ToListAsync();
        _logger.LogInformation("Fetching all medicines. Total count: {medicine}.", medicine.Count);
        return Result.Success(medicine);
    }
    /// <summary>
    /// function to get  medicine by id  that take  medicine id
    /// </summary>
    /// <param name="Id">medicine id</param>
    /// <returns>medicine response dto </returns>
    public async Task<Result<MedicineResponseDto>> GetMedicineByIdAsync(int id)
    {
        var medicine = await _dbContext.Medicines
              .ProjectTo<MedicineResponseDto>(_mapper.ConfigurationProvider)
              .FirstOrDefaultAsync(d => d.Id == id);
        if (medicine is null)
        {
            _logger.LogWarning("medicine Id not found,Id {medicineId}", id);
            return Result.NotFound(["medicine not found"]);
        }
        _logger.LogInformation("Fetching medicine");
        return Result.Success(medicine);
    }

    /// <summary>
    /// function to update medicine  that take  medicine id and medicine dto
    /// </summary>
    /// <param name="Id">medicine id</param>
    /// <param name="MedicineRequestDto">medicine dto</param>
    /// <returns>medicine response dto </returns>
    public async Task<Result<MedicineResponseDto>> UpdateMedicineAsycn(int id, MedicineRequestDto MedicineRequestDto )
    {
        var medicine = await _dbContext.Medicines.FindAsync(id);
        if (medicine is null)
        {
            _logger.LogWarning("medicine Invaild Id ,Id {medicineId}", id);
            return Result.NotFound(["medicine Invaild Id"]);
        }
       
        medicine.ModifiedBy = _userContext.Email;
        _mapper.Map(MedicineRequestDto, medicine);
        await _dbContext.SaveChangesAsync();

        var medicineResponse = _mapper.Map<MedicineResponseDto>(medicine);
        if (medicineResponse is null)
        {
            _logger.LogError("Failed to map MedicineRequestDto to medicineResponseDto. pharmacistDto: {@MedicineRequestDto}", MedicineRequestDto);
            return Result.Invalid(new List<ValidationError>
                {
                    new ValidationError
                    {
                        ErrorMessage = "Validation Errror"
                    }
                });
        }

        _logger.LogInformation("Updated medicine , Id {Id}", id);

        return Result.Success(medicineResponse);
    }
}

