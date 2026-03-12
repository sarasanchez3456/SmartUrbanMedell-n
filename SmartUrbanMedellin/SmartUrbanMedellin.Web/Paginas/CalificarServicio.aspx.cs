using System;
using System.Web.UI;
using SmartUrbanMedellin.BLL;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.Web.Paginas
{
    public partial class CalificarServicio : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idSolicitud = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idSolicitud))
                {
                    hdnIdSolicitud.Value = idSolicitud;
                }
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(hdnIdSolicitud.Value))
                {
                    Response.Write("<script>alert('ID de solicitud no válido');</script>");
                    return;
                }

                int puntuacion = 0;
                if (rblPuntuacion.SelectedValue != "")
                {
                    puntuacion = Convert.ToInt32(rblPuntuacion.SelectedValue);
                }

                if (puntuacion == 0)
                {
                    Response.Write("<script>alert('Por favor seleccione una puntuación');</script>");
                    return;
                }

                var calificacion = new Calificacion
                {
                    IdSolicitud = Convert.ToInt32(hdnIdSolicitud.Value),
                    Puntuacion = puntuacion,
                    Comentario = txtComentario.Text.Trim(),
                    FechaCalificacion = DateTime.Now
                };

                var bll = new CalificacionBLL();
                bll.Insertar(calificacion);

                Response.Redirect("/Paginas/Solicitudes.aspx?rated=1");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al guardar: " + ex.Message + "');</script>");
            }
        }
    }
}
