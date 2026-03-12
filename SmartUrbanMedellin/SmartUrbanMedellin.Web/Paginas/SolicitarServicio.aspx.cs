using System;
using System.Web.UI;
using SmartUrbanMedellin.BLL;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.Web.Paginas
{
    public partial class SolicitarServicio : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarServicios();
                txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void CargarServicios()
        {
            try
            {
                var bll = new ServicioBLL();
                var servicios = bll.ObtenerTodos();
                
                ddlServicio.Items.Clear();
                ddlServicio.Items.Add(new System.Web.UI.WebControls.ListItem("— Seleccionar servicio —", ""));
                
                foreach (var s in servicios)
                {
                    ddlServicio.Items.Add(new System.Web.UI.WebControls.ListItem(
                        s.Nombre + " — " + s.Categoria, 
                        s.IdServicio.ToString()));
                }
            }
            catch
            {
                // Datos de ejemplo
                ddlServicio.Items.Add(new System.Web.UI.WebControls.ListItem("Electricidad", "1"));
                ddlServicio.Items.Add(new System.Web.UI.WebControls.ListItem("Plomería", "2"));
                ddlServicio.Items.Add(new System.Web.UI.WebControls.ListItem("Carpintería", "3"));
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                var solicitud = new Solicitud
                {
                    IdServicio = Convert.ToInt32(ddlServicio.SelectedValue),
                    FechaSolicitud = DateTime.Now,
                    Estado = ddlEstado.SelectedValue,
                    Latitud = string.IsNullOrEmpty(hdnLat.Value) ? 0 : Convert.ToDouble(hdnLat.Value),
                    Longitud = string.IsNullOrEmpty(hdnLng.Value) ? 0 : Convert.ToDouble(hdnLng.Value)
                };

                var bll = new SolicitudBLL();
                bll.Insertar(solicitud);

                Response.Redirect("/Paginas/Solicitudes.aspx?success=1");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al guardar: " + ex.Message + "');</script>");
            }
        }
    }
}
