using BackEnd.Entidades;
using BackEnd.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiProyecto.Controllers
{
    public class ArticuloController : Controller
    {
        // GET: Articulo
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/articulo/insertar")]
        public ResIngresarArticulo insertarArticulo(ReqIngresarArticulo req)
        {
            return new LogArticulo().IngresarArticulo(req);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/articulo/listar")]
        public ResObtenerArticulo obtenerArticulo()
        {
            return new LogArticulo().obtenerArticulo();
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/articulo/actualizar")]
        public ResIngresarArticulo actualizarArticulo(ReqIngresarArticulo req)
        {
            return new LogArticulo().actualizarArticulo(req);
        }


        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/articulo/eliminar/{id}")]
        public ResIngresarArticulo eliminarArticulo(int id)
        {
            return new LogArticulo().eliminarArticulo(id);
        }
    }
}