using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IMedicalHistoryService : IApplicationService, IScopedService
{
    Task<Result<List<MedicalHistoryResponseDto>>> GetMedicalHistoryByPatientId(string patientId);
    Task<Result<MedicalHistoryResponseDto>> GetMedicalHistoryeById(int id);
    Task<Result> AddMedicalHistoryAsync(MedicalHistoryRequestDto medicalHistoryRequestDto);
    Task<Result<MedicalHistoryResponseDto>> UpdateMedicalHistory(int id, MedicalHistoryRequestDto medicalHistoryRequestDto);
    Task<Result> DeleteMedicalHistory(int id);
}
