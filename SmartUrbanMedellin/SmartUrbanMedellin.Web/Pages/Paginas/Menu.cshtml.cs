using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmartUrbanMedellin.Web.Pages.Paginas
{
    public class MenuItem
    {
        public string Emoji { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }

    public class MenuModel : PageModel
    {
        public List<MenuItem> Items { get; set; } = new();

        public void OnGet()
        {
            Items = new()
            {
                new(){ Emoji="🏪", Titulo="Proveedores",         Descripcion="Ver y gestionar proveedores",              Url="/Paginas/Proveedores"        },
                new(){ Emoji="🛠️", Titulo="Servicios",           Descripcion="Catálogo de servicios disponibles",        Url="/Paginas/Servicios"          },
                new(){ Emoji="📋", Titulo="Solicitudes",         Descripcion="Gestionar solicitudes de servicio",        Url="/Paginas/Solicitudes"        },
                new(){ Emoji="➕", Titulo="Registrar Proveedor", Descripcion="Agregar nuevo proveedor con ubicación",    Url="/Paginas/RegistrarProveedor" },
                new(){ Emoji="📤", Titulo="Solicitar Servicio",  Descripcion="Crear nueva solicitud con ubicación",     Url="/Paginas/SolicitarServicio"  },
                new(){ Emoji="⭐", Titulo="Calificar Servicio",  Descripcion="Evaluar la calidad del servicio recibido", Url="/Paginas/CalificarServicio"  },
            };
        }
    }
}