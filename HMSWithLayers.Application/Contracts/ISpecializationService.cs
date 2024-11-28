using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface ISpecializationService : IApplicationService, IScopedService
{
    public Task<Result> AddSpectializationAsync(SpecializationRequestDto specializationRequestDto);
    public Task<Result<List<SpecializationResponseDto>>> GetAllSpecializationsAsync();
    public Task<Result<SpecializationResponseDto>> GetSpecializationByIdAsync(int id);
    public Task<Result<SpecializationResponseDto>> UpdateSpecializationAsycn(int id, SpecializationRequestDto specializationRequestDto);
    public Task<Result> DeleteSpecializationAsync(int id);
}
