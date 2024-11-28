using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class RoomTypeResponseDto
{
    public int Id { get; set; }
    public string Type { get; set; } = "";
    public int NumberOfPatient { get; set; }
}
