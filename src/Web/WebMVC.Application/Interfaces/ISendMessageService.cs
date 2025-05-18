using Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.Application.Interfaces
{
    internal interface ISendMessageService
    {
        public void SendMessage(Plate plate);
    }
}
