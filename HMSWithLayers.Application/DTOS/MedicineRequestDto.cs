using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class MedicineRequestDto
{
    [Required]
    public string MedicineName { get; set; } = "";
    [Required]
    public string MedicineDescription { get; set; } = "";
    [Required]
    [Range(1, int.MaxValue)]
    public int MedicineDosage { get; set; }
}
