using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class NurseRequestDto
{
    [Required]
    public string NurseEmail { get; set; } = "";
    [Required]
    public string UserName { get; set; } = "";
    
    public string Password { get; set; } = "";
    [Required]
    public string NurseFirstName { get; set; } = "";
    [Required]
    public string NurseLastName { get; set; } = "";
    [Required]
    public string NursePhoneNumber { get; set; } = "";
 
    public DateOnly DateOfBirth { get; set; }
    
    public string Gender { get; set; } = "";
    [Required]
    public int SpecializationId { get; set; }
   
}
