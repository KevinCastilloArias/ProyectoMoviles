using BackEnd.AccesoDatos;
using BackEnd.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Logica
{
    public class LogicaCategoria
    {
        public ResIngresarCategoria insertarCategoria(ReqIngresarCategoria req)
        {
            ResIngresarCategoria res = new ResIngresarCategoria();
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en lógica - 3 Error no controlado
            try
            {

                if (String.IsNullOrEmpty(req.categoria.NOMBRE))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Nombre faltante");
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
                    linq.SP_AgregarCategoria(req.categoria.NOMBRE, ref idReturn, ref idError, ref errorBD);
                    if (idError == null || idError == 0)
                    {
                        res.resultado = false;
                        res.listaDeErrores.Add(errorBD); // GRAVE!!
                        tipoRegistro = 2; // No Exitoso
                    }
                    else
                    {
                        res.resultado = true;
                        tipoRegistro = 1; // No Exitoso
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
                //Utilitarios.Utilitarios.CrearBitacora(res.listaDeErrores, tipoRegistro, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }
            return res;
        }
        public ResIngresarCategoria actualizarCategoria(ReqIngresarCategoria req)
        {
            ResIngresarCategoria res = new ResIngresarCategoria();
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en lógica - 3 Error no controlado
            try
            {
                if (String.IsNullOrEmpty(req.categoria.NOMBRE))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Nombre faltante");
                    tipoRegistro = 2; // No Exitoso
                    return res;
                }
                ConexionDataContext linq = new ConexionDataContext();
                int? idError = 0;
                String errorBD = "";
                linq.SP_AcutalizarCategoria(req.categoria.NOMBRE, ref idError, ref idError, ref errorBD);

                if (idError == null || idError == 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add(errorBD); // GRAVE!!
                    tipoRegistro = 2; // No Exitoso
                    return res;
                }
                else
                {
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
                //Utilitarios.Utilitarios.CrearBitacora(res.listaDeErrores, tipoRegistro, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }
            return res;
        }

        public ResObtenerCategoria ObtenerCategorias()
        {
            ResObtenerCategoria res = new ResObtenerCategoria();
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en lógica - 3 Error no controlado
            try
            {
                // Validar parámetros de búsqueda (si aplica)
                // ....

                ConexionDataContext linq = new ConexionDataContext();
                int? idError = 0;
                String errorBD = "";
                var linqCategorias = linq.SP_ObtenerCategorias();
                foreach (var item in linqCategorias)
                {
                    Categoria categoria = factoryArmarCategorias(item);
                    if (categoria != null)
                    {
                        res.listaCategorias.Add(categoria);
                    }
                }
                res.resultado = true;
                if (idError == null || idError == 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add(errorBD); // GRAVE!!
                    tipoRegistro = 2; // No Exitoso
                    return res;
                }
                else
                {
                    res.resultado = true;
                    tipoRegistro = 1; // Exitoso
                }
                if (linqCategorias == null)
                {
                    res.resultado = false;
                    // res.listaDeMensajes.Add("No se encontraron artículos");
                    tipoRegistro = 2; // No Exitoso
                }
                else
                {
                    res.resultado = true;
                    //res.paginado.totalRegistros = totalRegistros;
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
                // Utilitarios.Utilitarios.CrearBitacora(res.listaDeMensajes, tipoRegistro, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }
            return res;
        }

        public Categoria factoryArmarCategorias(SP_ObtenerCategoriasResult linq)
        {
            Categoria res = new Categoria();
            res.NOMBRE = linq.NOMBRE;
            return res;
        }

    }
}
