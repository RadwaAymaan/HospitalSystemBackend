using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IMedicalTestService : IApplicationService, IScopedService
{
    Task<Result<List<LabResponseDto>>> GetAllLabsAsync();
    Task<Result<LabResponseDto>> GetLabByIdAsync(int id);
    Task<Result> AddLabAsync(LabRequestDto labRequestDtol);
    Task<Result<LabResponseDto>> UpdateLabAsync(int id, LabRequestDto labRequestDto);
    Task<Result> DeleteLabAsync(int id);
    Task<Result<List<ScanResponseDto>>> GetAllScansAsync();
    Task<Result<ScanResponseDto>> GetScanByIdAsync(int id);
    Task<Result> AddScanAsync(ScanRequestDto scanDto);
    Task<Result<ScanResponseDto>> UpdateScanAsync(int id, ScanRequestDto scanRequestDto);
    Task<Result> DeleteScanAsync(int id);
}
