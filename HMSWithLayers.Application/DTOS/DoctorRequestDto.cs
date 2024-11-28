using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class DoctorRequestDto
{
    [Required]
    public string DoctorEmail { get; set; } = "";
    [Required]
    public string DoctorFirstName { get; set; } = "";
    [Required]
    public string DoctorLastName { get; set; } = "";
    [Required]
    public string DoctorPhoneNumber { get; set; } = "";
    [Required]
    public string UserName { get; set; } = "";
    public string Password { get; set; } = "";
    public DateOnly DateOfBirth { get; set; }
    public string Gender { get; set; } = "";
    [Required]
    public int SpecializationId { get; set; }
}
