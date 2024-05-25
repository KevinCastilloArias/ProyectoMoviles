using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entidades
{
    public class ReqIngresarTicketSoporte : ReqBase
    {
        public TicketSoporte ticketSoporte { get; set; }
    }
}
