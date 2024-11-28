using HMSWithLayers.Core.Entities;
using HMSWithLayers.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Domain.Entities;

public class MedicalTestOrder : AuditableEntity
{
    public Status OrderStatus { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public int MedicalTestId { get; set; }
    public string PatientId { get; set; }
    public string? DoctorId { get; set; }
    public string LaboratoristId { get; set; }
    public virtual MedicalTest MedicalTest { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual Doctor? Doctor { get; set; }
    public virtual Laboratorist Laboratorist { get; set; }
    public  virtual MedicalTestResult MedicalTestResult { get; set; }
}