using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class PrescriptionRequestDto
{
    [Required]
    public string Name { get; set; } = "";
    [Required]
    public string Description { get; set; } = "";
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public int MedicineId { get; set; }
    [Required]
    public string PatientId { get; set; }
    public string? DoctorId { get; set; }
}
