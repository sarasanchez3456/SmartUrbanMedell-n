using System;
using System.Collections.Generic;
using System.Web.UI;
using SmartUrbanMedellin.BLL;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.Web.Paginas
{
    public partial class Solicitudes : Page
    {
        public List<Solicitud> Solicitudes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSolicitudes();
            }
        }

        private void CargarSolicitudes()
        {
            try
            {
                var bll = new SolicitudBLL();
                Solicitudes = bll.ObtenerTodos();
                
                if (Solicitudes == null)
                {
                    Solicitudes = new List<Solicitud>();
                }
                
                rptSolicitudes.DataSource = Solicitudes;
                rptSolicitudes.DataBind();
                
                trSinSolicitudes.Visible = Solicitudes.Count == 0;
            }
            catch
            {
                Solicitudes = new List<Solicitud>();
                trSinSolicitudes.Visible = true;
            }
        }

        public string GetBadgeClass(string estado)
        {
            switch (estado)
            {
                case "Activo":
                    return "badge badge-verde";
                case "Pendiente":
                    return "badge badge-amarillo";
                default:
                    return "badge badge-rojo";
            }
        }
    }
}
