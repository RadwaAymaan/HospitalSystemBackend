using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class MedicineWithoutRelationResponseDto
{
    public int Id { get; set; }
    public string MedicineName { get; set; } = "";
    public string MedicineDescription { get; set; } = "";
    public int MedicineDosage { get; set; }
}
