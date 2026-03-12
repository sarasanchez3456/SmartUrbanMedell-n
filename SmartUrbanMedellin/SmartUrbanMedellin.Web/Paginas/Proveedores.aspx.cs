using System;
using System.Collections.Generic;
using System.Web.UI;
using SmartUrbanMedellin.BLL;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.Web.Paginas
{
    public partial class Proveedores : Page
    {
        public List<Proveedor> Proveedores { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedores();
                EliminarProveedor();
            }
        }

        private void CargarProveedores()
        {
            try
            {
                var bll = new ProveedorBLL();
                Proveedores = bll.ObtenerTodos();
                
                if (Proveedores == null)
                {
                    Proveedores = new List<Proveedor>();
                }
                
                rptProveedores.DataSource = Proveedores;
                rptProveedores.DataBind();
                
                trSinDatos.Visible = Proveedores.Count == 0;
            }
            catch
            {
                Proveedores = new List<Proveedor>();
                trSinDatos.Visible = true;
            }
        }

        private void EliminarProveedor()
        {
            string idEliminar = Request.QueryString["eliminar"];
            if (!string.IsNullOrEmpty(idEliminar))
            {
                try
                {
                    int id = Convert.ToInt32(idEliminar);
                    var bll = new ProveedorBLL();
                    bll.Eliminar(id);
                    Response.Redirect(Request.Url.AbsolutePath);
                }
                catch
                {
                    // Error al eliminar
                }
            }
        }
    }
}
