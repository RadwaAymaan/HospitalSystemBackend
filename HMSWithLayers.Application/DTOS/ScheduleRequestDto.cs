using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class ScheduleRequestDto
{
    [Required]
    public string DoctorId { get; set; } = "";
    [Required]
    public int TimeSlotId { get; set; }
}
