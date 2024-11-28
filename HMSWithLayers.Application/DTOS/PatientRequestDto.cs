using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class PatientRequestDto
{
    [Required]
    public string UserName { get; set; } = "";
    [Required]
    public string PatientFirstName { get; set; } = "";
    [Required]
    public string PatientLastName { get; set; } = "";
    [Required]
    public string PatientEmail { get; set; } = "";
    [Required]
    public string Password { get; set; } = "";
    [Required]
    public string PatientPhoneNumber { get; set; } = "";
    [Required]
    public DateOnly DateOfBirth { get; set; }
}
