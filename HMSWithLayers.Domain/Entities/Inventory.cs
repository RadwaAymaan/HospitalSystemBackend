using HMSWithLayers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Domain.Entities;

public class Inventory : BaseEntity
{
    public string InventoryName { get; set; } = "";
    public string InventoryLocation { get; set; } = "";
    public int InventoryCapacity { get; set; }
    public virtual ICollection<ItemCategory> Categories { get; set; } = new HashSet<ItemCategory>();
}
