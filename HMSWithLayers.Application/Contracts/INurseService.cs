using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface INurseService : IApplicationService, IScopedService
{
    public Task<Result> AddNurseAsync(NurseRequestDto nurseRequestDto);
    public Task<Result<List<NurseGetAllResponseDto>>> GetAllNurseAsync();
    public Task<Result<NurseResponseDto>> GetNurseByIdAsync(string id);
    public Task<Result<NurseResponseDto>> UpdateNurseAsync(string id, NurseRequestDto nurseRequestDto);
    public Task<Result> DeleteNurseAsync(string id);
}
