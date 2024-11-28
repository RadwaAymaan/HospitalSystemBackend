using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class DoctorResponseDto
{
    public string Id { get; set; } = "";
    public string DoctorEmail { get; set; } = "";
    public string DoctorFirstName { get; set; } = "";
    public string DoctorLastName { get; set; } = "";
    public string DoctorPhoneNumber { get; set; } = "";
    public string UserName { get; set; } = "";
    public SpecializationResponseDto Specialization { get; set; }
}
