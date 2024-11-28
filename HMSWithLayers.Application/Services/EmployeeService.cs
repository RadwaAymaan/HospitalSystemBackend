using AutoMapper;
using AutoMapper.QueryableExtensions;
using Castle.Core.Logging;
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
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Services;

public class EmployeeService(HMSBaseDbContext dbContext, IMapper mapper, ILogger<EmployeeService> logger, IAuthService authService) : IEmployeeService 
{
    private readonly HMSBaseDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<EmployeeService> _logger = logger;
    private readonly IAuthService _authService = authService;

    /// <summary>
    /// function to add employee that take employee dto   
    /// </summary>
    /// <param name="employeeRequestDto">employee dto</param>
    /// <returns>employee added successfully</returns>

    public async Task<Result> AddEmployeeAsync(EmployeeRequestDto employeeRequestDto)
    {
        var employee = _mapper.Map<Employee>(employeeRequestDto);
        var department = await _dbContext.Departments.FindAsync(employeeRequestDto.DepartmentId);
        if (department is null)
        {
            _logger.LogWarning("Department Invaild Id ,Id {departmentId}", employeeRequestDto.DepartmentId);
            return Result.NotFound(["Department Invaild Id"]);
        }
        employee.Department = department;
        var employeeAdded = await _authService.RegisterEmployeeAsync( employeeRequestDto);
        if (!employeeAdded.IsSuccess)
        {
            return Result.Error(employeeAdded.Errors.FirstOrDefault());
        }
        _logger.LogInformation("Employee added successfully in the database");
        return Result.SuccessWithMessage("Employee added successfully");
    }

    /// <summary>
    /// function to get all employees 
    /// </summary>
    /// <returns>list of employee response dto </returns>
    public async Task<Result<List<EmployeeResponseDto>>> GetAllEmployeesAsync()
    {
        var employees = await _dbContext.Users.OfType<Employee>()
                  .ProjectTo<EmployeeResponseDto>(_mapper.ConfigurationProvider)
                  .ToListAsync();
        _logger.LogInformation("Fetching all employee. Total count: {employee}.", employees.Count);
        return Result.Success(employees);
    }
    /// <summary>
    /// function to remove  employee that take employee id 
    /// </summary>
    /// <param name="Id">employee id</param>
    /// <returns>employee remove successfully</returns>
    public async Task<Result> DeleteEmployeeAsync(string id)
    {
        var employee = await _dbContext.Employees.FindAsync(id);

        if (employee is null)
        {
            _logger.LogWarning("employee Invaild Id ,Id {employeeId}", id);
            return Result.NotFound(["employee Invaild Id"]);
        }

        _dbContext.Employees.Remove(employee);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation("employee remove successfully in the database");
        return Result.SuccessWithMessage("employee remove successfully ");
    }

    /// <summary>
    /// function to get  employee by id  that take  employee id
    /// </summary>
    /// <param name="Id">employee id</param>
    /// <returns>employee response dto </returns>
    public async Task<Result<EmployeeResponseDto>> GetEmployeeByIdAsync(string Id)
    {
        var employee = await _dbContext.Employees
            .ProjectTo<EmployeeResponseDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(d => d.Id == Id);
        if (employee is null)
        {
            _logger.LogWarning("employee Id not found,Id {employeeId}", Id);
            return Result.NotFound(["employee not found"]);
        }
        _logger.LogInformation("Fetching employee");
        return Result.Success(employee);
    }
    /// <summary>
    /// function to update employee  that take  employee id and employee dto
    /// </summary>
    /// <param name="id">employee id</param>
    /// <param name="employeeRequestDto">employee dto</param>
    /// <returns>employee response dto </returns>
    public async Task<Result<EmployeeResponseDto>> UpdateEmployeeAsync(string id, EmployeeRequestDto employeeRequestDto)
    {
        var employee = await _dbContext.Employees.FindAsync(id);

        if (employee is null)
        {
            _logger.LogWarning("employee Id not found,Id {employeeId}", id);
            return Result.NotFound(["employee not found"]);
        }

        _mapper.Map(employeeRequestDto, employee);

        await _dbContext.SaveChangesAsync();

        var employeeResponse = _mapper.Map<EmployeeResponseDto>(employee);
        if (employeeResponse is null)
        {
            _logger.LogError("Failed to map employeeRequestDto to employeeResponseDto. employeeRequestDto: {@employeeRequestDto}", employeeRequestDto);
            return Result.Invalid(new List<ValidationError>
                {
                    new ValidationError
                    {
                        ErrorMessage = "Validation Errror"
                    }
                });
        }

        _logger.LogInformation("Updated employee , Id {Id}", id);

        return Result.Success(employeeResponse);
    }

}