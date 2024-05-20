using BackEnd.AccesoDatos;
using BackEnd.Entidades;
using BackEnd.Utiliarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Logica
{
    public class LogicaUsuario
    {
        public ResIngresarUsuario IngresarUsuario(ReqIngresarUsuario req)
        {
            ResIngresarUsuario res = new ResIngresarUsuario();
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en lógica - 3 Error no controlado
            try
            {
                if (String.IsNullOrEmpty(req.usuario.TELEFONO))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Teléfono faltante");
                    tipoRegistro = 2; // No Exitoso
                }
                if (String.IsNullOrEmpty(req.usuario.CONTRASENA))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Contraseña faltante");
                    tipoRegistro = 2; // No Exitoso
                }
                if (req.usuario.ID_ROL <= 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("ID de rol inválido");
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
                    linq.SP_INGRESAR_USUARIO(req.usuario.TELEFONO, req.usuario.CONTRASENA, req.usuario.ID_ROL, ref idReturn, ref idError, ref errorBD);
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
                Utilitarios.Utilitarios.CrearBitacora(res.listaDeErrores, tipoRegistro, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }
            return res;
        }
        public ResEditarUsuario EditarUsuario(ReqEditarUsuario req)
        {
            ResEditarUsuario res = new ResEditarUsuario();
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en lógica - 3 Error no controlado
            try
            {
                if (req.usuario.ID_CORREO <= 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("ID de correo inválido");
                    tipoRegistro = 2; // No Exitoso
                }
                if (String.IsNullOrEmpty(req.usuario.TELEFONO))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Teléfono faltante");
                    tipoRegistro = 2; // No Exitoso
                }
                if (String.IsNullOrEmpty(req.usuario.CONTRASENA))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Contraseña faltante");
                    tipoRegistro = 2; // No Exitoso
                }
                if (req.usuario.ID_ROL <= 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("ID de rol inválido");
                    tipoRegistro = 2; // No Exitoso
                }
                if (!res.listaDeErrores.Any()) // Lista vacía
                {
                    // No hay errores
                    // Enviar a LINQ
                    ConexionDataContext linq = new ConexionDataContext();
                    int? idError = 0;
                    String errorBD = "";
                    linq.SP_EDITAR_USUARIO(req.usuario.ID_CORREO, req.usuario.TELEFONO, req.usuario.CONTRASENA, req.usuario.ID_ROL, ref idError, ref errorBD);
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
                Utilitarios.Utilitarios.CrearBitacora(res.listaDeErrores, tipoRegistro, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }
            return res;
        }
        public ResEliminarUsuario EliminarUsuario(ReqEliminarUsuario req)
        {
            ResEliminarUsuario res = new ResEliminarUsuario();
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en lógica - 3 Error no controlado
            try
            {
                if (req.usuario.ACTIVO <= 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("ID de usuario inválido");
                    tipoRegistro = 2; // No Exitoso
                }
                if (!res.listaDeErrores.Any()) // Lista vacía
                {
                    // No hay errores
                    // Enviar a LINQ
                    ConexionDataContext linq = new ConexionDataContext();
                    int? idError = 0;
                    String errorBD = "";
                    linq.SP_DESACTIVAR_USUARIO(req.idUsuario, ref idError, ref errorBD);
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
                Utilitarios.Utilitarios.CrearBitacora(res.listaDeErrores, tipoRegistro, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }
            return res;
        }
        public ResListarUsuarios ListarUsuarios(ReqListarUsuarios req)
        {
            ResListarUsuarios res = new ResListarUsuarios();
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en lógica - 3 Error no controlado
            try
            {
                int? idError = 0;
                String errorBD = "";
                // No se valida nada en el request, ya que se asume que se quieren listar todos los usuarios
                ConexionDataContext linq = new ConexionDataContext();
                List<Usuario> listaUsuarios = linq.SP_LISTAR_USUARIOS(ref tipoRegistro, ref errorBD);
                if (tipoRegistro == 1) // Exitoso
                {
                    res.resultado = true;
                    res.listaUsuarios = listaUsuarios;
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
                Utilitarios.Utilitarios.CrearBitacora(res.listaDeErrores, tipoRegistro, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }
            return res;
        }




    }
}