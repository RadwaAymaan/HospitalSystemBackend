using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts
{
    public interface IEmployeeService : IApplicationService, IScopedService
    {
        public Task<Result> AddEmployeeAsync(EmployeeRequestDto employeeRequestDto);
        public Task<Result<List<EmployeeResponseDto>>> GetAllEmployeesAsync();
        public Task<Result<EmployeeResponseDto>> GetEmployeeByIdAsync(string id);
        public  Task<Result> DeleteEmployeeAsync(string id);
        public  Task<Result<EmployeeResponseDto>> UpdateEmployeeAsync(string id, EmployeeRequestDto employeeRequestDto);
    }
}
