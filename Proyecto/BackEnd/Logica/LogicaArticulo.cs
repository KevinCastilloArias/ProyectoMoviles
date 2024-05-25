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
    public class LogArticulo
    {
        public ResIngresarArticulo IngresarArticulo(ReqIngresarArticulo req)
        {
            ResIngresarArticulo res = new ResIngresarArticulo();
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en lógica - 3 Error no controlado
            try
            {
                if (String.IsNullOrEmpty(req.articulo.NOMBRE))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Nombre faltante");
                    tipoRegistro = 2; // No Exitoso
                }
                if (String.IsNullOrEmpty(req.articulo.DESCRIPCION))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Descripción faltante");
                    tipoRegistro = 2; // No Exitoso
                }
                if (req.articulo.CANTIDAD_DISPONIBLE <= 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Cantidad disponible debe ser mayor que cero");
                    tipoRegistro = 2; // No Exitoso
                }
                if (req.articulo.PRECIO <= 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Precio debe ser mayor que cero");
                    tipoRegistro = 2; // No Exitoso
                }
                if (req.articulo.IMAGEN == null || req.articulo.IMAGEN.Length == 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Imagen faltante");
                    tipoRegistro = 2; // No Exitoso
                }
                if (req.articulo.ID_CATEGORIA <= 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("ID de categoría inválido");
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
                    linq.SP_INGRESAR_ARTICULO(req.articulo.NOMBRE, req.articulo.DESCRIPCION, req.articulo.CANTIDAD_DISPONIBLE, req.articulo.PRECIO, req.articulo.IMAGEN, req.articulo.ID_CATEGORIA, ref idReturn, ref idError, ref errorBD);
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
        public ResObtenerArticulo ObtenerArticulos()
        {
            ResObtenerArticulo res = new ResObtenerArticulo();
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en lógica - 3 Error no controlado
            try
            {
                // Validar parámetros de búsqueda (si aplica)
                // ...

                ConexionDataContext linq = new ConexionDataContext();
                List<Articulo> articulos = linq.SP_OBTENER_ARTICULOS();

                if (articulos == null || articulos.Count == 0)
                {
                    res.resultado = false;
                   // res.listaDeMensajes.Add("No se encontraron artículos");
                    tipoRegistro = 2; // No Exitoso
                }
                else
                {
                    res.resultado = true;
                    res.listaArticulos = articulos;
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
        public ResActualizarArticulo ActualizarArticulo(ReqActualizarArticulo req)
        {
            ResActualizarArticulo res = new ResActualizarArticulo();
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en lógica - 3 Error no controlado
            try
            {
                if (String.IsNullOrEmpty(req.articulo.NOMBRE))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Nombre faltante");
                    tipoRegistro = 2; // No Exitoso
                    return res;
                }
                if (String.IsNullOrEmpty(req.articulo.DESCRIPCION))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Descripción faltante");
                    tipoRegistro = 2; // No Exitoso
                    return res;
                }
                if (req.articulo.CANTIDAD_DISPONIBLE <= 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Cantidad disponible debe ser mayor que cero");
                    tipoRegistro = 2; // No Exitoso
                    return res;
                }
                if (req.articulo.PRECIO <= 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Precio debe ser mayor que cero");
                    tipoRegistro = 2; // No Exitoso
                    return res;
                }
                if (req.articulo.IMAGEN == null || req.articulo.IMAGEN.Length == 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Imagen faltante");
                    tipoRegistro = 2; // No Exitoso
                    return res;
                }
                if (req.articulo.ID_CATEGORIA <= 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("ID de categoría inválido");
                    tipoRegistro = 2; // No Exitoso
                    return res;
                }

                ConexionDataContext linq = new ConexionDataContext();
                int? idError = 0;
                String errorBD = "";
                linq.SP_ACTUALIZAR_ARTICULO(req.articulo.ID, req.articulo.NOMBRE, req.articulo.DESCRIPCION, req.articulo.CANTIDAD_DISPONIBLE, req.articulo.PRECIO, req.articulo.IMAGEN, req.articulo.ID_CATEGORIA, ref idError, ref errorBD);

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

        public ResEliminarArticulo EliminarArticulo(ReqEliminarArticulo req)
        {
            ResEliminarArticulo res = new ResEliminarArticulo();
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en lógica - 3 Error no controlado
            try
            {
                if (req.idArticulo <= 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("ID de artículo inválido");
                    tipoRegistro = 2; // No Exitoso
                    return res;
                }

                ConexionDataContext linq = new ConexionDataContext();
                int? idError = 0;
                String errorBD = "";
                linq.SP_ELIMINAR_ARTICULO(req.idArticulo, ref idError, ref errorBD);

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
               // Utilitarios.Utilitarios.CrearBitacora(res.listaDeErrores, tipoRegistro, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }
            return res;
        }


    }
}
