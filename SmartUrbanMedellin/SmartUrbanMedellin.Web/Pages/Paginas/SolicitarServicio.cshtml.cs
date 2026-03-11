using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.Web.Pages.Paginas
{
    public class SolicitarServicioModel : PageModel
    {
        [BindProperty] public Solicitud Solicitud { get; set; } = new();
        [BindProperty] public double Lat { get; set; }
        [BindProperty] public double Lng { get; set; }
        public List<Servicio> Servicios { get; set; } = new();

        public void OnGet(int idServicio = 0)
        {
            Solicitud.IdServicio = idServicio;
            Solicitud.FechaSolicitud = DateTime.Now;
            Solicitud.Estado = "Pendiente";
            // TODO: cargar desde ServicioBLL.ObtenerTodos()
            Servicios = new()
            {
                new(){ IdServicio=1, Nombre="Electricidad", Categoria="Hogar"        },
                new(){ IdServicio=2, Nombre="Plomería",     Categoria="Hogar"        },
                new(){ IdServicio=3, Nombre="Carpintería",  Categoria="Construcción" },
                new(){ IdServicio=4, Nombre="Pintura",      Categoria="Construcción" },
                new(){ IdServicio=5, Nombre="Jardinería",   Categoria="Exterior"     },
                new(){ IdServicio=6, Nombre="Limpieza",     Categoria="Hogar"        },
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            // TODO: SolicitudBLL.Insertar(Solicitud)
            return RedirectToPage("/Paginas/Solicitudes");
        }
    }
}