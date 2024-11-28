using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IMedicalTestResultService : IApplicationService, IScopedService
{
    Task<Result<List<MedicalTestResultResponseDto>>> GetAllMedicalTestResultsAsync();
    Task<Result<List<MedicalTestResultResponseDto>>> GetAllMedicalTestResultsByPatientIdAsync(string id);
    Task<Result<MedicalTestResultResponseDto>> GetMedicalTestResultByIdAsync(int id);
    Task<Result> AddMedicalTestResultAsync(MedicalTestResultRequestDto medicalTestResultRequestDto);
    Task<Result<MedicalTestResultResponseDto>> UpdateMedicalTestResultAsync(int id, MedicalTestResultRequestDto medicalTestResultRequestDto);
    Task<Result> DeleteMedicalTestResultAsync(int id);
}
