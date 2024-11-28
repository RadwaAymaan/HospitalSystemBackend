using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class RoomRequestDto
{
    [Required]
    [Range(1, int.MaxValue)]
    public int RoomNumber { get; set; }
    [Required]
    public bool Availability { get; set; } = true;
    [Required]
    public int RoomTypeId { get; set; }

}
