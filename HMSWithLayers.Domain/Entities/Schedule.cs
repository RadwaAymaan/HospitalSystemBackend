using HMSWithLayers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Domain.Entities;

public class Schedule : AuditableEntity
{
    public int? TimeSlotId { get; set; }
    public virtual Doctor Doctor { get; set; }
    public virtual TimeSlot TimeSlot { get; set; }
}