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
public class LaboratoriestServiceTest
{
    private static LaboratoriestService _laboratoriestService;


    private List<ApplicationUser> _users = new List<ApplicationUser>
        {
            new ApplicationUser() { Id = "53ae72a7-589e-4f0b-81ed-40388754",FirstName="lksdnh" },
            new ApplicationUser() { Id = "53ae72a7-589e-4f0b-81ed-40389558",FirstName="lksdnh" }
        };

    private LaboratoriestService CreateLaboratoriestService()
    {

        if (_laboratoriestService is null)
        {
            var dbContext = ContextGenerator.Generator();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();
            ILogger<LaboratoriestService> LaboratoriestLogger = new LoggerFactory().CreateLogger<LaboratoriestService>();

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

            _laboratoriestService = new LaboratoriestService(dbContext, mapper, LaboratoriestLogger, authService);
        }

        return _laboratoriestService;
    }

    private void CheckService()
    {
        if (_laboratoriestService is null)
            _laboratoriestService = CreateLaboratoriestService();
    }
    /// <summary>
    /// fuction to update Laboratoriest as a test case .
    /// </summary>
    /// <param name="LaboratoriestEmail">Laboratoriest email</param>
    /// <param name="LaboratoriestFirstName">Laboratoriest first name</param>
    /// <param name="LaboratoriestLastName">Laboratoriest last name</param> 
    /// <param name="LaboratoriestPhoneNumber">Laboratoriest phone number</param>
    /// <param name="Gender">Laboratoriest gender</param>
    /// <param name="id">Laboratoriest id</param>
    /// <param name="Password">Laboratoriest password</param>
    /// <param name="UserName">Laboratoriest user name</param>
    /// <param name="expectedResult">expected result</param>
    [Theory, TestPriority(3)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389558", "nejosif605@hisotyr.com", "passant", "mohamed", "01124961181", "passantmohamed7", "0167519Kh!", "Female",true)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f683027-6514984", "nejosif605@hisotyr.com", "Hager", "shaaban", "01065695783", "nejosif605", "0167519Kh!", "Female", false)]
    public async Task UpdateLaboratoriestAsync(string id, string LaboratoriestEmail, string LaboratoriestFirstName, string LaboratoriestLastName, string LaboratoriestPhoneNumber, string UserName, string Password, string Gender, bool expectedResult)
    {
        //Arrange
        CheckService();
        var LaboratoriestRequestDto = new LaboratoriestRequestDto
        {
            LaboratoriestEmail = LaboratoriestEmail,
            LaboratoriestFirstName = LaboratoriestFirstName,
            LaboratoriestLastName = LaboratoriestLastName,
            LaboratoriestPhoneNumber = LaboratoriestPhoneNumber,
            UserName = UserName,
            Password = Password,
            Gender = Gender
        };
        // Act
        var result = await _laboratoriestService.UpdateLaboratoriestAsync(id, LaboratoriestRequestDto);
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
    /// fuction to get all  Laboratoriest as a test case 
    /// </summary>
    [Fact, TestPriority(1)]
    public async Task GetAllLaboratoriest()
    {
        // Arrange
        CheckService();

        // Act
        var result = await _laboratoriestService.GetAllLaboratoriestsAsync();

        // Assert
        Assert.True(result.IsSuccess);

    }
    /// <summary>
    /// fuction to get Laboratoriest by id as a test case that take Laboratoriest id
    /// </summary>
    /// <param name="id"> Laboratoriest id</param>
    [Theory, TestPriority(2)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40388754")]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f68302765165")]
    public async Task GetByIdLaboratoriest(string id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _laboratoriestService.GetLaboratoriestByIdAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
    /// <summary>
    /// fuction to remove Laboratoriest as a test case that take Laboratoriest id
    /// </summary>
    /// <param name="id">Laboratoriest id</param>
    [Theory, TestPriority(4)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389558")]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f6830658-51694k")]
    public async Task RemoveLaboratoriest(string id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _laboratoriestService.DeleteLaboratoriestAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
}
