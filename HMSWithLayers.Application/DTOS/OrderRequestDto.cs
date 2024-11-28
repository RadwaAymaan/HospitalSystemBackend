
using HMSWithLayers.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class OrderRequestDto
{
    [Required]
    public string From { get; set; } = "";
    [Required]
    public Status OrderStatus { get; set; }
    [Required]
    public DateTime OrderArrivalDate { get; set; }
    [Required]
    public ICollection<ItemOrderRequestDto> ItemOrders { get; set; }
}
