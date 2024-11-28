using HMSWithLayers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Domain.Entities;

public class MedicalHistory : AuditableEntity
{
    public string Details { get; set; } = "";
    public string PatientId { get; set; }
    public virtual Patient Patient { get; set; }
}
