using System;
using System.Web.UI;
using SmartUrbanMedellin.BLL;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.Web.Paginas
{
    public partial class RegistrarProveedor : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var proveedor = new Proveedor
                {
                    RazonSocial = txtRazonSocial.Text.Trim(),
                    Contacto = txtContacto.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Latitud = string.IsNullOrEmpty(hdnLat.Value) ? 0 : Convert.ToDouble(hdnLat.Value),
                    Longitud = string.IsNullOrEmpty(hdnLng.Value) ? 0 : Convert.ToDouble(hdnLng.Value),
                    Estado = "Activo"
                };

                var bll = new ProveedorBLL();
                bll.Insertar(proveedor);

                Response.Redirect("/Paginas/Proveedores.aspx?success=1");
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                Response.Write("<script>alert('Error al guardar: " + ex.Message + "');</script>");
            }
        }
    }
}
