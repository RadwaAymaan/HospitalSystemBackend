﻿using HMSWithLayers.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Services;

public class UserContextService:IUserContextService
{
    public string UserId { get; set; } = "";
    public string Email { get; set; } = "";
}
