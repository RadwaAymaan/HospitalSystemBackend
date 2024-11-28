using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class RoomGetAllResponseDto
{
    public int Id { get; set; }
    public int RoomNumber { get; set; }
    public bool Availability { get; set; }
    public RoomTypeResponseDto RoomType { get; set; }
}
