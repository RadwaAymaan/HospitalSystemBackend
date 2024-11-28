using HMSWithLayers.Application.DTOS;
using HMSWithLayers.API.Mapping;
using HMSWithLayers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.API.ExtensionMethods;

public static class StaffMapping
{
    public static void AddStaffMapping(this MappingProfiles map)
    {
        //mapping of specialization 
        map.CreateMap<SpecializationRequestDto, Specialization>().ReverseMap();
        map.CreateMap<SpecializationResponseDto, Specialization>().ReverseMap();
        //mapping of employee 
        map.CreateMap<EmployeeRequestDto, Employee>()
           .ForMember(d => d.Email, o => o.MapFrom(s => s.EmployeeEmail))
           .ForMember(d => d.FirstName, o => o.MapFrom(s => s.EmployeeFirstName))
           .ForMember(d => d.LastName, o => o.MapFrom(s => s.EmployeeLastName))
           .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.EmployeePhoneNumber)).ReverseMap();
        map.CreateMap<Employee,EmployeeResponseDto>()
           .ForMember(d => d.EmployeeFirstName, o => o.MapFrom(s => s.FirstName))
           .ForMember(d => d.EmployeeEmail, o => o.MapFrom(s => s.Email))
           .ForMember(d => d.EmployeeLastName, o => o.MapFrom(s => s.LastName))
           .ForMember(d => d.EmployeePhoneNumber, o => o.MapFrom(s => s.PhoneNumber));
        //mapping of doctor 
        map.CreateMap<DoctorRequestDto, Doctor>()
           .ForMember(d => d.Email, o => o.MapFrom(s => s.DoctorEmail))
           .ForMember(d => d.FirstName, o => o.MapFrom(s => s.DoctorFirstName))
           .ForMember(d => d.LastName, o => o.MapFrom(s => s.DoctorLastName))
           .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.DoctorPhoneNumber));
        map.CreateMap<Doctor, DoctorResponseDto>()
           .ForMember(d => d.DoctorFirstName, o => o.MapFrom(s => s.FirstName))
           .ForMember(d => d.DoctorEmail, o => o.MapFrom(s => s.Email))
           .ForMember(d => d.DoctorLastName, o => o.MapFrom(s => s.LastName))
           .ForMember(d => d.DoctorPhoneNumber, o => o.MapFrom(s => s.PhoneNumber));
        //mapping of pharmacist 
        map.CreateMap<PharmacistRequestDto, Pharmacist>()
           .ForMember(d => d.Email, o => o.MapFrom(s => s.PharmacistEmail))
           .ForMember(d => d.FirstName, o => o.MapFrom(s => s.PharmacistFirstName))
           .ForMember(d => d.LastName, o => o.MapFrom(s => s.PharmacistLastName))
           .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.PharmacistPhoneNumber));
        map.CreateMap<Pharmacist, PharmacistResponseDto>()
           .ForMember(d => d.PharmacistFirstName, o => o.MapFrom(s => s.FirstName))
           .ForMember(d => d.PharmacistEmail, o => o.MapFrom(s => s.Email))
           .ForMember(d => d.PharmacistLastName, o => o.MapFrom(s => s.LastName))
           .ForMember(d => d.PharmacistPhoneNumber, o => o.MapFrom(s => s.PhoneNumber));
        //mapping of laboratorist 
        map.CreateMap<LaboratoriestRequestDto, Laboratorist>()
           .ForMember(D => D.Email, O => O.MapFrom(S => S.LaboratoriestEmail))
           .ForMember(D => D.FirstName, O => O.MapFrom(S => S.LaboratoriestFirstName))
           .ForMember(D => D.LastName, O => O.MapFrom(S => S.LaboratoriestLastName))
           .ForMember(D => D.PhoneNumber, O => O.MapFrom(S => S.LaboratoriestPhoneNumber))
           .ForMember(D => D.UserName, O => O.MapFrom(S => S.UserName))
           .ForMember(D => D.PasswordHash, O => O.MapFrom(S => S.Password))
           .ReverseMap();
        map.CreateMap<LaboratoriestResponseDto, Laboratorist>()
           .ForMember(D => D.Email, O => O.MapFrom(S => S.LaboratoriestEmail))
           .ForMember(D => D.FirstName, O => O.MapFrom(S => S.LaboratoriestFirstName))
           .ForMember(D => D.LastName, O => O.MapFrom(S => S.LaboratoriestLastName))
           .ForMember(D => D.PhoneNumber, O => O.MapFrom(S => S.LaboratoriestPhoneNumber))
           .ForMember(D => D.UserName, O => O.MapFrom(S => S.LaboratoriestUserName))
           .ReverseMap();
        //mapping of nurse 
        map.CreateMap<NurseRequestDto, Nurse>()
           .ForMember(D => D.Email, O => O.MapFrom(S => S.NurseEmail))
           .ForMember(D => D.FirstName, O => O.MapFrom(S => S.NurseFirstName))
           .ForMember(D => D.LastName, O => O.MapFrom(S => S.NurseLastName))
           .ForMember(D => D.PhoneNumber, O => O.MapFrom(S => S.NursePhoneNumber))
           .ForMember(D => D.PasswordHash, O => O.MapFrom(S => S.Password))
           .ReverseMap();
        map.CreateMap<Nurse, NurseResponseDto>()
           .ForMember(D => D.NurseEmail, O => O.MapFrom(S => S.Email))
           .ForMember(D => D.NurseFirstName, O => O.MapFrom(S => S.FirstName))
           .ForMember(D => D.NurseLastName, O => O.MapFrom(S => S.LastName))
           .ForMember(D => D.NursePhoneNumber, O => O.MapFrom(S => S.PhoneNumber))
           //.ForMember(dest => dest.SpecializationName, O => O.MapFrom(S => S.Specialization.SpecializationName))
           .ReverseMap();
        map.CreateMap<Nurse, NurseGetAllResponseDto>()
           .ForMember(D => D.NurseFirstName, O => O.MapFrom(S => S.FirstName))
           .ForMember(D => D.NurseLastName, O => O.MapFrom(S => S.LastName))
           .ForMember(D => D.NurseEmail, O => O.MapFrom(S => S.Email))
           .ForMember(D => D.NursePhoneNumber, O => O.MapFrom(S => S.PhoneNumber))
           .ForMember(dest => dest.SpecializationName, O => O.MapFrom(S => S.Specialization.SpecializationName))
           .ReverseMap();
        //mapping of patient
        map.CreateMap<PatientGetAllResponseDto, Patient>()
           .ForMember(D => D.FirstName, O => O.MapFrom(S => S.PatientFirstName))
           .ForMember(D => D.LastName, O => O.MapFrom(S => S.PatientLastName))
           .ForMember(D => D.Email, O => O.MapFrom(S => S.PatientEmail))
           .ForMember(D => D.PhoneNumber, O => O.MapFrom(S => S.PatientPhoneNumber))
           .ReverseMap();
        map.CreateMap<PatientByIdResponseDto, Patient>()
           .ForMember(D => D.FirstName, O => O.MapFrom(S => S.PatientFirstName))
           .ForMember(D => D.LastName, O => O.MapFrom(S => S.PatientLastName))
           .ForMember(D => D.Email, O => O.MapFrom(S => S.PatientEmail))
           .ForMember(D => D.PhoneNumber, O => O.MapFrom(S => S.PatientPhoneNumber))
           .ForPath(D => D.Room.RoomNumber, O => O.MapFrom(S => S.RoomNumber))
           .ReverseMap();
        map.CreateMap<PatientRequestDto, Patient>()
           .ForMember(D => D.FirstName, O => O.MapFrom(S => S.PatientFirstName))
           .ForMember(D => D.LastName, O => O.MapFrom(S => S.PatientLastName))
           .ForMember(D => D.Email, O => O.MapFrom(S => S.PatientEmail))
           .ForMember(D => D.PhoneNumber, O => O.MapFrom(S => S.PatientPhoneNumber))
           .ReverseMap();
        //mapping of room type
        map.CreateMap<RoomTypeRequestDto, RoomType>();
        map.CreateMap<RoomType, RoomTypeResponseDto>().ReverseMap();
        //mapping  of room
        map.CreateMap<RoomRequestDto, Room>();
        map.CreateMap<Room, RoomGetAllResponseDto>();
        map.CreateMap<Room, RoomResponseDto>();
        //mapping of medicine
        map.CreateMap<MedicineRequestDto, Medicine>();
        map.CreateMap<Medicine, MedicineWithoutRelationResponseDto>();
        map.CreateMap<Medicine, MedicineResponseDto>();
        //mapping of inventory
        map.CreateMap<InventoryRequestDto, Inventory>().ReverseMap();
        map.CreateMap<InventoryResponseDto, Inventory>()
                   .ForMember(dest => dest.Categories, O => O.MapFrom(S => S.Categories))
                   .ReverseMap();


    }
}
