using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entidades
{
    public class ResListarTicketSoporte :ResBase
    {
        public List<TicketSoporte> listaTicketSoportes = new LinkedList<TicketSoporte>();
    }
}
