using HMSWithLayers.Core.Result;
using HMSWithLayers.Application.DTOS;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HMSWithLayers.Domain.Entities;

namespace HMSWithLayers.Application.Contracts;

public interface IAuthService: IApplicationService, IScopedService
{
    Task<Result<LoginResponseDto>> Login(LoginRequestDto LoginRequestDto);
    Task<Result> RegisterPatientAsync(PatientRequestDto patientDto);
    Task<Result> RegisterDoctorAsync(DoctorRequestDto doctorDto);
    Task<Result> RegisterPharmacistAsync(PharmacistRequestDto pharmacistDto);
    Task<Result> RegisterLaboratoristAsync(LaboratoriestRequestDto laboratoristDto);
    Task<Result> RegisterNurseAsync(NurseRequestDto nurseDto);
    Task<Result> RegisterEmployeeAsync(EmployeeRequestDto employeeDto);
    Task<Result> AddUserToRoleAsync(string userId, string roleName);
    Task InitializeRoles();
    Task CreateAdminAccount();
}
