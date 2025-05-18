using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain
{
    public class PlateRecord : Plate
    {
        public string? PromoName { get; set; }
        public bool HasPromo { get; set; } = false;
    }
}
