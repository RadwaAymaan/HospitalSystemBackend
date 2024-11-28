using AutoMapper;
using HMSWithLayers.API.ExtensionMethods;
using System.Security.Claims;

namespace HMSWithLayers.API.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {

        this.AddStaffMapping();

        this.AddOperationMapping();
    }
}
