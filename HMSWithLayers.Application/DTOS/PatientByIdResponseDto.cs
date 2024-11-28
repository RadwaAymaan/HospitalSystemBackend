using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class PatientByIdResponseDto
{
    public string Id { get; set; } = "";
    public string PatientFirstName { get; set; } = "";
    public string PatientLastName { get; set; } = "";
    public string PatientEmail { get; set; } = "";
    public string PatientPhoneNumber { get; set; } = "";
    public int? RoomNumber { get; set; }
}
