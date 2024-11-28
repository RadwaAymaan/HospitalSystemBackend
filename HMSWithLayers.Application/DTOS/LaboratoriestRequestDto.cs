using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class LaboratoriestRequestDto
{
    [EmailAddress]
    [Required] 
    public string LaboratoriestEmail { get; set; } = "";
    [Required]
    public string LaboratoriestFirstName { get; set; } = "";
    [Required]
    public string LaboratoriestLastName { get; set; } = "";
    [Phone]
    [Required]
    public string LaboratoriestPhoneNumber { get; set; } = "";
    [Required]
    public string UserName { get; set; } = "";
    [Required]
    public string Password { get; set; } = "";
    [Required]
    public DateOnly DateOfBirth { get; set; }
    [Required]
    public string Gender { get; set; } = "";
}
