using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class MedicineResponseDto
{
    public int Id { get; set; }
    public string MedicineName { get; set; } = "";
    public string MedicineDescription { get; set; } = "";
    public int MedicineDosage { get; set; }
    public virtual ICollection<PrescriptionWithoutRelationResponseDto> Prescriptions { get; set; } = new HashSet<PrescriptionWithoutRelationResponseDto>();

}
