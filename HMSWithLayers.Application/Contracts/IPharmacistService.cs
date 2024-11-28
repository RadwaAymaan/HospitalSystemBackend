using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IPharmacistService : IApplicationService, IScopedService
{
    public Task<Result> AddPharmacistAsync(PharmacistRequestDto pharmacistRequestDto);
    public Task<Result<List<PharmacistResponseDto>>> GetAllPharmacistsAsync();
    public Task<Result<PharmacistResponseDto>> GetPharmacistByIdAsync(string id);
    public Task<Result<PharmacistResponseDto>> UpdatePharmacistAsycn(string id, PharmacistRequestDto pharmacistRequestDto);
    public Task<Result> DeletePharmacistAsync(string id);
}
