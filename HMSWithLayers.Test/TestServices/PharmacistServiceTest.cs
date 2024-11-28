using AutoMapper;
using HMSWithLayers.API.Mapping;
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
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.JWT;
using Microsoft.Extensions.Options;

namespace HMSWithLayers.Test.TestServices;
[TestCaseOrderer(
ordererTypeName: "HMSWithLayers.Test.TestPriority.PriorityOrderer",
ordererAssemblyName: "HMSWithLayers.Test")]
public class PharmacistServiceTest
{
    private static PharmacistService _pharmacistService;
    private List<ApplicationUser> _users = new List<ApplicationUser>
        {
            new ApplicationUser() { Id = "53ae72a7-589e-4f0b-81ed-403896568",FirstName="Hager" },
            new ApplicationUser() { Id = "53ae72a7-589e-4f0b-81ed-40381265451",FirstName="Hager" }
        };
    private PharmacistService CreatePharmacistService()
    {

        if (_pharmacistService is null)
        {
            var dbContext = ContextGenerator.Generator();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();
            ILogger<PharmacistService> PharmacistLogger = new LoggerFactory().CreateLogger<PharmacistService>();
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
            
            _pharmacistService = new PharmacistService(dbContext, mapper, PharmacistLogger, authService);
        }

        return _pharmacistService;
    }

    private void CheckService()
    {
        if (_pharmacistService is null)
            _pharmacistService = CreatePharmacistService();
    }
    /// <summary>
    /// fuction to update pharmacist as a test case .
    /// </summary>
    /// <param name="PharmacistEmail">pharmacist email</param>
    /// <param name="PharmacistFirstName">pharmacist first name</param>
    /// <param name="PharmacistLastName">pharmacist last name</param> 
    /// <param name="PharmacistPhoneNumber">pharmacist phone number</param>
    /// <param name="Gender">pharmacist gender</param>
    /// <param name="id">pharmacist id</param>
    /// <param name="Password">pharmacist password</param>
    /// <param name="UserName">pharmacist user name</param>
    /// <param name="expectedResult">expected result</param>
    [Theory, TestPriority(3)]
    [InlineData("53ae72a7-589e-4f0b-81ed-403896568", "nejosif605@hisotyr.com", "Hager", "shaaban", "01065695783", "nejosif605", "0167519Kh!", "Female", true)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f683027-6514984", "nejosif605@hisotyr.com", "Hager", "shaaban", "01065695783", "nejosif605", "0167519Kh!", "Female", false)]
    public async Task UpdatePharmacistAsync(string id, string PharmacistEmail, string PharmacistFirstName, string PharmacistLastName, string PharmacistPhoneNumber, string UserName, string Password, string Gender, bool expectedResult)
    {
        //Arrange
        CheckService();
        var PharmacistRequestDto = new PharmacistRequestDto
        {
            PharmacistEmail = PharmacistEmail,
            PharmacistFirstName = PharmacistFirstName,
            PharmacistLastName = PharmacistLastName,
            PharmacistPhoneNumber = PharmacistPhoneNumber,
            UserName = UserName,
            Password = Password,
        };
        // Act
        var result = await _pharmacistService.UpdatePharmacistAsycn(id, PharmacistRequestDto);
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
    /// fuction to get all  pharmacist as a test case 
    /// </summary>
    [Fact, TestPriority(1)]
    public async Task GetAllPharmacist()
    {
        // Arrange
        CheckService();

        // Act
        var result = await _pharmacistService.GetAllPharmacistsAsync();

        // Assert
        Assert.True(result.IsSuccess);

    }
    /// <summary>
    /// fuction to get pharmacist by id as a test case that take pharmacist id
    /// </summary>
    /// <param name="id"> pharmacist id</param>
    [Theory, TestPriority(2)]
    [InlineData("53ae72a7-589e-4f0b-81ed-403896568")]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f68302765165")]
    public async Task GetByIdPharmacist_ReturnResult(string id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _pharmacistService.GetPharmacistByIdAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
    /// <summary>
    /// fuction to remove pharmacist as a test case that take pharmacist id
    /// </summary>
    /// <param name="id">pharmacist id</param>
    [Theory, TestPriority(4)]
    [InlineData("53ae72a7-589e-4f0b-81ed-40381265451")]
    [InlineData("53ae72a7-589e-4f0b-81ed-40389f6830658-51694k")]
    public async Task RemovePharmacist_ReturnResult(string id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _pharmacistService.DeletePharmacistAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
}
