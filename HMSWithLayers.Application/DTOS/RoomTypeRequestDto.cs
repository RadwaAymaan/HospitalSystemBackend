using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class RoomTypeRequestDto
{
    [Required]
    public string Type { get; set; } = "";
    [Required]
    [Range(1, int.MaxValue)]
    public int NumberOfPatient { get; set; }
}
