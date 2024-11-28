using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class MedicalTestResultRequestDto
{
    [Required]
    public string ResultDescription { get; set; } = "";
    [Required]
    public int MedicalTestOrderId { get; set; }
    [Required]
    public string LaboratoristId { get; set; } = "";
}
