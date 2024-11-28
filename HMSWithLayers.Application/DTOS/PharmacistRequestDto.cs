using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class PharmacistRequestDto
{
    [Required]
    public string PharmacistEmail { get; set; } = "";
    [Required]
    public string PharmacistFirstName { get; set; } = "";
    [Required]
    public string PharmacistLastName { get; set; } = "";
    [Required]
    public string PharmacistPhoneNumber { get; set; } = "";
    [Required]
    public string UserName { get; set; } = "";
    public string Password { get; set; } = "";
    public DateOnly DateOfBirth { get; set; }
    public string Gender { get; set; } = "";
}
