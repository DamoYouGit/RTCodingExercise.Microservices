using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain
{
    public class PromoPlate: Plate
    {
        public Plate? plate { get; set; }
        public string? PromoName { get; set; }
        public bool HasPromo { get; set; } = false;
    }
}
