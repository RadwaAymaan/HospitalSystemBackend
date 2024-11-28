using HMSWithLayers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Domain.Entities;

public class RoomNurse : BaseEntity
{
    public int RoomId { get; set; }
    public virtual Room Room { get; set; }
    public string NurseId { get; set; }
    public virtual Nurse Nurse { get; set; }
}
