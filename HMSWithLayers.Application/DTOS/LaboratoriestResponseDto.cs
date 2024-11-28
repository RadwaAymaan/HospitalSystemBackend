using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;
public class LaboratoriestResponseDto
{
    public string Id { get; set; } = "";
    [EmailAddress]
    public string LaboratoriestEmail { get; set; } = "";
    public string LaboratoriestFirstName { get; set; } = "";
    public string LaboratoriestLastName { get; set; } = "";
    [Phone]
    public string LaboratoriestPhoneNumber { get; set; } = "";
    public string LaboratoriestUserName { get; set; } = "";
}
