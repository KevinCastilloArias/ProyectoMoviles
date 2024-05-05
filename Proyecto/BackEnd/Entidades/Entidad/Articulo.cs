using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entidades
{
    public class Articulo
    {
        public int ID_ARTICULO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public int CANTIDAD_DISPONIBLE { get; set; }
        public decimal PRECIO { get; set; }
        public byte[] IMAGEN { get; set; }
        public int ID_CATEGORIA { get; set; }
    }
}
