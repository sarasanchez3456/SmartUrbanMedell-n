using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.Web.Pages.Paginas
{
    public class ProveedorGeo
    {
        public string RazonSocial { get; set; } = string.Empty;
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class ProveedoresModel : PageModel
    {
        public List<Proveedor> Proveedores { get; set; } = new();
        public List<ProveedorGeo> ProveedoresGeo { get; set; } = new();

        public void OnGet()
        {
            // TODO: reemplazar con ProveedorBLL.ObtenerTodos()
            Proveedores = new()
            {
                new(){ IdProveedor=1, RazonSocial="Eléctricos El Poblado", Contacto="Carlos Ríos",  Telefono="3001234567" },
                new(){ IdProveedor=2, RazonSocial="Plomeros Laureles",      Contacto="Ana Martínez", Telefono="3119876543" },
            };
            ProveedoresGeo = new()
            {
                new(){ RazonSocial="Eléctricos El Poblado", Lat=6.2090, Lng=-75.5680 },
                new(){ RazonSocial="Plomeros Laureles",     Lat=6.2442, Lng=-75.5950 },
            };
        }
    }
}