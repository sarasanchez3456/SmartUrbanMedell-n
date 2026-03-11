using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartUrbanMedellin.ENT;

namespace SmartUrbanMedellin.Web.Pages.Paginas
{
    public class ServicioVM : Servicio
    {
        public string Emoji { get; set; } = "🛠️";
        public string ColorBg { get; set; } = "bg-blue-600";
    }

    public class ServiciosModel : PageModel
    {
        public List<ServicioVM> Servicios { get; set; } = new();

        public void OnGet()
        {
            // TODO: cargar desde ServicioBLL.ObtenerTodos()
            Servicios = new()
            {
                new(){ IdServicio=1, Nombre="Electricidad", Descripcion="Instalaciones eléctricas residenciales y comerciales.", Categoria="Hogar",        Emoji="⚡", ColorBg="bg-yellow-500" },
                new(){ IdServicio=2, Nombre="Plomería",     Descripcion="Reparación de tuberías, sanitarios y filtraciones.",    Categoria="Hogar",        Emoji="🔧", ColorBg="bg-blue-600"   },
                new(){ IdServicio=3, Nombre="Carpintería",  Descripcion="Muebles a la medida, reparaciones y acabados.",         Categoria="Construcción", Emoji="🪚", ColorBg="bg-amber-700"  },
                new(){ IdServicio=4, Nombre="Pintura",      Descripcion="Pintura interior y exterior, acabados decorativos.",    Categoria="Construcción", Emoji="🎨", ColorBg="bg-red-500"    },
                new(){ IdServicio=5, Nombre="Jardinería",   Descripcion="Mantenimiento de zonas verdes y jardines.",             Categoria="Exterior",     Emoji="🌿", ColorBg="bg-green-600"  },
                new(){ IdServicio=6, Nombre="Limpieza",     Descripcion="Limpieza profunda de hogares y oficinas.",              Categoria="Hogar",        Emoji="🧹", ColorBg="bg-violet-600" },
            };
        }
    }
}