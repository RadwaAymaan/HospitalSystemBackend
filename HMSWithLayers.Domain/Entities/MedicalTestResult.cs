using HMSWithLayers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Domain.Entities;

public class MedicalTestResult : AuditableEntity
{
    public string ResultDescription { get; set; } = "";
    public DateTime ResultDate { get; set; } = DateTime.Now;
    public int MedicalTestOrderId { get; set; }
    public string LaboratoristId { get; set; }
    public virtual MedicalTestOrder MedicalTestOrder { get; set; }
    public virtual Laboratorist Laboratorist { get; set; }
}