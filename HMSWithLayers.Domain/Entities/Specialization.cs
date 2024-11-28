using HMSWithLayers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Domain.Entities;

public class Specialization : BaseEntity
{
    public string SpecializationName { get; set; } = "";
    public virtual ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
    public virtual ICollection<Nurse> Nurses { get; set; } = new HashSet<Nurse>();
}