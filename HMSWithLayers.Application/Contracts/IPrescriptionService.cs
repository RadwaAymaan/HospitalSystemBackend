using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IPrescriptionService : IApplicationService, IScopedService
{
    public Task<Result<List<PrescriptionResponseDto>>> GetAllPrescriptionsAsync();
    public Task<Result<PrescriptionResponseDto>> GetPrescriptionByIdAsync(int id);
    public Task<Result> AddPrescriptionAsync(PrescriptionRequestDto prescriptionRequestDto);
    public Task<Result<PrescriptionResponseDto>> UpdatePrescriptionAsync(int id, PrescriptionRequestDto prescriptionRequestDto );
    public Task<Result> DeletePrescriptionAsync(int id);
}
