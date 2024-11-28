using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class PrescriptionWithoutRelationResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.Now;
    public string PatientName { get; set; } = "";
    public string DoctorName { get; set; } = "";

}
