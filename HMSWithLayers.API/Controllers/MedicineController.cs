using HMSWithLayers.Application.Contracts;
using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace HMSWithLayers.API.Controllers;
public class MedicineController(IMedicineService medicineService) : BaseController
{
    private readonly IMedicineService _medicineService = medicineService;

    /// <summary>
    /// action for add medicine that take medicine dto   
    /// </summary>
    /// <param name="medicineDto">medicine dto</param>
    /// <returns>result of medicine added successfully</returns>
    [HttpPost]
    [Authorize(Roles = "Admin,Pharmacist")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> AddMedicine(MedicineRequestDto medicineDto)
    {
        
        return await _medicineService.AddMedicineAsync(medicineDto);

    }

    /// <summary>
    /// action for get all medicines  
    /// </summary>
    /// <returns>result of list from medicine response dto </returns>
    [HttpGet]
    [Authorize(Roles = "Admin,Pharmacist,Doctor")]
    [ProducesResponseType(typeof(Result<List<MedicineResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<List<MedicineResponseDto>>> GetAllMedicine()
    {
        return await _medicineService.GetAllMedicinesAsync();
    }

    /// <summary>
    /// action for get by id medicine  that take  medicine id
    /// </summary>
    /// <param name="id">medicine id</param>
    /// <returns>result of medicine response dto </returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Pharmacist,Doctor")]
    [ProducesResponseType(typeof(Result<MedicineResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<MedicineResponseDto>> GetMedicineById(int id)
    {
        return await _medicineService.GetMedicineByIdAsync(id);
    }
    /// <summary>
    /// action for update medicine by id that take  medicine id and medicine dto
    /// </summary>
    /// <param name="id">medicine id</param>
    /// <param name="medicineDto">medicine dto</param>
    /// <returns>result of medicine response dto after updated</returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Pharmacist")]
    [ProducesResponseType(typeof(Result<MedicineResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result<MedicineResponseDto>> UpdateDoctor(int id, MedicineRequestDto medicineDto)
    {
        return await _medicineService.UpdateMedicineAsycn(id, medicineDto);
    }
    /// <summary>
    /// action for remove  medicine by id that take medicine id 
    /// </summary>
    /// <param name="id">medicine id</param>
    /// <returns>result of medicine remove successfully</returns>
    [HttpDelete]
    [Authorize(Roles = "Admin,Pharmacist")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<Result> DeleteMedicine(int id)
    {
        return await _medicineService.DeleteMedicineAsync(id);
    }
}
