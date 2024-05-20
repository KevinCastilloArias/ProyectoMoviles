using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entidades
{
    public class Usuario
    {
        public int ID_CORREO{ get; set; }
        public string TELEFONO {get; set; }
        public string CONTRASENA {  get; set; }
        public int ID_ROL {  get; set; }
        public int ACTIVO { get; set; }
    }
}
