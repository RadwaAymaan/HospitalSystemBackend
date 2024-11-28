using HMSWithLayers.Application.DTOS;
using HMSWithLayers.API.Mapping;
using HMSWithLayers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.API.ExtensionMethods;

public static class OperationMapping
{
    public static void AddOperationMapping(this MappingProfiles map)
    {
        //mapping of lab
        map.CreateMap<LabRequestDto, Lab>();
        map.CreateMap<Lab, LabResponseDto>();
        map.CreateMap<LabRequestDto, MedicalTest>();
        map.CreateMap<MedicalTest,LabResponseDto>();
        //mapping of scan
        map.CreateMap<ScanRequestDto, Scan>();
        map.CreateMap<ScanRequestDto, MedicalTest>();
        map.CreateMap<MedicalTest, ScanResponseDto>();
        map.CreateMap<Scan, ScanResponseDto>();
        //mapping of medical test order
        map.CreateMap<MedicalTestOrderRequestDto, MedicalTestOrder>();
        map.CreateMap<MedicalTestOrder, MedicalTestOrderResponseDto>()
           .ForMember(D => D.DoctorName, O => O.MapFrom(S => $"{S.Doctor.FirstName} {S.Doctor.LastName}"))
           .ForMember(D => D.PatientName, O => O.MapFrom(S => $"{S.Patient.FirstName} {S.Patient.LastName}"))
           .ForMember(D => D.LaboratoristName, O => O.MapFrom(S => $"{S.Laboratorist.FirstName} {S.Laboratorist.LastName}"));
        //mapping of medical test result
        map.CreateMap<MedicalTestResultRequestDto, MedicalTestResult>();
        map.CreateMap<MedicalTestResult, MedicalTestResultResponseDto>()
           .ForMember(D => D.LaboratoristName, O => O.MapFrom(S => $"{S.Laboratorist.FirstName} {S.Laboratorist.LastName}"));
        //mapping of medical history
        map.CreateMap<MedicalHistoryRequestDto, MedicalHistory>();
        map.CreateMap<MedicalHistory, MedicalHistoryResponseDto>();
        //mapping of prescription
        map.CreateMap<PrescriptionRequestDto, Prescription>();
        map.CreateMap<Prescription, PrescriptionWithoutRelationResponseDto>()
        .ForMember(dest => dest.DoctorName, src => src.MapFrom(src => src.Doctor.FirstName + " " + src.Doctor.LastName))
        .ForMember(dest => dest.PatientName, src => src.MapFrom(src => src.Patient.FirstName + " " + src.Patient.LastName));
        map.CreateMap<Prescription, PrescriptionResponseDto>()
         .ForMember(dest => dest.DoctorName, src => src.MapFrom(src => src.Doctor.FirstName + " " + src.Doctor.LastName))
         .ForMember(dest => dest.PatientName, src => src.MapFrom(src => src.Patient.FirstName + " " + src.Patient.LastName));
        //mapping of item
        map.CreateMap<ItemRequestDto, Item>();
        map.CreateMap<Item, ItemResponseDto>();
        //mapping of item category
        map.CreateMap<ItemCategoryRequestDto, ItemCategory>().ReverseMap();
        map.CreateMap<ItemCategory, ItemCategoryResponseDto>().ReverseMap();
        //mapping of order
        map.CreateMap<OrderRequestDto, Order>();
        map.CreateMap<Order, OrderResponseDto>();
        //mapping of item order
        map.CreateMap<ItemOrderRequestDto, ItemOrder>().ReverseMap();
        map.CreateMap<ItemOrder, ItemOrderResponseDto>();
        //mapping of appointment
        map.CreateMap<AppointmentRequestDto, Appointment>();
        map.CreateMap<Appointment, AppointmentResponseDto>()
            .ForMember(dest => dest.PatientName, src => src.MapFrom(src => src.Patient.FirstName + " " + src.Patient.LastName))
            .ForMember(dest => dest.DoctorName, src => src.MapFrom(src => src.Doctor.FirstName + " " + src.Doctor.LastName));
        //mapping of time slot
        map.CreateMap<TimeSlotRequestDto, TimeSlot>().ReverseMap();
        map.CreateMap<TimeSlot, TimeSlotResponseDto>().ReverseMap();
        //mapping of schedule
        map.CreateMap<ScheduleRequestDto, Schedule>().ReverseMap();
        map.CreateMap<Schedule, ScheduleResponseDto>().ReverseMap();
        //mapping of department
        map.CreateMap<DepartmentRequestDto, Department>().ReverseMap();
        map.CreateMap<Department, DepartmentResponseDto>().ReverseMap();

        map.CreateMap<ApplicationUser, LoginResponseDto>()
            .ForMember(dest => dest.FullName, src => src.MapFrom(src => src.FirstName + " " + src.LastName));







    }
}
