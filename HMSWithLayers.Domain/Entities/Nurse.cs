using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Domain.Entities;

public class Nurse : ApplicationUser
{
    public int SpecializationId { get; set; }
    public virtual Specialization Specialization { get; set; }
}