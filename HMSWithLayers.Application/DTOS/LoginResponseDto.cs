using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.DTOS;

public class LoginResponseDto
{
    public string UserName { get; set; }
    public string FullName { get; set; }
    public List<string> Roles { get; set; }
    public string Token { get; set; }
}
