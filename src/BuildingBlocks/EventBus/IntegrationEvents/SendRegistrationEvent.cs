using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationEvents
{
    public class SendRegistrationEvent :IntegrationEvent
    {
        public string? Registration { get; set; }
    }
}
