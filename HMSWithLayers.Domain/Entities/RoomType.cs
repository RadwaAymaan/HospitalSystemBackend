using HMSWithLayers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Domain.Entities;

public class RoomType : BaseEntity
{
    public string Type { get; set; } = "";
    public int NumberOfPatient { get; set; }
}