using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IMessagingService: IApplicationService, IScopedService
{
    Task SendMessage(string recipient, string subject, string message);
}
