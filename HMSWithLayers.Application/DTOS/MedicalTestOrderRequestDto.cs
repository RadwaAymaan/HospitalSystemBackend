
using HMSWithLayers.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class MedicalTestOrderRequestDto
{
    [Required]
    public Status OrderStatus { get; set; }
    [Required]
    public int MedicalTestId { get; set; }
    [Required]
    public string PatientId { get; set; } = "";
    [Required]
    public string DoctorId { get; set; } = "";
    [Required]
    public string LaboratoristId { get; set; } = "";
}
