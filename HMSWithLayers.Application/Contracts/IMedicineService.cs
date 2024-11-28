using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IMedicineService:IApplicationService,IScopedService
{
    public Task<Result> AddMedicineAsync(MedicineRequestDto medicineRequestDto);
    public Task<Result<List<MedicineResponseDto>>> GetAllMedicinesAsync();
    public Task<Result<MedicineResponseDto>> GetMedicineByIdAsync(int id);
    public Task<Result<MedicineResponseDto>> UpdateMedicineAsycn(int id, MedicineRequestDto medicineRequestDto);
    public Task<Result> DeleteMedicineAsync(int id);
}
