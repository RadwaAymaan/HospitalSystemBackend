using HMSWithLayers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Domain.Entities;

public class Room : AuditableEntity
{
    public int RoomNumber { get; set; }
    public bool Availability { get; set; }
    public int RoomTypeId { get; set; }
    public virtual RoomType RoomType { get; set; }
    public virtual ICollection<Patient>? Patients { get; set; } = new HashSet<Patient>();
}