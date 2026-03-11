using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.Web.Pages.Paginas
{
    public class CalificarServicioModel : PageModel
    {
        [BindProperty] public Calificacion Calificacion { get; set; } = new();

        public void OnGet(int id = 0) { Calificacion.IdSolicitud = id; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            // TODO: CalificacionBLL.Insertar(Calificacion)
            return RedirectToPage("/Paginas/Solicitudes");
        }
    }
}