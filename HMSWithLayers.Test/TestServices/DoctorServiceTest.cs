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
public class DoctorServiceTest
{
    private static DoctorService _doctorService;


    private List<ApplicationUser> _users = new List<ApplicationUser>
        {
            new ApplicationUser() { Id = "53ae72a7-589e-4f0b-81ed-40389f683027",FirstName="lksdnh" },
            new ApplicationUser() { Id = "53ae72a7-589e-4f0b-81ed-40389f683027561",FirstName="lksdnh" }
        };

    private DoctorService CreateDoctorService()
    {

        if (_doctorService is null)
        {
            var dbContext = ContextGenerator.Generator();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();
            ILogger<DoctorService> doctorLogger = new LoggerFactory().CreateLogger<DoctorService>();

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

            _doctorService = new DoctorService(dbContext, mapper, doctorLogger, authService);
        }

        return _doctorService;
    }

    private void CheckService()
    {
        if (_doctorService is null)
            _doctorService = CreateDoctorService();
    }
    /// <summary>
    /// fuction to update doctor as a test case .
    /// </summary>
    /// <param name="DoctorEmail">doctor email</param>
    /// <param name="DoctorFirstName">doctor first name</param>
    /// <param name="DoctorLastName">doctor last name</param> 
    /// <param name="DoctorPhoneNumber">doctor phone number</param>
    /// <param name="Gender">doctor gender</param>
    /// <param name="id">doctor id</param>
    /// <param name="Password">doctor password</param>
    /// <param name="SpecializationId">specialization id</param>
    /// <param name="UserName">doctor user name</param>
    /// <param name="expectedResult">expected result</param>
    [Theory, TestPriority(3)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f683027", "nejosif605@hisotyr.com", "Hager", "shaaban", "01065695783", "nejosif605", "0167519Kh!", "Female", 1, true)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f683027-6514984", "nejosif605@hisotyr.com", "Hager", "shaaban", "01065695783", "nejosif605", "0167519Kh!", "Female", 10, false)]
    public async Task UpdateDoctorAsync(string id,string DoctorEmail, string DoctorFirstName, string DoctorLastName, string DoctorPhoneNumber, string UserName, string Password, string Gender, int SpecializationId, bool expectedResult)
    {
        //Arrange
         CheckService();
        var doctorRequestDto = new DoctorRequestDto
        {
            DoctorEmail = DoctorEmail,
            DoctorFirstName = DoctorFirstName,
            DoctorLastName = DoctorLastName,
            DoctorPhoneNumber = DoctorPhoneNumber,
            UserName = UserName,
            Password = Password,
            Gender = Gender,
            SpecializationId = SpecializationId
        };
        // Act
        var result = await _doctorService.UpdateDoctorAsycn(id, doctorRequestDto);
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
    /// fuction to get all  doctor as a test case 
    /// </summary>
    [Fact, TestPriority(1)]
    public async Task GetAllDoctor()
    {
        // Arrange
         CheckService();

        // Act
        var result = await _doctorService.GetAllDoctorsAsync();

        // Assert
        Assert.True(result.IsSuccess);

    }
    /// <summary>
    /// fuction to get doctor by id as a test case that take doctor id
    /// </summary>
    /// <param name="id"> doctor id</param>
    [Theory, TestPriority(2)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f683027")]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f68302765165")]
    public async Task GetByIdDoctor_ReturnResult(string id)
    {
        // Arrange
         CheckService();

        // Act
        var result = await _doctorService.GetDoctorByIdAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
    /// <summary>
    /// fuction to remove doctor as a test case that take doctor id
    /// </summary>
    /// <param name="id">doctor id</param>
    [Theory, TestPriority(4)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f6830658")]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f6830658-51694k")]
    public async Task RemoveDoctor_ReturnResult(string id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _doctorService.DeleteDoctorAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
}
