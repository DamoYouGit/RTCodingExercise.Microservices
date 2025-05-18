using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain
{
    public class ReservationLog
    {
        public Guid Id { get; set; }
        public string? Registration {  get; set; }
        public bool IsReserved  { get; set; }
        public DateTime CreatedOn { get; set; } 

    }
}
