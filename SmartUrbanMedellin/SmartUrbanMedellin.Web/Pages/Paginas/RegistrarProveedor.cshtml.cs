using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartUrbanMedellin.ENT;
using SmartUrbanMedellin.BLL;

namespace SmartUrbanMedellin.Web.Pages.Paginas
{
    public class RegistrarProveedorModel : PageModel
    {
        private readonly ProveedorBLL _proveedorBLL = new();
        
        [BindProperty] public Proveedor Proveedor { get; set; } = new();

        public void OnGet() { }

        public IActionResult OnPost()
        {
            try
            {
                if (Proveedor == null || string.IsNullOrEmpty(Proveedor.Nombre))
                {
                    ModelState.AddModelError(string.Empty, "El nombre del proveedor es obligatorio");
                    return Page();
                }
                
                // Insertar el proveedor
                _proveedorBLL.Insertar(Proveedor);
                
                return RedirectToPage("/Paginas/Proveedores");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error al guardar: {ex.Message}");
                return Page();
            }
        }
    }
}