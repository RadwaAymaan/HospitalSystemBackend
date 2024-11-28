using AutoMapper;
using AutoMapper.QueryableExtensions;
using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Services;

public class DepartmentService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<DepartmentService> logger, IUserContextService userContext) : IDepartmentService
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<DepartmentService> _logger = logger;
    private readonly IUserContextService _userContext = userContext;

    /// <summary>
    /// function for add department that take departmentRequestDto   
    /// </summary>
    /// <param name="departmentRequestDto">department dto</param>
    /// <returns>department added successfully</returns>
    public async Task<Result> AddDepartmentAsync(DepartmentRequestDto departmentRequestDto)
    {
        var mappedDepartment = _mapper.Map<Department>(departmentRequestDto);
        if (mappedDepartment is null)
        {
            _logger.LogError("Failed to map departmentRequestDto to Department. departmentRequestDto: {@DepartmentRequestDto}", departmentRequestDto);
            return Result.Invalid(new List<ValidationError>
            {
                new ValidationError
                {
                    ErrorMessage = "Validation Errror"
                }
            });
        }
        mappedDepartment.CreatedBy = _userContext.Email;
        _dbContext.Departments.Add(mappedDepartment);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("department added successfully to the database");
        return Result.SuccessWithMessage("department added successfully");
    }

    /// <summary>
    /// function for remove department by id that take department id 
    /// </summary>
    /// <param name="id">department id</param>
    /// <returns>department removed successfully</returns>
    public async Task<Result> DeleteDepartmentAsync(int id)
    {
        var department = await _dbContext.Departments.FindAsync(id);

        if (department is null)
        {
            _logger.LogWarning("department Invaild Id ,Id {DepartmentId}", id);
            return Result.NotFound(["department Invaild Id"]);
        }

        _dbContext.Departments.Remove(department);
        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("department remove successfully in the database");
        return Result.SuccessWithMessage("department removed successfully");
    }

    /// <summary>
    /// function for get all department  
    /// </summary>
    /// <returns>list of department response dto </returns>
    public async Task<Result<List<DepartmentResponseDto>>> GetAllDepartmentsAsync()
    {
        var mappedDepartment = await _dbContext.Departments
          .ProjectTo<DepartmentResponseDto>(_mapper.ConfigurationProvider)
          .ToListAsync();
        _logger.LogInformation("Fetching all department. Total count: {Department}.", mappedDepartment.Count);
        return Result.Success(mappedDepartment);
    }

    /// <summary>
    /// function for get by id department  that take  department id
    /// </summary>
    /// <param name="id">department id</param>
    /// <returns>department response dto </returns>
    public async Task<Result<DepartmentResponseDto>> GetDepartmentByIdAsync(int id)
    {
        var department = await _dbContext.Departments
          .ProjectTo<DepartmentResponseDto>(_mapper.ConfigurationProvider)
          .FirstOrDefaultAsync(s => s.Id == id);
        if (department is null)
        {
            _logger.LogWarning("department Id not found,Id {DepartmentId}", id);
            return Result.NotFound(["department not found"]);
        }
        _logger.LogInformation("Fetching department");
        return Result.Success(department);
    }

    /// <summary>
    /// function for update department by id that take  department id and departmentRequestDto
    /// </summary>
    /// <param name="id">department id</param>
    /// <param name="departmentRequestDto">department dto</param>
    /// <returns>department response dto </returns>
    public async Task<Result<DepartmentResponseDto>> UpdateDepartmentAsync(int id, DepartmentRequestDto departmentRequestDto)
    {
        var department = await _dbContext.Departments.FindAsync(id);

        if (department is null)
        {
            _logger.LogWarning("department Id not found,Id {departmentId}", id);
            return Result.NotFound(["department not found"]);
        }

        _mapper.Map(departmentRequestDto, department);
        department.ModifiedBy = _userContext.Email;
        await _dbContext.SaveChangesAsync();

        var departmentResponse = _mapper.Map<DepartmentResponseDto>(department);
        if (departmentResponse is null)
        {
            _logger.LogError("Failed to map departmentRequestDto to departmentResponseDto. departmentRequestDto: {@DepartmentRequestDto}", departmentRequestDto);
            return Result.Invalid(new List<ValidationError>
                {
                    new ValidationError
                    {
                        ErrorMessage = "Validation Errror"
                    }
                });
        }

        _logger.LogInformation("Updated department , Id {Id}", id);

        return Result.Success(departmentResponse);
    }
}
