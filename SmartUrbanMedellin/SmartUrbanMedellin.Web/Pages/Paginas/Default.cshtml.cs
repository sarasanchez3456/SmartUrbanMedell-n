using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmartUrbanMedellin.Web.Pages.Paginas
{
    public class StatCard
    {
        public string Emoji { get; set; } = string.Empty;
        public string Valor { get; set; } = string.Empty;
        public string Etiqueta { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }

    public class DefaultModel : PageModel
    {
        public List<StatCard> Stats { get; set; } = new();

        public void OnGet()
        {
            Stats = new()
            {
                new(){ Emoji="🏪", Valor="0", Etiqueta="Proveedores",    Url="/Paginas/Proveedores" },
                new(){ Emoji="🛠️", Valor="0", Etiqueta="Servicios",      Url="/Paginas/Servicios"   },
                new(){ Emoji="📋", Valor="0", Etiqueta="Solicitudes",    Url="/Paginas/Solicitudes" },
                new(){ Emoji="⭐", Valor="0", Etiqueta="Calificaciones", Url="/Paginas/CalificarServicio" },
            };
        }
    }
}