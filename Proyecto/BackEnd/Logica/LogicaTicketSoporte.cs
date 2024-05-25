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

namespace BackEnd.Logica
{
    public class LogicaTicketSoporte
    {
        public ResIngresarTicketSoporte IngresarTicketSoporte(ReqIngresarTicketSoporte req)
        {
            ResIngresarTicketSoporte res = new ResIngresarTicketSoporte();
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en lógica - 3 Error no controlado

            try
            {
                if (String.IsNullOrEmpty(req.ticketSoporte.DETALLE))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Detalle del ticket faltante");
                    tipoRegistro = 2; // No Exitoso
                }
                if (req.ticketSoporte.ID_ESTADO <= 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("ID de estado inválido");
                    tipoRegistro = 2; // No Exitoso
                }
                if (!res.listaDeErrores.Any()) // Lista vacía
                {
                    // No hay errores
                    // Enviar a LINQ
                    ConexionDataContext linq = new ConexionDataContext();
                    int? idReturn = 0;
                    int? idError = 0;
                    String errorBD = "";
                    linq.SP_INGRESAR_TICKET_SOPORTE(req.ticketSoporte.DETALLE, req.ticketSoporte.ID_ESTADO, ref idReturn, ref idError, ref errorBD);
                    if (idError == null || idError == 0)
                    {
                        res.resultado = false;
                        res.listaDeErrores.Add(errorBD); // GRAVE!!
                        tipoRegistro = 2; // No Exitoso
                    }
                    else
                    {
                        res.resultado = true;
                        tipoRegistro = 1; // Exitoso
                    }
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
        public ResActualizarTicketSoporte EditarTicketSoporte(ReqActualizarTicketSoporte req)
        {
            ResActualizarTicketSoporte res = new ResActualizarTicketSoporte();
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en lógica - 3 Error no controlado

            try
            {
                if (req.ticketSoporte.ID_TICKED_SOPORTE <= 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("ID de ticket de soporte inválido");
                    tipoRegistro = 2; // No Exitoso
                }
                if (String.IsNullOrEmpty(req.ticketSoporte.DETALLE))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Detalle del ticket faltante");
                    tipoRegistro = 2; // No Exitoso
                }
                if (req.ticketSoporte.ID_ESTADO <= 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("ID de estado inválido");
                    tipoRegistro = 2; // No Exitoso
                }
                if (!res.listaDeErrores.Any()) // Lista vacía
                {
                    // No hay errores
                    // Enviar a LINQ
                    ConexionDataContext linq = new ConexionDataContext();
                    int? idError = 0;
                    String errorBD = "";
                    linq.SP_EDITAR_TICKET_SOPORTE(req.ticketSoporte.ID_TICKED_SOPORTE, req.ticketSoporte.DETALLE, req.ticketSoporte.ID_ESTADO, ref idError, ref errorBD);
                    if (idError == null || idError == 0)
                    {
                        res.resultado = false;
                        res.listaDeErrores.Add(errorBD); // GRAVE!!
                        tipoRegistro = 2; // No Exitoso
                    }
                    else
                    {
                        res.resultado = true;
                        tipoRegistro = 1; // Exitoso
                    }
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
              //  Utilitarios.Utilitarios.CrearBitacora(res.listaDeErrores, tipoRegistro, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }

            return res;
        }
        public ResListarTicketSoporte ListarTicketsSoporte(ReqListarTicketSoporte req)
        {
            ResListarTicketSoporte res = new ResListarTicketSoporte();
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en lógica - 3 Error no controlado

            try
            {
                // Se agregan validaciones al request, según los criterios de búsqueda deseados
              

                int? idError = 0;
                String errorBD = "";
                ConexionDataContext linq = new ConexionDataContext();
                List<TicketSoporte> listaTicketsSoporte = linq.SP_LISTAR_TICKETS_SOPORTE(req.filtros.ID_ESTADO, req.filtros.FECHA_CREACION_DESDE, req.filtros.FECHA_CREACION_HASTA, ref tipoRegistro, ref errorBD);
                if (tipoRegistro == 1) // Exitoso
                {
                    res.resultado = true;
                    res.listaTicketsSoporte = listaTicketsSoporte;
                }
                else
                {
                    res.resultado = false;
                    res.listaDeErrores.Add(errorBD);
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
              //  Utilitarios.Utilitarios.CrearBitacora(res.listaDeErrores, tipoRegistro, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }

            return res;
        }



    }
}
