using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entidades
{
    public class TicketSolicitud
    {
        public int ID_TICKET_SOLICITUD { get; set; }
        public string ID_USUARIO { get; set; }
        public string DETALLE {  get; set; }
        public string FECHA_VISITA {  get; set; }
        
    }
}
