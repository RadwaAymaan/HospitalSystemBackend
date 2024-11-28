using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class MedicalHistoryResponseDto
{
    public int Id { get; set; }
    public string Details { get; set; } = "";
    public PatientGetAllResponseDto Patient { get; set; }
}
