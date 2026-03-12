using System;
using System.Web.UI;
using SmartUrbanMedellin.BLL;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.Web.Paginas
{
    public partial class EditarProveedor : Page
    {
        public double Lat { get; set; }
        public double Lng { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedor();
            }
        }

        private void CargarProveedor()
        {
            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                var bll = new ProveedorBLL();
                var proveedor = bll.ObtenerPorId(id);

                if (proveedor != null)
                {
                    hdnIdProveedor.Value = proveedor.IdProveedor.ToString();
                    txtRazonSocial.Text = proveedor.RazonSocial;
                    txtContacto.Text = proveedor.Contacto;
                    txtTelefono.Text = proveedor.Telefono;
                    txtCorreo.Text = proveedor.Correo;
                    Lat = proveedor.Latitud;
                    Lng = proveedor.Longitud;
                    hdnLat.Value = Lat.ToString();
                    hdnLng.Value = Lng.ToString();
                }
            }
            catch
            {
                Response.Redirect("/Paginas/Proveedores.aspx");
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var proveedor = new Proveedor
                {
                    IdProveedor = Convert.ToInt32(hdnIdProveedor.Value),
                    RazonSocial = txtRazonSocial.Text.Trim(),
                    Contacto = txtContacto.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Latitud = string.IsNullOrEmpty(hdnLat.Value) ? 0 : Convert.ToDouble(hdnLat.Value),
                    Longitud = string.IsNullOrEmpty(hdnLng.Value) ? 0 : Convert.ToDouble(hdnLng.Value)
                };

                var bll = new ProveedorBLL();
                bll.Actualizar(proveedor);

                Response.Redirect("/Paginas/Proveedores.aspx?updated=1");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al actualizar: " + ex.Message + "');</script>");
            }
        }
    }
}
