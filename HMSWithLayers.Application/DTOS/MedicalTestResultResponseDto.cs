using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class MedicalTestResultResponseDto
{
    public int Id { get; set; }
    public string ResultDescription { get; set; } = "";
    public DateTime ResultDate { get; set; }
    public MedicalTestOrderResponseDto MedicalTestOrder { get; set; }
    public string LaboratoristName { get; set; } = "";
}
