using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Application.Services;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Profiling;
using System.Security.Claims;

namespace HMSWithLayers.API.Controllers;

public class DepartmentController(IDepartmentService departmentService) : BaseController
{
    private readonly IDepartmentService _departmentService = departmentService;

    /// <summary>
    /// action for add department that take department request dto   
    /// </summary>
    /// <param name="departmentDto">department dto</param>
    /// <returns>result of department added successfully</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> Adddepartment(DepartmentRequestDto departmentDto)
    {
        using (MiniProfiler.Current.Step("Add Department"))
        {
            return await _departmentService.AddDepartmentAsync(departmentDto);
        }
    }

    /// <summary>
    /// action for get all departments 
    /// </summary>
    /// <returns>result of list from department response dto</returns>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<List<DepartmentResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<DepartmentResponseDto>>> GetAllDepartments()
    {
        using (MiniProfiler.Current.Step("query data"))
        {
            return await _departmentService.GetAllDepartmentsAsync();
        }
    }

    /// <summary>
    /// action for get by id department  that take  department id
    /// </summary>
    /// <param name="id">department id</param>
    /// <returns>result of department response dto </returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<DepartmentResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<DepartmentResponseDto>> GetDepartmentById(int id)
    {
        using (MiniProfiler.Current.Step("Add Department"))
        {
            return await _departmentService.GetDepartmentByIdAsync(id);
        }
    }
    /// <summary>
    /// action for update department by id that take  department id and department request dto
    /// </summary>
    /// <param name="id">department id</param>
    /// <param name="departmentDto">department dto</param>
    /// <returns>result of department response dto after updated</returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result<DepartmentResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<DepartmentResponseDto>> Updatedepartment(int id, DepartmentRequestDto departmentDto)
    {
        return await _departmentService.UpdateDepartmentAsync(id, departmentDto);
    }

    /// <summary>
    /// action for remove department by id that take department id 
    /// </summary>
    /// <param name="id">department id</param>
    /// <returns>result of department removed successfully</returns>
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> Deletedepartment(int id)
    {
        return await _departmentService.DeleteDepartmentAsync(id);
    }
}
