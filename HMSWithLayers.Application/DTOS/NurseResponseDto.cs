using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class NurseResponseDto
{
    public string Id { get; set; } = "";
    public string NurseEmail { get; set; } = "";
    public string NurseFirstName { get; set; } = "";
    public string NurseLastName { get; set; } = "";
    public string NursePhoneNumber { get; set; } = "";
    public string UserName { get; set; } = "";
    public SpecializationResponseDto Specialization { get; set; }

}
