using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entidades
{
    public class TicketSoporte
    {
        public int ID_TICKED_SOPORTE { get; set; }
        public string DETALLE { get; set; }
        public byte[] IMAGEN1 { get; set; }
        public byte[] IMAGEN2 { get; set; }
        public byte[] IMAGEN3 { get; set; }
        public string FECHA_CREACION { get; set; }
        public string FECHA_MODIFICACION { get; set; }
        public int ID_ESTADO { get; set; }
    }
}
