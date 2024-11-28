using HMSWithLayers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Domain.Entities;

public class ItemCategory : AuditableEntity
{
    public string CategoryName { get; set; } = "";
    public int ReferenceNumber { get; set; }
    public int InventoryId { get; set; }
    public virtual Inventory Inventory { get; set; }
}
