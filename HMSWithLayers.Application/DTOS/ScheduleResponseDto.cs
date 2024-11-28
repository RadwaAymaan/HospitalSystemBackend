using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class ScheduleResponseDto
{
    public int Id { get; set; }
    public string DoctorId { get; set; } = "";
    public TimeSlotResponseDto TimeSlot { get; set; }
}
