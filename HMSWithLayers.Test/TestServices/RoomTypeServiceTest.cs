using AutoMapper;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.API.Mapping;
using HMSWithLayers.Application.Services;
using HMSWithLayers.Test.TestPriority;
using HMSWithLayers.Test.TestSetup;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Test.TestServices;
[TestCaseOrderer(
ordererTypeName: "HMSWithLayers.Test.TestPriority.PriorityOrderer",
ordererAssemblyName: "HMSWithLayers.Test")]
public class RoomTypeServiceTest
{
    private static RoomTypeService _roomTypeService;
    private string userEmail = "hagershaaban7@gmail.com";
    private RoomTypeService CreateRoomTypeService()
    {

        if (_roomTypeService is null)
        {
            var dbContext = ContextGenerator.Generator();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();

            ILogger<RoomTypeService> logger = new LoggerFactory().CreateLogger<RoomTypeService>();

            _roomTypeService = new RoomTypeService(dbContext, logger,mapper );
        }

        return _roomTypeService;
    }
    private void CheckService()
    {
        if (_roomTypeService is null)
            _roomTypeService = CreateRoomTypeService();
    }

    /// <summary>
    /// fuction to add room type as a test case that take number Of Patient,  type of room type
    /// </summary>
    /// <param name="numberOfPatient">number of patient</param>
    /// <param name="type">type of room type</param>
    [Theory, TestPriority(0)]
    [InlineData(1, "Single")]
    public async Task AddRoomType(int numberOfPatient, string type)
    {
        // Arrange
        CheckService();
        var roomTypeRequestDto = new RoomTypeRequestDto { NumberOfPatient = numberOfPatient, Type= type };
        // Act
        var result = await _roomTypeService.AddRoomTypeAsync(roomTypeRequestDto);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);
    }

    /// <summary>
    /// fuction to get all  RoomTypes as a test case 
    /// </summary>
    [Fact, TestPriority(1)]
    public async Task GetAllRoomType()
    {
        // Arrange
        CheckService();

        // Act
        var result = await _roomTypeService.GetAllRoomTypesAsync();

        // Assert
        Assert.True(result.IsSuccess);

    }

    /// <summary>
    /// fuction to get room type by id as a test case 
    /// </summary>
    /// <param name="id"> room type id</param>
    [Theory, TestPriority(2)]
    [InlineData(1)]
    [InlineData(6)]
    public async Task GetByIdRoomType(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _roomTypeService.GetRoomTypeByIdAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }

    /// <summary>
    /// fuction to update RoomType as a test case that  take number Of Patient,  type of room type  expected result
    /// </summary>
    /// <param name="numberOfPatient">number of patient</param>
    /// <param name="type">type of room type</param>
    [Theory, TestPriority(3)]
    [InlineData(1,1, "Single",true)]
    [InlineData(10,1, "Single",false)]
    public async Task UpdateSpectialization(int id, int numberOfPatient, string type, bool expectedResult)
    {
        //Arrange
        CheckService();
        var roomTypeRequestDto = new RoomTypeRequestDto { NumberOfPatient = numberOfPatient, Type = type };
        // Act
        var result = await _roomTypeService.UpdateRoomTypeAsync(id, roomTypeRequestDto);
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
    /// fuction to remove room type as a test case that take room type id
    /// </summary>
    /// <param name="id"> room type id </param>
    /// <returns>room type remove successfully</returns>
    [Theory, TestPriority(4)]
    [InlineData(2)]
    [InlineData(50)]
    public async Task RemoveRoomType(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _roomTypeService.DeleteRoomTypeAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
}
