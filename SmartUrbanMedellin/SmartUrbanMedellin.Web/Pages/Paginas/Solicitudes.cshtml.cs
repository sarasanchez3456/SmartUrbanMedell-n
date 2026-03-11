using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.Web.Pages.Paginas
{
    public class SolicitudGeo
    {
        public int Id { get; set; }
        public string Estado { get; set; } = string.Empty;
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class SolicitudesModel : PageModel
    {
        public List<Solicitud> Solicitudes { get; set; } = new();
        public List<SolicitudGeo> SolicitudesGeo { get; set; } = new();

        public void OnGet()
        {
            // TODO: cargar desde SolicitudBLL.ObtenerTodos()
            Solicitudes = new()
            {
                new(){ IdSolicitud=1, IdUsuario=1, IdServicio=1, FechaSolicitud=DateTime.Now,             Estado="Pendiente" },
                new(){ IdSolicitud=2, IdUsuario=2, IdServicio=2, FechaSolicitud=DateTime.Now.AddDays(-1), Estado="Activo"    },
                new(){ IdSolicitud=3, IdUsuario=3, IdServicio=5, FechaSolicitud=DateTime.Now.AddDays(-3), Estado="Cancelado" },
            };
            SolicitudesGeo = new()
            {
                new(){ Id=1, Estado="Pendiente", Lat=6.2090, Lng=-75.5681 },
                new(){ Id=2, Estado="Activo",    Lat=6.2442, Lng=-75.5950 },
                new(){ Id=3, Estado="Cancelado", Lat=6.2700, Lng=-75.5812 },
            };
        }
    }
}