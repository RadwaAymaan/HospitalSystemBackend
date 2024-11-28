using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class PharmacistResponseDto
{
    public string Id { get; set; } = "";
    public string PharmacistEmail { get; set; } = "";
    public string PharmacistFirstName { get; set; } = "";
    public string PharmacistLastName { get; set; } = "";
    public string PharmacistPhoneNumber { get; set; } = "";
    public string UserName { get; set; } = "";
}
