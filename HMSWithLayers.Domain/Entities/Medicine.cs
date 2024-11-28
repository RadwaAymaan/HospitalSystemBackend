using HMSWithLayers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Domain.Entities;

public class Medicine : AuditableEntity
{
    public string MedicineName { get; set; } = "";
    public string MedicineDescription { get; set; } = "";
    public int MedicineDosage { get; set; }
    public virtual ICollection<Prescription?> Prescriptions { get; set; } = new HashSet<Prescription>();
}
