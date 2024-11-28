using HMSWithLayers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Domain.Entities;

public class Prescription : AuditableEntity
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.Now;
    public virtual ICollection<Medicine> Medicines { get; set; } = new HashSet<Medicine>();
    public string PatientId { get; set; } = "";
    public virtual Patient Patient { get; set; }
    public string DoctorId { get; set; } = "";
    public virtual Doctor Doctor { get; set; }
}
