using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Application.Services;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSWithLayers.API.Controllers
{
    public class EmployeeController(IEmployeeService employeeService) : BaseController
    {
        private readonly IEmployeeService _employeeService = employeeService;

        /// <summary>
        /// action for add employee that take employee dto   
        /// </summary>
        /// <param name="employeeRequestDto">employee dto</param>
        /// <returns>result of employee added successfully</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)] 
        public async Task<Result> AddEmployee(EmployeeRequestDto employeeRequestDto)
        {
            return await _employeeService.AddEmployeeAsync(employeeRequestDto);
        }
        /// <summary>
        /// action for get all employee  
        /// </summary>
        /// <returns>result of list from employee response dto </returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Result<List<EmployeeResponseDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        public async Task<Result<List<EmployeeResponseDto>>> GetAllEmployees()
        {
            return await _employeeService.GetAllEmployeesAsync();
        }
        /// <summary>
        /// action for get by id employee  that take  employee id
        /// </summary>
        /// <param name="id">employee id</param>
        /// <returns>result of employee response dto </returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Result<EmployeeResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        public async Task<Result<EmployeeResponseDto>> GetEmployeeById(string id)
        {
            return await _employeeService.GetEmployeeByIdAsync(id);
        }
        /// <summary>
        /// action for remove  employee by id that take employee id 
        /// </summary>
        /// <param name="id">employee id</param>
        /// <returns>result of employee remove successfully</returns>
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        public async Task<Result> Deleteemployee(string id)
        {
            return await _employeeService.DeleteEmployeeAsync(id);
        }
        /// <summary>
        /// action for update employee by id that take  employee id and employee dto
        /// </summary>
        /// <param name="id">employee id</param>
        /// <param name="employeeDto">employee dto</param>
        /// <returns>result of employee response dto after updated</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(typeof(Result<EmployeeResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        public async Task<Result<EmployeeResponseDto>> UpdateEmployee(string id, EmployeeRequestDto employeeDto)
        {
            return await _employeeService.UpdateEmployeeAsync(id, employeeDto);
        }

    }
}
