using HMSWithLayers.Core.Result;
using HMSWithLayers.Application.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IDoctorService : IApplicationService, IScopedService
{
    public Task<Result> AddDoctorAsync(DoctorRequestDto doctorRequestDto);
    public Task<Result<List<DoctorResponseDto>>> GetAllDoctorsAsync();
    public Task<Result<DoctorResponseDto>> GetDoctorByIdAsync(string id);
    public Task<Result<DoctorResponseDto>> UpdateDoctorAsycn(string id, DoctorRequestDto doctorRequestDto);
    public Task<Result> DeleteDoctorAsync(string id);
}
