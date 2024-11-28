using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Domain.Entities;

public class Patient : ApplicationUser
{
    public int? RoomId { get; set; }
    public virtual Room? Room { get; set; }
}