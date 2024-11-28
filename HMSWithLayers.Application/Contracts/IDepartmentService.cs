using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IDepartmentService : IApplicationService, IScopedService
{
    public Task<Result> AddDepartmentAsync(DepartmentRequestDto departmentRequestDto);
    public Task<Result<List<DepartmentResponseDto>>> GetAllDepartmentsAsync();
    public Task<Result<DepartmentResponseDto>> GetDepartmentByIdAsync(int id);
    public Task<Result<DepartmentResponseDto>> UpdateDepartmentAsync(int id, DepartmentRequestDto departmentRequestDto);
    public Task<Result> DeleteDepartmentAsync(int id);
}
