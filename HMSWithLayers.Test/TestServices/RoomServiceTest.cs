﻿using AutoMapper;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.API.Mapping;
using HMSWithLayers.Application.Services;
using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Test.TestPriority;
using HMSWithLayers.Test.TestSetup;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMSWithLayers.Application.Contracts;

namespace HMSWithLayers.Test.TestServices;
[TestCaseOrderer(
ordererTypeName: "HMSWithLayers.Test.TestPriority.PriorityOrderer",
ordererAssemblyName: "HMSWithLayers.Test")]
public class RoomServiceTest
{
    private static RoomService _roomService;
    private string userEmail = "passant7@gmail.com";
    private RoomService CreateRoomService()
    {

        if (_roomService is null)
        {
            var dbContext = ContextGenerator.Generator();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();

            ILogger<RoomService> logger = new LoggerFactory().CreateLogger<RoomService>();

            IUserContextService userContext = new UserContextService();

            _roomService = new RoomService(dbContext, mapper, logger, userContext);
        }

        return _roomService;
    }
    private void CheckService()
    {
        if (_roomService is null)
            _roomService = CreateRoomService();
    }

    /// <summary>
    /// fuction to add room as a test case that take   room id , room number , room avaliability , roomtype id  
    /// </summary>
    /// <param name="roomNumber">room number</param>
    /// <param name="roomAvaliabitlity">room availability</param>
    /// <param name="roomTypeId">room Type id</param>
    [Theory, TestPriority(0)]
    [InlineData(10, true, 2)]
    public async Task Addroom(int  roomNumber , bool roomAvaliabitlity, int roomTypeId)
    {
    // Arrange
    CheckService();
        var roomRequestDto = new RoomRequestDto { RoomNumber = roomNumber, Availability = roomAvaliabitlity , RoomTypeId = roomTypeId };
        // Act
        var result = await _roomService.AddRoomAsync(roomRequestDto);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);
    }

    /// <summary>
    /// fuction to get all  rooms as a test case 
    /// </summary>
    [Fact, TestPriority(1)]
    public async Task GetAllRoom()
    {
        // Arrange
        CheckService();

        // Act
        var result = await _roomService.GetAllRoomsAsync();

        // Assert
        Assert.True(result.IsSuccess);

    }

    /// <summary>
    /// fuction to get room by id as a test case 
    /// </summary>
    /// <param name="id">room id </param>
    [Theory, TestPriority(2)]
    [InlineData(1)]
    [InlineData(6)]
    public async Task GetByIdRoom(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _roomService.GetRoomByIdAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }

     /// <summary>
    /// fuction to update room as a test case that take   room id , room number , room avaliability , roomtype id  
    /// </summary>
    /// <param name="roomNumber">room number</param>
    /// <param name="roomAvaliabitlity">room availability</param>
    /// <param name="roomTypeId">room Type id</param>
    /// <param name="expectedResult">expected result</param>
    [Theory, TestPriority(3)]
    [InlineData(1,1,false , 2, true)]
    [InlineData(1,10,false , 3, true)]
    public async Task UpdateRoom(int id,int roomNumber, bool roomAvaliabitlity, int roomTypeId, bool expectedResult)
    {
        //Arrange
        CheckService();
        var roomRequestDto = new RoomRequestDto { RoomNumber = roomNumber, Availability = roomAvaliabitlity, RoomTypeId = roomTypeId };
        
        // Act
        var result = await _roomService.UpdateRoomAsycn(id, roomRequestDto);
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
    /// fuction to remove room as a test case that take room id
    /// </summary>
    /// <param name="id">room id </param>
    [Theory, TestPriority(4)]
    [InlineData(2)]
    [InlineData(50)]
    public async Task Removeroom(int id)
    {
        // Arrange
        CheckService();

        // Act
        var result = await _roomService.DeleteRoomAsync(id);

        // Assert
        if (result.IsSuccess)
            Assert.True(result.IsSuccess);
        else
            Assert.False(result.IsSuccess);

    }
}
