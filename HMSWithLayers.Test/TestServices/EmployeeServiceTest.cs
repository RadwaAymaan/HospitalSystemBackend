using AutoMapper;
using HMSWithLayers.Application.Services;
using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Test.TestSetup;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMSWithLayers.API.Mapping;
using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Test.TestPriority;
using HMSWithLayers.Core.JWT;
using Microsoft.Extensions.Options;

namespace HMSWithLayers.Test.TestServices;

[TestCaseOrderer(
ordererTypeName: "HMSWithLayers.Test.TestPriority.PriorityOrderer",
ordererAssemblyName: "HMSWithLayers.Test")]
public class EmployeeServiceTest
{
    private static EmployeeService _employeeService;


    private List<ApplicationUser> _users = new List<ApplicationUser>
        {
            new ApplicationUser() { Id = "78ty72a7-589e-4f0b-81ed-40389f683616",FirstName="user1" },
            new ApplicationUser() { Id = "78ty72a7-589e-4f0b-81ed-40389f689009",FirstName="user2" }
        };

    private EmployeeService CreateEmployeeService()
    {

        if (_employeeService is null)
        {
            var dbContext = ContextGenerator.Generator();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();
            ILogger<EmployeeService> employeeLogger = new LoggerFactory().CreateLogger<EmployeeService>();

            ILogger<ApplicationUser> userLogger = new LoggerFactory().CreateLogger<ApplicationUser>();
            var userStore = new UserStore<ApplicationUser>(dbContext);
            UserManager<ApplicationUser> userManager = InMemoryUserStore.MockUserManager(_users).Object;

            var jwtOptions = Options.Create(new JWT
            {
                Issuer = "TOTPlatform",
                Audience = "PlatformUsers",
                Key = "QqEz6jAMz8LIsXLcm4GtSOp24cQ50LxPlY/cgZ4NCZQ=",
                DurationInDays = 1
            });
            var authService = new AuthService(userManager, userLogger, mapper, jwtOptions);

            _employeeService = new EmployeeService(dbContext, mapper, employeeLogger, authService);
        }

        return _employeeService;
    }

    private void CheckService()
    {
        if (_employeeService is null)
            _employeeService = CreateEmployeeService();
    }
    /// <summary>
    /// fuction to update employee as a test case .
    /// </summary>
    /// <param name="EmployeeEmail">employee email</param>
    /// <param name="EmployeeFirstName">employee first name</param>
    /// <param name="EmployeeLastName">employee last name</param> 
    /// <param name="EmployeePhoneNumber">employee phone number</param>
    /// <param name="Gender">employee gender</param>
    /// <param name="id">employee id</param>
    /// <param name="Password">employee password</param>
    /// <param name="DepartmentId">department id</param>
    /// <param name="UserName">employee user name</param>
    /// <param name="expectedResult">expected result</param>
    [Theory, TestPriority(3)]
    [InlineData("78ty72a7-589e-4f0b-81ed-40389f683616", "nejosif605@hisotyr.com", "mariam", "abdeen", "01021432813", "meme", "0167519Kh!", "Female", 3, true)]
    [InlineData("78ty72a7-589e-4f0b-81ed-40389f689009", "nejosif605@hisotyr.com", "mariam", "abdeen", "01021432813", "meme", "0167519Kh!", "Female", 10, false)]
    public async Task UpdateEmployeeAsync(string id, string EmployeeEmail, string EmployeeFirstName, string EmployeeLastName, string EmployeePhoneNumber, string UserName, string Password, string Gender, int DepartmentId, bool expectedResult)
    {
        //Arrange
        CheckService();
        var employeeRequestDto = new EmployeeRequestDto
        {
            EmployeeEmail = EmployeeEmail,
            EmployeeFirstName = EmployeeFirstName,
            EmployeeLastName = EmployeeLastName,
            EmployeePhoneNumber = EmployeePhoneNumber,
            UserName = UserName,
            Password = Password,
            Gender = Gender,
            DepartmentId = DepartmentId,
        };
        // Act
        var result = await _employeeService.UpdateEmployeeAsync(id, employeeRequestDto);
        // Assert
        if (expectedResult)
        {
            Assert.True(result.IsSuccess); // Expecting successful update
        }
        else
        {
            Assert.False(result.IsSuccess); // Expecting unsuccessful update
        }
    }
    /// <summary>
    /// fuction to get all  employee as a test case 
    /// </summary>
    [Fact, TestPriority(1)]
    public async Task GetAllEmployee()
    {
        // Arrange
        CheckService();

        // Act
        var result = await _employeeService.GetAllEmployeesAsync();

        // Assert
        Assert.True(result.IsSuccess);

    }
    /// <summary>
    /// fuction to get employee by id as a test case that take employee id
    /// </summary>
    /// <param name="id"> employee id</param>
    [Theory, TestPriority(2)]
    [InlineData("78ty72a7-589e-4f0b-81ed-40389f683027")]
    [InlineData("78ty72a7-589e-4f0b-81ed-40389f689009")]
    public async Task GetByIdEmployee_ReturnResult(string id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _employeeService.GetEmployeeByIdAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
    /// <summary>
    /// fuction to remove employee as a test case that take employee id
    /// </summary>
    /// <param name="id">employee id</param>
    [Theory, TestPriority(4)]
    [InlineData("78ty72a7-589e-4f0b-81ed-40389f683027")]
    [InlineData("78ty72a7-589e-4f0b-81ed-40389f68900r9")]
    public async Task RemoveEmployee_ReturnResult(string id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _employeeService.DeleteEmployeeAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
}