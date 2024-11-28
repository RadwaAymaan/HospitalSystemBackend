using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IMedicalTestOrderService : IApplicationService, IScopedService
{
    Task<Result<List<MedicalTestOrderResponseDto>>> GetAllMedicalTestOrdersAsync();
    Task<Result<List<MedicalTestOrderResponseDto>>> GetAllMedicalTestOrdersByPatientIdAsync(string id);
    Task<Result<MedicalTestOrderResponseDto>> GetMedicalTestOrderByIdAsync(int id);
    Task<Result> AddMedicalTestOrderAsync(MedicalTestOrderRequestDto medicalTestOrderDto);
    Task<Result<MedicalTestOrderResponseDto>> UpdateMedicalTestOrderAsync(int id, MedicalTestOrderRequestDto medicalTestOrderDto);
    Task<Result> DeleteMedicalTestOrderAsync(int id);
}
