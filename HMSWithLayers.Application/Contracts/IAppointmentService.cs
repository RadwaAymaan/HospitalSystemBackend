using HMSWithLayers.Core.Result;
using HMSWithLayers.Application.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IAppointmentService: IApplicationService,IScopedService
{
    Task<Result> AddAppointmentAsync(AppointmentRequestDto appointmentRequestDto);
    Task<Result> DeleteAppointmentAsync(int id);
    Task<Result<AppointmentResponseDto>> GetAppointmentByIdAsync(int id);
    Task<Result<List<AppointmentResponseDto>>> GetAllAppointmentAsync();
    Task<Result<AppointmentResponseDto>> UpdateAppointmentAsync(int id, AppointmentRequestDto appointmentRequestDto);
    Task<Result<List<AppointmentResponseDto>>> GetAllAppointmentForSpecificDoctor(string doctorId);
    Task<Result<List<AppointmentResponseDto>>> GetAllAppointmentForSpecificPatient(string patientId);
}
