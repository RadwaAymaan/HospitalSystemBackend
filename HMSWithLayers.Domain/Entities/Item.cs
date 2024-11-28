using HMSWithLayers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Domain.Entities;

public class Item : AuditableEntity
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int Stock { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public virtual ItemCategory Category { get; set; }
}