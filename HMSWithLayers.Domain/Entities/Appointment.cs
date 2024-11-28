using HMSWithLayers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Domain.Entities;

public class Appointment : AuditableEntity
{
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public DateOnly Date { get; set; }
    public string PatientId { get; set; }
    public virtual Patient Patient { get; set; }
    public string DoctorId { get; set; }
    public virtual Doctor Doctor { get; set; }
}
