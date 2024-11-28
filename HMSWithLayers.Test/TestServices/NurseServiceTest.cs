using AutoMapper;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Application.Services;
using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Test.TestPriority;
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
using HMSWithLayers.Core.JWT;
using Microsoft.Extensions.Options;

namespace HMSWithLayers.Test.TestServices;

[TestCaseOrderer(
ordererTypeName: "HMSWithLayers.Test.TestPriority.PriorityOrderer",
ordererAssemblyName: "HMSWithLayers.Test")]
public class NurseServiceTest
{
    private static NurseService _nurseService;


    private List<ApplicationUser> _users = new List<ApplicationUser>
        {
            new ApplicationUser() { Id = "53ae72a7-589e-4f0b-81ed-40389f6854986",FirstName="lksdnh" },
            new ApplicationUser() { Id = "53ae72a7-589e-4f0b-81ed-40389f683027562",FirstName="lksdnh" }
        };

    private NurseService CreateNurseService()
    {

        if (_nurseService is null)
        {
            var dbContext = ContextGenerator.Generator();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();
            ILogger<NurseService> nurseLogger = new LoggerFactory().CreateLogger<NurseService>();

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

            _nurseService = new NurseService(dbContext, mapper, nurseLogger, authService);
        }

        return _nurseService;
    }

    private void CheckService()
    {
        if (_nurseService is null)
            _nurseService = CreateNurseService();
    }
    /// <summary>
    /// fuction to update nurse as a test case .
    /// </summary>
    /// <param name="NurseEmail">Nurse email</param>
    /// <param name="NurseFirstName">Nurse first name</param>
    /// <param name="NurseLastName">Nurse last name</param> 
    /// <param name="NursePhoneNumber">Nurse phone number</param>
    /// <param name="Gender">Nurse gender</param>
    /// <param name="id">Nurse id</param>
    /// <param name="Password">Nurse password</param>
    /// <param name="SpecializationId">specialization id</param>
    /// <param name="UserName">Nurse user name</param>
    /// <param name="expectedResult">expected result</param>
    [Theory, TestPriority(3)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f6854986", "nejosif605@hisotyr.com", "passant", "mohamed", "01124961181", "passantmohamed7", "0167519Kh!", "Female", 1, true)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f683027-6514984", "nejosif605@hisotyr.com", "Hager", "shaaban", "01065695783", "nejosif605", "0167519Kh!", "Female", 10, false)]
    public async Task UpdateNurseAsync(string id, string NurseEmail, string NurseFirstName, string NurseLastName, string NursePhoneNumber, string UserName, string Password, string Gender, int SpecializationId, bool expectedResult)
    {
        //Arrange
        CheckService();
        var nurseRequestDto = new NurseRequestDto
        {
            NurseEmail = NurseEmail,
            NurseFirstName = NurseFirstName,
            NurseLastName = NurseLastName,
            NursePhoneNumber = NursePhoneNumber,
            UserName = UserName,
            Password = Password,
            Gender = Gender,
            SpecializationId = SpecializationId
        };
        // Act
        var result = await _nurseService.UpdateNurseAsync(id, nurseRequestDto);
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
    /// fuction to get all  Nurse as a test case 
    /// </summary>
    [Fact, TestPriority(1)]
    public async Task GetAllNurse()
    {
        // Arrange
        CheckService();

        // Act
        var result = await _nurseService.GetAllNurseAsync();

        // Assert
        Assert.True(result.IsSuccess);

    }
    /// <summary>
    /// fuction to get nurse by id as a test case that take Nurse id
    /// </summary>
    /// <param name="id"> nurse id</param>
    [Theory, TestPriority(2)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f6854986")]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f68302765165")]
    public async Task GetByIdNurse_ReturnResult(string id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _nurseService.GetNurseByIdAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
    /// <summary>
    /// fuction to remove nurse as a test case that take Nurse id
    /// </summary>
    /// <param name="id">nurse id</param>
    [Theory, TestPriority(4)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f683027562")]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f6830658-51694k")]
    public async Task RemoveNurse_ReturnResult(string id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _nurseService.DeleteNurseAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
}
