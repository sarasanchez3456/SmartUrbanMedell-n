using System;
using System.Web.UI;
using SmartUrbanMedellin.BLL;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.Web.Paginas
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEstadisticas();
            }
        }

        private void CargarEstadisticas()
        {
            try
            {
                var proveedorBLL = new ProveedorBLL();
                var servicioBLL = new ServicioBLL();
                var solicitudBLL = new SolicitudBLL();
                var calificacionBLL = new CalificacionBLL();

                int totalProveedores = proveedorBLL.ObtenerTodos().Count;
                int totalServicios = servicioBLL.ObtenerTodos().Count;
                int totalSolicitudes = solicitudBLL.ObtenerTodos().Count;
                int totalCalificaciones = calificacionBLL.ObtenerTodos().Count;

                lblProveedores.InnerText = totalProveedores.ToString();
                lblServicios.InnerText = totalServicios.ToString();
                lblSolicitudes.InnerText = totalSolicitudes.ToString();
                lblCalificaciones.InnerText = totalCalificaciones.ToString();
            }
            catch (Exception ex)
            {
                // En caso de error, mostrar 0
                lblProveedores.InnerText = "0";
                lblServicios.InnerText = "0";
                lblSolicitudes.InnerText = "0";
                lblCalificaciones.InnerText = "0";
            }
        }
    }
}
