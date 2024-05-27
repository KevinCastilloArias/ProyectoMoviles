using BackEnd.AccesoDatos;
using BackEnd.Entidades;
using BackEnd.Utiliarios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.LogicaTicketSolicitud
{
    public class LogicaTicketSolicitud
    {
        public ResIngresarTicketSolicitud IngresarTicketSolicitud(ReqIngresarTicketSolicitud req)
        {
            ResIngresarTicketSolicitud res = new ResIngresarTicketSolicitud();
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en lógica - 3 Error no controlado

            try
            {
                if (String.IsNullOrEmpty(req.ticketSolicitud.DETALLE))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Detalle del ticket faltante");
                    tipoRegistro = 2; // No Exitoso
                }
                if (String.IsNullOrEmpty(req.ticketSolicitud.ID_USUARIO))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("ID de usuario faltante");
                    tipoRegistro = 2; // No Exitoso
                }
                if (req.ticketSolicitud.FECHA_VISITA == DateTime.MinValue)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Fecha de visita inválida");
                    tipoRegistro = 2; // No Exitoso
                }
                if (!res.listaDeErrores.Any()) // Lista vacía
                {
                    // No hay errores
                    // Enviar a LINQ
                    ConexionDataContext linq = new ConexionDataContext();
                    linq.SP_AgregarTicketSolicitudSoporte(req.ticketSolicitud.ID_USUARIO, req.ticketSolicitud.DETALLE, req.ticketSolicitud.FECHA_VISITA);

                    res.resultado = true;
                    tipoRegistro = 1; // Exitoso
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add("Error interno: " + ex.Message);
                tipoRegistro = 3; // No exitoso
            }
            finally
            {
                // Se bitacorea todo resultado. Exitoso o no exitoso.
               // Utilitarios.Utilitarios.CrearBitacora(res.listaDeErrores, tipoRegistro, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }

            return res;
        }
    }
}
