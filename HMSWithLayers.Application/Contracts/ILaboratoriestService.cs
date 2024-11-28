using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface ILaboratoriestService : IApplicationService, IScopedService
{
    public Task<Result> AddLaboratoriestAsync(LaboratoriestRequestDto laboratoriestRequestDto);
    public Task<Result<List<LaboratoriestResponseDto>>> GetAllLaboratoriestsAsync();
    public Task<Result<LaboratoriestResponseDto>> GetLaboratoriestByIdAsync(string id);
    public Task<Result<LaboratoriestResponseDto>> UpdateLaboratoriestAsync(string id, LaboratoriestRequestDto laboratoriestRequestDto);
    public Task<Result> DeleteLaboratoriestAsync(string id);
}
