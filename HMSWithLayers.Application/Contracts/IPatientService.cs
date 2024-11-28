using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IPatientService : IApplicationService, IScopedService
{
    public Task<Result<List<PatientGetAllResponseDto>>> GetAllPatientsAsync();
    public Task<Result<PatientByIdResponseDto>> GetPatientByIdAsync(string id);
    public Task<Result<PatientByIdResponseDto>> UpdatePatientAsync(string id, PatientRequestDto patientRequestDto);
    public Task<Result> DeletePatientAsync(string id);
}
