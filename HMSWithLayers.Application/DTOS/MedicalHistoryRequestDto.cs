using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class MedicalHistoryRequestDto
{
    [Required]
    public string Details { get; set; } = "";
    [Required]
    public string PatientId { get; set; }
}
