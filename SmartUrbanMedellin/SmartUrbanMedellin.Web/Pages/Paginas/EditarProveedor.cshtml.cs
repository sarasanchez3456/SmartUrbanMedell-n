using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.Web.Pages.Paginas
{
    public class EditarProveedorModel : PageModel
    {
        [BindProperty] public Proveedor Proveedor { get; set; } = new();
        [BindProperty] public double Lat { get; set; }
        [BindProperty] public double Lng { get; set; }

        public void OnGet(int id)
        {
            // TODO: reemplazar con ProveedorBLL.ObtenerPorId(id)
            Proveedor = new() { IdProveedor = id, RazonSocial = "Ejemplo S.A.S", Contacto = "Contacto", Telefono = "3000000000", Correo = "ejemplo@mail.com" };
            Lat = 6.2442; Lng = -75.5812;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            // TODO: ProveedorBLL.Actualizar(Proveedor)
            return RedirectToPage("/Paginas/Proveedores");
        }
    }
}