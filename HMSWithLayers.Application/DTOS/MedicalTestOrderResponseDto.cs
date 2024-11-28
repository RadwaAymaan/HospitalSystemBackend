using HMSWithLayers.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class MedicalTestOrderResponseDto
{
    public int Id { get; set; }
    public Status OrderStatus { get; set; }
    public DateTime OrderDate { get; set; }
    public string MedicalTestName { get; set; } = "";
    public string PatientName { get; set; } = "";
    public string DoctorName { get; set; } = "";
    public string LaboratoristName { get; set; } = "";
}
